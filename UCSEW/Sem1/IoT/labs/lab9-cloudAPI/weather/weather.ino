#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>

const char* ssid = "UOW Malaysia KDU";
const char* password = "kdu@batu-kawan";

void setup() {
    Serial.begin(9600);
    WiFi.begin(ssid, password);
    while(WiFi.status() != WL_CONNECTED) delay(500);
    Serial.println("WiFi connected");
}

HTTPClient http;
void loop() {
    http.begin("http://api.geonames.org/findNearByWeatherJSON?lat=5.41960&lng=100.32245&username=kyoowu"); //Open connection

    int httpCode = http.GET();
        Serial.printf("Status code: %d\n", httpCode);

    if (httpCode == 200) {
        Serial.printf("JSON: %s\n", http.getString().c_str());
    }
    http.end(); //Close connection

    delay(60000);
}