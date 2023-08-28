#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <ArduinoJson.h>

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
      String weatherJSON = http.getString();
      StaticJsonDocument<1000> doc;
      DeserializationError err = deserializeJson(doc, weatherJSON);
      if (err) {
        Serial.print("ERROR: ");
        Serial.println(err.c_str());
        return;
      }
      const char* countryCode = doc["weatherObservation"]["countryCode"];
      const char* station = doc["weatherObservation"]["stationName"];
      const char* dateTime = doc["weatherObservation"]["datetime"];
      float temperature = doc["weatherObservation"]["temperature"];
      float humidity = doc["weatherObservation"]["humidity"];
      float lat = doc["weatherObservation"]["lat"];
      float lng = doc["weatherObservation"]["lng"];

      Serial.printf("Country code: %s\n", countryCode);
      Serial.printf("Station: %s\n", station);
      Serial.printf("Date & Time: %s\n", dateTime);
      Serial.printf("Temperature: %2f\n", temperature);
      Serial.printf("Humidity: %2f\n", humidity);
      Serial.printf("Station Latitude: %6f\n", lat);
      Serial.printf("Station Longitude: %6f\n", lng);
    }
    http.end(); //Close connection

    delay(60000);
}