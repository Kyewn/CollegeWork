#include <ESP8266WiFi.h>
#include "Adafruit_MQTT.h"
#include "Adafruit_MQTT_Client.h"

const int LED_PIN = D5;
const char* SSID = "BLSB13714";
const char* PASSWORD = "PHWPQH6023";

#define AIO_SERVER "io.adafruit.com"
#define AIO_SERVERPORT 1883
#define AIO_USERNAME "kyoowu"
#define AIO_KEY "aio_vKih61NVGevEqoYC4HPWFXxF709w"

WiFiClient client;
Adafruit_MQTT_Client mqtt(&client, AIO_SERVER, AIO_SERVERPORT, AIO_USERNAME, AIO_KEY);

// Subscribe in MQTT protocol means read
Adafruit_MQTT_Subscribe toggle = Adafruit_MQTT_Subscribe(&mqtt, AIO_USERNAME "/feeds/leds.led01");

// Publish in MQTT protocol means write
Adafruit_MQTT_Publish number = Adafruit_MQTT_Publish(&mqtt, AIO_USERNAME "/feeds/counter");

int value = 0;

void MQTT_connect();

void setup() {
  pinMode(LED_PIN, OUTPUT);
  digitalWrite(LED_PIN, LOW);

  Serial.begin(9600);
  delay(10);

  Serial.println("Adafruit MQTT");
  WiFi.begin(SSID, PASSWORD);
  while(WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print('.');
  }
  Serial.println("WiFi connected.");
  Serial.println();
  
  mqtt.subscribe(&toggle);
  
}


void loop() {
  MQTT_connect();
  
  // Write to Adafruit MQTT server
  Serial.print("\nSending number ");
  Serial.print(value);
  if(!number.publish(value++)){
	  Serial.println("Send failed.");
  }
  else{
	  Serial.println("Sent!");
  }
  if(value == 100){ // Reset
	  value = 0;
  }
  delay(5000);
  
  // Read LED status from Adafruit MQTT server
  Adafruit_MQTT_Subscribe *read;
  while(read == mqtt.readSubscription(5000)){
	  if(read = &toggle){
		  Serial.print("Status: ");
		  Serial.println((char*)toggle.lastread);
		  
		  String msg = (char*)toggle.lastread;
		  if(msg.indexOf("ON") != -1)
			  digitalWrite(LED_PIN, HIGH);
		  else if(msg.indexOf("OFF") != -1)
			  digitalWrite(LED_PIN, LOW);
	  }
  }
  
  if (!mqtt.ping()) mqtt.disconnect();
}

// Function to connect and reconnect as necessary to the MQTT server.
// Should be called in the loop function and it will take care if connecting.
void MQTT_connect(){
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
        delay(10000);  // wait 10 seconds
        retries--;
        if(retries == 0)
            while (1); // basically die and wait for WDT to reset me
    }
    Serial.println("MQTT Connected!");
}