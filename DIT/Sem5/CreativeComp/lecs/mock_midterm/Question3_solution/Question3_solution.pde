//Question 3
void setup() {
  size(500,500);
  background(255);
}

void draw() {
}

void mouseReleased() {
  int size = 20;
  drawBox(mouseX-size/2, mouseY-size/2, size);
}

void drawBox(float x, float y, int size){
  fill(100);
  stroke(0);
  rect(x,y, size, size);
}
