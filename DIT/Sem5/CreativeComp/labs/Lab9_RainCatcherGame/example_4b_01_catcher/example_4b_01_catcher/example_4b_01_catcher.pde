//Week4b

// Main file Catcher

Catcher catcher;

void setup() {
  size(640, 360);
  catcher = new Catcher(32);
}

void draw() {
  background(255);
  catcher.setLocation(mouseX, mouseY);
  catcher.display();
}

