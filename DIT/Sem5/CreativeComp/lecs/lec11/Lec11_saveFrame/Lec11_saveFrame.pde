void setup() {
  size(500,240);
  background(255);
}

void draw(){
  stroke(0);
  strokeWeight(4);
  if(mousePressed) {
    line(pmouseX,pmouseY,mouseX,mouseY);
  }
}

void mousePressed() {
  saveFrame("render/drawing####.png");
}
