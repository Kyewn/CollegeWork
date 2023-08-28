float theta = 0;
float scaleFactor = 1;
float scaleDirection = 1;
PImage catImage;
void setup() {
  size(640, 480, P3D);
  catImage = loadImage("cat.jpg");
}
void draw() {
  translate(width/2, height/2);
  rotateZ(theta);
  rotateY(theta);
  scale(scaleFactor);
  imageMode(CENTER);
  image(catImage, 0, 0);
  theta += 0.1;
  scaleFactor += (0.01 * scaleDirection);
  if (scaleFactor < 0 || scaleFactor > 2) {
    scaleDirection = -scaleDirection;
  }
}