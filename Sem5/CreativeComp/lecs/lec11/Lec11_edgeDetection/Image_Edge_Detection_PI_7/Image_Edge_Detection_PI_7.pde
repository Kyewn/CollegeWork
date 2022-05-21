PImage source;
PImage dest;
void setup() {
  size(632, 475);
  source = loadImage("cat.jpg");
  dest = createImage(source.width,source.height,RGB);
}
void draw() {
  dest.loadPixels();
  for (int x = 0; x < source.width; x++) {
    for (int y = 0; y < source.height; y++) {
      int loc = x + y*width;
      if (loc < dest.pixels.length - 1) {
        dest.pixels[loc] = source.pixels[loc] + source.pixels[loc + 1];
      }
    }
  }
  dest.updatePixels(); // If we changed the pixels array we need to update it
  image(dest,0,0);
}