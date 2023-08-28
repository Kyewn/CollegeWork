void setup() {
  size(700,500);
  fill(0);
}

void draw() {
  float midV = width/2;
  float midH = height/2;
  background(255);
  stroke(0);
  line(0, midH, width, midH);
  line(midV, 0, midV, height);
  noStroke();
  if(mouseX < midV && mouseY < midH) {
    rect(0, 0, midV, midH);
  } else if (mouseX > midV && mouseY < midH) {
    rect(midV, 0, midV, midH);
  } else if (mouseX < midV && mouseY > midH) {
    rect(0, midH, midV, midH);
  } else if (mouseX > midV && mouseY > midH) {
    rect(midV, midH, midV, midH);
  } else {}
}
