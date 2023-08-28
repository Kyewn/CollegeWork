const int PIEZO_PIN = A0;
const int threshold = 100;
int sensorRead = 0;

const int LED_PIN = D5;
bool LED_STATUS = false;

void setup() {
  pinMode(LED_PIN, OUTPUT);
  digitalWrite(LED_PIN, LOW);

  Serial.begin(9600);
}

void loop() {
  sensorRead = analogRead(PIEZO_PIN);
  if (sensorRead > threshold) {
    Serial.println("Pressure detected.");
    if(!LED_STATUS) {
      digitalWrite(LED_PIN, HIGH);
      LED_STATUS = true;
    } else {
      digitalWrite(LED_PIN, LOW);
      LED_STATUS = false;
    }
  }
}