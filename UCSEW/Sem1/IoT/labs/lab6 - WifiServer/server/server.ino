#include <ESP8266WiFi.h>

long BR = 9600;
const char* SSID = "BLSB13714";
const char* PASSWORD = "PHWPQH6023";
const int LED_PIN = D5;
int ledState = LOW; 

WiFiServer server(80);

void setup() {
  pinMode(LED_PIN, OUTPUT);
  digitalWrite(LED_PIN, LOW);

  Serial.begin(BR);
  WiFi.begin(SSID, PASSWORD);
  
  // WiFi.status() != 3
  while(WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("Controller has connected to WLAN.");
  server.begin();
  Serial.println("Server started at port 80.");

  Serial.print("URL = http://");
  Serial.print(WiFi.localIP());
  Serial.println("/");
}

void loop() {
  // Check server availability
  WiFiClient client = server.available();
  if(!client) return;
  
  // Wait until client send data
  while(!client.available()) delay(1);
  
  String req = client.readStringUntil('\r');
  Serial.println(req);

  // Remove printed data;
  client.flush();

  // Check req
  if (req.indexOf("/LED=ON") != -1) {
    digitalWrite(LED_PIN, HIGH);
    ledState = HIGH;
  }
  if (req.indexOf("/LED=OFF") != -1) {
    digitalWrite(LED_PIN, LOW);
    ledState = LOW;
  }
  client.println("HTTP/1.1 200 OK");
  client.println("Content-Type: text/html");
  client.println("");

  String html = "<html>\n<head>\n<meta charset='utf-8'/>\n<title>ESP8266 Landing Page</title>\n</head>\n<body>\n<p>Welcome to ESP8266</p>\nLED status: ";
  client.println(html);
  if (ledState == HIGH) {
    client.println("ON<br/><br/>");
  } else {
    client.println("OFF<br/><br/>");
  }

  String html2 = "<a href='/LED=ON/'><button>TURN ON</button></a>\n<a href='/LED=OFF/'><button>TURN OFF</button></a>\n</body>\n</html>";
  client.println(html2);
  delay(1);
}