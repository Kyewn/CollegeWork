//Question 1
void setup() {
  size(500,500);
}

void draw() {
  mydrawhut();
}

void mydrawhut() {
  final int size = 25;
  float posX, posY;
  posX = random(0, width-size);
  posY = random(0, height-size);
  fill(0);
  noStroke();
  //Draw huts
  rect(posX, posY, size, size);
}
