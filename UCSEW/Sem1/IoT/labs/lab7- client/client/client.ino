#include <ESP8266WiFi.h>

const char* SSID = "BLSB13714";
const char* PASSWORD = "PHWPQH6023";
long BR = 9600;

const char* host = "192.168.101.37";
const int port = 80;
bool state = false;

void setup() {
  Serial.begin(BR);
  delay(10);

  WiFi.mode(WIFI_STA);
  WiFi.begin(SSID, PASSWORD);
  while(WiFi.status() != WL_CONNECTED) {
    delay(500);
  }
  Serial.println("Client has connected to the network");
}

WiFiClient client;
void loop() {
  String request;
  if(!client.connect(host, port)) {
    Serial.println("Server not found.");
    return;
  }

  if (state == false) {
    request = "LED=ON";
    state = true;
  } else {
    request = "LED=OFF";
    state - false;
  }

  client.println(String("GET /") + request + " HTTP/1.1\n" +
                  "Host: " + host + "\r\n" +
                  "Connection: close\r\n\r\n");
  client.flush();
  delay(2000);                
}