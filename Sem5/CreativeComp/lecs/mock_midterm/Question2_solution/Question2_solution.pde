//Question 2
int i = 0;
void setup() {
  size(800,800);
  background(255);
}

void draw(){
  final int carAmount = 5;
  final int maxCarBodyW = 100;
  final int maxCarBodyH = 50;
  float posX, posY;
  int carBodyW, carBodyH;
  posX = random(0, width);
  posY = random(0, height);
  carBodyW = int(random(maxCarBodyW/2, maxCarBodyW));
  carBodyH = int(random(maxCarBodyH/2, maxCarBodyH));
  
  i++;
  if (i == carAmount) noLoop();
  drawVehicle(posX, posY, carBodyW, carBodyH);
}

void drawVehicle(float posX, float posY, int carBodyW, int carBodyH) {
  final int wheelW = carBodyW/5; 
  final int wheelH = 10;
  noStroke();
  //Car body
  fill(100);
  rect(posX, posY, carBodyW, carBodyH);
  //Car wheels
  stroke(255);
  fill(100);
  rect(posX+carBodyW/5,posY-wheelH/2, wheelW ,wheelH);
  rect(posX+2*carBodyW/3,posY-wheelH/2, wheelW ,wheelH);
  rect(posX+carBodyW/5,posY+carBodyH-wheelH/2, wheelW ,wheelH);
  rect(posX+2*carBodyW/3,posY+carBodyH-wheelH/2, wheelW ,wheelH);
  
}
