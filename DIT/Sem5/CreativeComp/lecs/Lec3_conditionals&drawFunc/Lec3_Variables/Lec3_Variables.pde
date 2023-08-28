//Declare variables
int cirX=75;
int cirY=75;
int cirBg = 255;
int cirH = 10;
int cirW = 10;

void setup(){
  size(500,480);
}
void draw(){
  background(255);
  stroke(0);
  fill(175);
  // use the declared variables
  ellipse(cirX, cirY, cirH, cirW);
  cirX+=1;
}
