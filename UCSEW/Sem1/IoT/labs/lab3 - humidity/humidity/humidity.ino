#include "DHT.h"

#define dhtPin D6
#define DHTYPE DHT22

DHT dht(dhtPin, DHTYPE);

long BR = 9600;

void setup() {
  Serial.begin(BR);
  Serial.setTimeout(2000);
  while(!Serial);
  dht.begin();
  Serial.println("Dvice has started.");
}

void loop() {
  float h = dht.readHumidity();
  float tempCel = dht.readTemperature();
  float tempFah = dht.readTemperature(true);
  if (isnan(h) || isnan(tempCel) || isnan(tempFah)) {
    Serial.println("Failed to retrieve from DHT sensor.");
    return;
  }
  Serial.print("Humidity: ");
  Serial.print(h);
  Serial.println("%");

  Serial.print("Temperature (C): ");
  Serial.print(tempCel);
  Serial.println("'C");
  
  Serial.print("Temperature(F): ");
  Serial.print(tempFah);
  Serial.println("'F");

  delay(10000);
  }