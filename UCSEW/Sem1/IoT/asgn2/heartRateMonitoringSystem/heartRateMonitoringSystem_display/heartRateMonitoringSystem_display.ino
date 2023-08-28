// WiFi
#include <ESP8266WiFi.h>
// I2C
#include <Wire.h>
// Display
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>
// OLED settings
#define SCREEN_WIDTH 128
#define SCREEN_HEIGHT 32
#define OLED_RESET -1 // Share with Arduino Reset pin
Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);

// Base vars
const int BR = 9600;
const int PORT = 81;
const char* SSID = "BLSB13714";
const char* PASSWORD = "PHWPQH6023";

// Settings and object constructor
WiFiServer server(PORT);

void setup()
{
  Serial.begin(BR);

  if (!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) {
    Serial.println(F("Could not detect OLED. Please reset the controller!"));
    for(;;); // Loop forever, block code
  }  
  WiFi.begin(SSID, PASSWORD);

  // Initialize WiFi server
  while(WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(500);
  }
  Serial.println("Controller has connected to the WiFi.");

  server.begin();
  Serial.println("Server has been initialized at port 81.");
  Serial.print("URL: http://");
  Serial.print(WiFi.localIP());
  Serial.println(":81/");

  // Init display
  display.clearDisplay();
  display.setTextSize(2);
  display.setTextColor(WHITE);
  display.setCursor(0,0); // Set origin to top left
  display.cp437(true); // Enable Code Page 437 (Combination of UTF8 and ASCII) font.
  display.display();
}

void loop()
{
  WiFiClient client = server.available();
  if (!client) return;  // Don't do anything if no one is at the URL

  while(!client.available()) delay(1);// Block loop if client hasn't receive data yet

  String req = client.readStringUntil('\r');

  Serial.println(req);
  client.flush();

  if (req.indexOf("/BPM=") != -1) {
    String strBeatsPerMinute = req.substring(req.indexOf("BPM=") + 4, req.indexOf("&"));
    char bpmArray[strBeatsPerMinute.length() + 1];
    strBeatsPerMinute.toCharArray(bpmArray, sizeof(bpmArray));
    float beatsPerMinute = atof(bpmArray);

    String strBeatAvg =  req.substring(req.indexOf("AVG=") + 4, req.indexOf("#"));
    char avgArray[strBeatAvg.length() + 1];
    strBeatAvg.toCharArray(avgArray, sizeof(avgArray));
    float beatAvg = atof(avgArray);

    display.clearDisplay();
    display.setTextSize(2);
    display.setTextColor(WHITE);
    display.setCursor(0,0); // Set origin to top left
    display.cp437(true); // Enable Code Page 437 (Combination of UTF8 and ASCII) font.
      display.println("Last BPM:");
      display.println(beatsPerMinute);
    display.display();
    delay(3000);

    display.clearDisplay();
    display.setTextSize(2);
    display.setTextColor(WHITE);
    display.setCursor(0,0); // Set origin to top left
    display.cp437(true); // Enable Code Page 437 (Combination of UTF8 and ASCII) font.
      display.println("Average");
      display.println("BPM: " + String(beatAvg));
    display.display();
    delay(3000);
  } else if (req.indexOf("/OLED=NO") != -1) {
    display.clearDisplay();
    display.display();
  } else if (req.indexOf("/READING") != -1) {
    display.clearDisplay();
    display.setTextSize(2);
    display.setTextColor(WHITE);
    display.setCursor(0,0); // Set origin to top left
    display.cp437(true); // Enable Code Page 437 (Combination of UTF8 and ASCII) font.
      display.print("Reading...");
    display.display();
    delay(750);
  } else {
    //  Render title text
    display.clearDisplay();
    display.setTextSize(2);
    display.setTextColor(WHITE);
    display.setCursor(0,0); // Set origin to top left
    display.cp437(true); // Enable Code Page 437 (Combination of UTF8 and ASCII) font.
      display.print("Heartbeat");
    display.display();

    delay(2000);

    display.clearDisplay();
    display.setTextSize(2);
    display.setTextColor(WHITE);
    display.setCursor(0,0); // Set origin to top left
    display.cp437(true); // Enable Code Page 437 (Combination of UTF8 and ASCII) font.
      display.print("Monitoring");
    display.display();

    delay(2000);

    display.clearDisplay();
    display.setTextSize(2);
    display.setTextColor(WHITE);
    display.setCursor(0,0); // Set origin to top left
    display.cp437(true); // Enable Code Page 437 (Combination of UTF8 and ASCII) font.
      display.print("System");
    display.display();
    
    delay(4000);
  }
}


