#include <ESP8266WiFi.h>
#include "Adafruit_MQTT.h"
#include "Adafruit_MQTT_Client.h"

const int LED_PIN = D5;
const char* SSID;
const char* PASSWORD;

#define AIO_SERVER "io.adafruit.com"
#define AIO_SERVERPORT 1883
#define AIO_USERNAME "kyoowu"
#define AIO_KEY "aio_vKih61NVGevEqoYC4HPWFXxF709w"

WiFiClient client;
Adafruit_MQTT_Client mqtt(&client, AIO_SERVER, AIO_SERVERPORT, AIO_USERNAME, AIO_KEY);
Adafruit_MQTT_Subscribe toggle = Adafruit_MQTT_Subscribe(&mqtt, AIO_USERNAME"/feeds/leds.led-1");
Adafruit_MQTT_Publish counter = Adafruit_MQTT_Publish(&mqtt, AIO_USERNAME"/feeds/leds.counter");

int value = 0;
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

  Serial.print("Sending number ");
  Serial.print(value);
  if (!counter.publish(value++)) {
    Serial.println(" Send failed.");
  } else {
    Serial.println(" Sent.");
  }
  delay(5000);
  
  Adafruit_MQTT_Subscribe *read;
  while(read == mqtt.readSubscription(5000)) {
    if (read = &toggle) {
      String msg = (char*) toggle.lastread;
      Serial.print("Status: ");
      Serial.println(msg);

      if (msg.indexOf("ON") != -1)
        digitalWrite(LED_PIN, HIGH);
      else if (msg.indexOf("OFF") != -1)
        digitalWrite(LED_PIN, LOW);
    }
  }
  
  if (!mqtt.ping()) mqtt.disconnect();  
}