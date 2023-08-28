PImage myImage;
void setup() {
  size(632,475);
  myImage = loadImage("cat.jpg");
}
void draw() {
  myImage.loadPixels(); // Get ready!
  for (int i = 0; i < myImage.pixels.length; i++) {
   myImage.pixels[i] += random(-800,800);
  }
  myImage.updatePixels(); // Change!
  image(myImage,0,0);
}