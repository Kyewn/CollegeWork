final int velocity = 1;
int xOrigin = 0;
int yOrigin = 100;
void setup() {
  size(500,500);
  noStroke();
  ellipseMode(CORNER);
}

void draw() {
  background(255);
  fill(0);
  //front of car
  quad(xOrigin,yOrigin, xOrigin,yOrigin-20, xOrigin+120,yOrigin-20, xOrigin+120,yOrigin);
  // middle of car
  quad(xOrigin+20,yOrigin-20, xOrigin+30,yOrigin-30, xOrigin+30,yOrigin, xOrigin+20,yOrigin);
  //back of car
  rect(xOrigin+30,yOrigin-30, 50, 30);
  //wheels
  ellipse(xOrigin+20,yOrigin-10, 20,20);
  ellipse(xOrigin+50,yOrigin-10, 20,20);
  xOrigin+=velocity;
}
