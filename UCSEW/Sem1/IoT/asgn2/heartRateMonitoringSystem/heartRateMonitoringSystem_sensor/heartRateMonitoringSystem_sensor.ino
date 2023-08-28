// WiFi
#include <ESP8266WiFi.h>
// Cloud
#include "Adafruit_MQTT.h"
#include "Adafruit_MQTT_Client.h"
// I2C
#include <Wire.h>
// MAX30102
#include "MAX30105.h"
#include "heartRate.h"

// Cloud vars
#define AIO_SERVER "io.adafruit.com"
#define AIO_SERVERPORT 1883
#define AIO_USERNAME "kyoowu"
#define AIO_KEY "aio_vKih61NVGevEqoYC4HPWFXxF709w"

// Base vars
const int BR = 9600;
const int LED_PIN = D5;
const int PORT = 80;
const char* DISPLAY_HOST= "192.168.101.37";
const int DISPLAY_PORT = 81;
const char* SSID = "";
const char* PASSWORD = "";

// Settings and object constructor
bool useLed = true;
bool useOled = true;
String settings = "";
MAX30105 particleSensor;
WiFiServer server(PORT);
WiFiClient cloudClient;
WiFiClient displayClient;
Adafruit_MQTT_Client mqtt(&cloudClient, AIO_SERVER, AIO_SERVERPORT, AIO_USERNAME, AIO_KEY);
Adafruit_MQTT_Subscribe cloudOLEDToggle = Adafruit_MQTT_Subscribe(&mqtt, AIO_USERNAME"/feeds/kduiotasgn2.oled-toggle");
Adafruit_MQTT_Publish highBPMChannel = Adafruit_MQTT_Publish(&mqtt, AIO_USERNAME"/feeds/kduiotasgn2.bpm-high");
Adafruit_MQTT_Publish normalBPMChannel = Adafruit_MQTT_Publish(&mqtt, AIO_USERNAME"/feeds/kduiotasgn2.bpm-normal");
Adafruit_MQTT_Publish lowBPMChannel = Adafruit_MQTT_Publish(&mqtt, AIO_USERNAME"/feeds/kduiotasgn2.bpm-low");

// MAX30102 vars
const byte RATE_SIZE = 10; //Increase this for more averaging.
byte rates[RATE_SIZE]; //Array of heart rates
byte rateSpot = 0;
long lastBeat = 0; //Time at which the last beat occurred
float beatsPerMinute;
int beatAvg = 0;
bool isFingerDetected;
bool isFingerDetectedLogged = false;
bool isFingerNotDetectedLogged = false;

void MQTT_connect() {
       int8_t ret;
 
    // Stop if already connected.
    if(mqtt.connected())
        return;
 
    Serial.print("Connecting to MQTT... ");
 
    uint8_t retries = 3;
    while((ret = mqtt.connect()) != 0){ // connect will return 0 for connected
        Serial.println(mqtt.connectErrorString(ret));
        Serial.println("Retrying MQTT connection in 5 seconds...");
        mqtt.disconnect();
        delay(1000);  // wait 10 seconds
        retries--;
        if(retries == 0)
            while (1); // basically die and wait for WDT to reset me
    }
    Serial.println("MQTT Connected!");
}

void printSiteHeader(WiFiClient client) {
  String ledOnUrl;
  String ledOffUrl;
  String oledOnUrl;
  String oledOffUrl;

  // Determine button routes
  if (useLed && useOled) {
    ledOnUrl = "/led=YES&OLED=YES/";
    ledOffUrl = "/led=NO&OLED=YES/";
    oledOnUrl = "/led=YES&OLED=YES/";
    oledOffUrl = "/led=YES&OLED=NO/";    
  } else if (useLed) {
    ledOnUrl = "/led=YES";
    ledOffUrl = "/led=NO";
    oledOnUrl = "/led=YES&OLED=YES/";
    oledOffUrl = "/led=YES&OLED=NO/";
  } else if (useOled) {
    ledOnUrl = "/led=YES&OLED=YES/";
    ledOffUrl = "/led=NO&OLED=YES/";
    oledOnUrl = "/OLED=YES/";
    oledOffUrl = "/OLED=NO/";
  } else {
    ledOnUrl = "/led=YES";
    ledOffUrl = "/led=NO";
    oledOnUrl = "/OLED=YES/";
    oledOffUrl = "/OLED=NO/";  
  }
  
  client.println("HTTP/1.1 200 OK");
  client.println("Content-Type: text/html");
  client.println("");

  String html = "<html><head><meta charset='utf-8'/><title>Heart rate monitoring system - Landing Page</title></head>";
  String ledStart = "<body><h1>Heart rate monitoring system</h1><p>Click the <b>Start</b> button to begin taking readings. 10 readings can be taken in a single session. Change the settings to toggle the use of LED and OLED display.</p><br/><p>Use LED: ";
  client.println(html + ledStart);
  if (useLed) {
    client.println("<b>YES</b></p>");
  } else {
    client.println("<b>NO</b></p>");
  }
  String ledEnd = "<a href='"+ ledOnUrl +"'><button>Yes</button></a>\n<a href='"+ ledOffUrl +"'><button>No</button></a><br/><br/>";
  String oledStart = "<p>Use OLED Display: ";
  client.println(ledEnd + oledStart);
  if (useOled) {
    client.println("<b>YES</b></p>");
  } else {
    client.println("<b>NO</b></p>");
  }
  String oledEnd = "<a href='"+ oledOnUrl +"'><button>Yes</button></a>\n<a href='"+ oledOffUrl +"'><button>No</button></a><br/><hr/>";
  client.println(oledEnd);
}

void getNewReadings(WiFiClient client) {
  String readingStart = "<h4><u>BPM Readings</u></h4><p>Put your finger steadily over the sensor. The reading will be taken indefinitely until the average BPM of 10 readings is determined, and normally lasts around 15 seconds.</p><ol>";      
  client.println(readingStart);
    
  while (!rates[RATE_SIZE-1] > 0) {
    long irValue = particleSensor.getIR();
    
    if (useOled) {
      //  Render loading animation
      displayClient.println("GET /READING HTTP/1.1\r\nHost: " + String(DISPLAY_HOST) + "\r\n" +
              "Connection: close\r\n");
    }
  
    if (irValue < 50000) {
      Serial.println("Finger not detected");
      isFingerDetected = false;
      delay(3000);
    } else {
      isFingerDetected = true;
    }

    if(!isFingerDetected) {
      isFingerDetectedLogged = false;
      if (!isFingerNotDetectedLogged) {
        client.println("<p><b>READING IS STILL ONGOING, BUT NO FINGER IS DETECTED!</b></p>"); 
        isFingerNotDetectedLogged = true;
      }
    } else {
      isFingerNotDetectedLogged = false;
      if(!isFingerDetectedLogged) {
        client.println("<p><b>READING BPM...</b></p>");
        isFingerDetectedLogged = true;
      }
    }

    if (isFingerDetected) {
      if (checkForBeat(irValue) == true)
      {
        //We sensed a beat!
        // Simulate heartbeat with LED
        if (useLed) {
          digitalWrite(LED_PIN, HIGH);
          delay(10);
          digitalWrite(LED_PIN, LOW);
          delay(1000);   
        }
        
        long delta = millis() - lastBeat;
        lastBeat = millis();

        beatsPerMinute = 60 * (delta / 1000.0);

        if (beatsPerMinute < 255 && beatsPerMinute > 20)
        {
          rates[rateSpot++] = (byte)beatsPerMinute; //Store this reading in the array
          rateSpot %= RATE_SIZE; //Wrap variable

          //Take average of readings
          beatAvg = 0;
          for (byte x = 0 ; x < RATE_SIZE ; x++)
            beatAvg += rates[x];
          beatAvg /= RATE_SIZE;
        }
      }
    }
  }
  
  if (beatAvg < 60) {
    // Low BPM
    lowBPMChannel.publish(beatAvg);;
  } else if (beatAvg > 100) {
    // High BPM
    highBPMChannel.publish(beatAvg);;
  } else {
    // Normal BPM
    normalBPMChannel.publish(beatAvg);;
  }

  // Print data to cloud and in website  
  client.println("</ol><p><b>Last BPM</b>: " + String(beatsPerMinute) + " | <b>Average BPM (10 readings)</b>: " + String(beatAvg) + "</p><a target='_blank' href='/new" + settings + "'><button>Retry</button></a>");
  String htmlEnd = "</body></html>";
  client.println(htmlEnd);
}

void setup()
{
  pinMode(LED_PIN, OUTPUT);
  digitalWrite(LED_PIN, LOW);

  Serial.begin(BR);

  WiFi.mode(WIFI_AP_STA);
  WiFi.begin(SSID, PASSWORD);

  // Initialize WiFi server
  while(WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(500);
  }
  Serial.println("Controller has connected to the WiFi.");

  server.begin();

  Serial.println("Server has been initialized at port 80.");
  Serial.print("URL: http://");
  Serial.print(WiFi.localIP());
  Serial.println("/");

  // Initialize sensor
  while(!particleSensor.begin(Wire, I2C_SPEED_FAST)) //Use default I2C port, 400kHz speed
  {
    Serial.print(".");
    delay(500);
  }
  Serial.println("MAX30102 is connected and ready.");
  particleSensor.setup(); //Configure sensor with default settings
  particleSensor.setPulseAmplitudeRed(0x0A); //Turn Red LED to low to indicate sensor is running
  particleSensor.setPulseAmplitudeGreen(0); //Turn off Green LED

  Serial.println("Place your index finger on the sensor with steady pressure.");

  // MQTT connection
  mqtt.subscribe(&cloudOLEDToggle); 
}

void loop()
{
  MQTT_connect();
 
  Adafruit_MQTT_Subscribe *read;
  while(read == mqtt.readSubscription(5000)) {
    if (read = &cloudOLEDToggle) {
      String msg = (char*) cloudOLEDToggle.lastread;
      Serial.print("MQTT-changed OLED status: ");
      Serial.println(msg);

      if (msg.indexOf("ON") != -1)
        useOled = true;
      else if (msg.indexOf("OFF") != -1)
        useOled = false;      
    }
  }

  WiFiClient client = server.available();
  if (!client) return;  // Don't do anything if no one is at the URL
  if (useOled && !displayClient.connect(DISPLAY_HOST, DISPLAY_PORT)) {
    Serial.println("Cannot connect to display.");
    return;
  };

  while(!client.available()) delay(1); // Block loop if client hasn't send page data yet
  String req = client.readStringUntil('\r');
  client.flush();

  if (req.indexOf("led=YES") != -1) {
    useLed = true;
    if (useOled) 
      settings = "/led=YES&OLED=YES";
    else if (!useOled)
      settings = "/led=YES&OLED=NO";
    else 
      settings = "/led=YES";
  }
  
  if (req.indexOf("led=NO") != -1) {
    useLed = false;
    if (useOled) 
      settings = "/led=NO&OLED=YES";
    else if (!useOled)
      settings = "/led=NO&OLED=NO";
    else 
      settings = "/led=NO";
  }
 
  if (req.indexOf("OLED=YES") != -1) {
    useOled = true;
    if (useLed) 
      settings = "/led=YES&OLED=YES";
    else if (!useLed)
      settings = "/led=NO&OLED=YES";
    else 
      settings = "/OLED=YES";
  }

  if (req.indexOf("OLED=NO") != -1) {
    useOled = false;
    displayClient.println("GET /OLED=NO HTTP/1.1\r\nHost: " + String(DISPLAY_HOST) + "\r\n" +
                "Connection: close\r\n");
    if (useLed) 
      settings = "/led=YES&OLED=NO";
    else if (!useLed)
      settings = "/led=NO&OLED=NO";
    else 
      settings = "/OLED=NO";
  }

  printSiteHeader(client); // Print site header (contains header section and settings)

  if (req.indexOf("/new") != -1) {
    memset(rates, 0, sizeof(rates));
    rateSpot = 0;
    beatAvg = beatsPerMinute = 0;
    getNewReadings(client);
  } else {
    client.println("<p>Start a new session: </p><a href='/new" + settings + "'><button>Start reading</button></a>");
    client.println("</body></html>");
  }

  if (useOled) {
    if (rates[RATE_SIZE-1] > 0) {    
      displayClient.println("GET /BPM=" + String(beatsPerMinute) +"&AVG=" + String(beatAvg) + "#/ HTTP/1.1\r\n" +
                            "Host: " + String(DISPLAY_HOST) + "\r\n" +
                            "Connection: close\r\n");
    } else {
      displayClient.println("GET /init HTTP/1.1\r\nHost: " + String(DISPLAY_HOST) + "\r\n" +
                          "Connection: close\r\n");
    } 
  } else {
    displayClient.println("GET /OLED=NO HTTP/1.1\r\nHost: " + String(DISPLAY_HOST) + "\r\n" +
                          "Connection: close\r\n");
  }
  
  if (!mqtt.ping()) mqtt.disconnect(); 
}


