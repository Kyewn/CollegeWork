#include "DHT.h"
#include <Wire.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

// Humid. sensor settings
#define dhtPin D6
#define DHTYPE DHT22

DHT dht(dhtPin, DHTYPE);

long BR = 9600;

// OLED sensor settings
#define SCREEN_WIDTH 128
#define SCREEN_HEIGHT 32
#define OLED_RESET -1 // Share with Arduino Reset pin
Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);

void setup() {
  Serial.begin(BR);
  Serial.setTimeout(2000);
  while(!Serial);
  dht.begin();
  Serial.println("DHT sensor has started.");

  if (!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) {
    Serial.println(F("Could not detect OLED."));
    for(;;); // Loop forever, block code
  }

  // Render initial text on OLED
  display.clearDisplay();
  display.setTextSize(2);
  display.setTextColor(WHITE);
  display.setCursor(0,0); // Set origin to top left
  display.cp437(true); // Enable Code Page 437 (Combination of UTF8 and ASCII) font.
  display.display();
  delay(1000);
}

void loop() {
  float h = dht.readHumidity();
  float tempCel = dht.readTemperature();
  float tempFah = dht.readTemperature(true);

  if (isnan(h) || isnan(tempCel) || isnan(tempFah)) {
    Serial.println("Failed to retrieve from DHT sensor.");
    return;
  }

  float hic = dht.computeHeatIndex(tempCel, h, false);
  float hif = dht.computeHeatIndex(tempFah, h);
  
  // Serial.print("Humidity: ");
  // Serial.print(h);
  // Serial.println("%");

  // Serial.print("Temperature (C): ");
  // Serial.print(tempCel);
  // Serial.println("'C");
  
  // Serial.print("Temperature(F): ");
  // Serial.print(tempFah);
  // Serial.println("'F");

  display.clearDisplay();
  display.setTextSize(2);
  display.setTextColor(WHITE);
  display.setCursor(0,0); // Set origin to top left
  delay(1);
  display.cp437(true); // Enable Code Page 437 (Combination of UTF8 and ASCII) font.
    display.print("Humidity\n");
    display.print(h);
    display.print("%");
  display.display();
  delay(2000);

  display.clearDisplay();
  display.setTextSize(2);
  display.setTextColor(WHITE);
  display.setCursor(0,0); // Set origin to top left
  delay(1);
  display.cp437(true); // Enable Code Page 437 (Combination of UTF8 and ASCII) font.
    display.print("Heat\n");
    display.print(hic);
    display.write(248); // Degree circle in extended ASCII
    display.print("C");
  display.display();
  delay(2000);
  }