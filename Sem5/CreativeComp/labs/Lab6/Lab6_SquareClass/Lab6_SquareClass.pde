int noOfSquares = 10;
int noOfCircles = 5;
Square[] sqArr = new Square[noOfSquares];
Circle[] cirArr = new Circle[noOfCircles];
ColorCircle[] clrCirArr = new ColorCircle[noOfCircles];

void setup() {
  size(500,500);
  for (int i=0; i< noOfSquares; i++) {
    sqArr[i] = new Square();
    sqArr[i].setup();
  }
  for (int i=0; i< noOfCircles; i++) {
    cirArr[i] = new Circle();
    cirArr[i].setup();
  }
  for (int i=0; i< noOfCircles; i++) {
    clrCirArr[i] = new ColorCircle();
    clrCirArr[i].setup();
  }
  background(0);
}

void draw() {
  for (int i=0; i< noOfSquares; i++) {
    sqArr[i].move();
    sqArr[i].drawSquare();
  }
  for (int i=0; i< noOfCircles; i++) {
    cirArr[i].move();
    cirArr[i].drawCircle();
  }  
  for (int i=0; i< noOfCircles; i++) {
    clrCirArr[i].move();
    clrCirArr[i].drawCircle();
  }
  if (keyPressed) background(0);
}

void keyPressed() {
  Square[] nsqArr = new Square[noOfSquares];
  Circle[] ncirArr = new Circle[noOfCircles];
  ColorCircle[] nclrCirArr = new ColorCircle[noOfCircles];
    for (int i=0; i< noOfSquares; i++) {
      nsqArr[i] = new Square();
      nsqArr[i].setup();
      sqArr[i] = nsqArr[i];
    }
    for (int i=0; i< noOfCircles; i++) {
      ncirArr[i] = new Circle();
      ncirArr[i].setup();
      cirArr[i] = ncirArr[i];
    }
    for (int i=0; i< noOfCircles; i++) {
      nclrCirArr[i] = new ColorCircle();
      nclrCirArr[i].setup();
      clrCirArr[i] = nclrCirArr[i];
    }
  
}
