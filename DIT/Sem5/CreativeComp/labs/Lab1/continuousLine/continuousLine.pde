//Continuously Draw Lines
void setup() {
  size(480,270);
  background(255);
  stroke(0);
}

void draw() {
  line(pmouseX,pmouseY,mouseX,mouseY);
}
