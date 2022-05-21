void setup() {
  size(500,500);
  stroke(0);
  background(255);
  fill(255,0,0);
}

void draw() {
  int r = 50;
  for (int i=10; i<height/2; i+=75) {
    for (int j=10;j<width;j+=55) {
      ellipse(j,i,r,r);
    }
  }
}
