PImage p;
void setup()
{
  size(500,500);
  background(200,200,0);
  p=loadImage("cat.jpg");
  image(p,20,20);
  
  println(p.width);
  println(p.height);
  p.loadPixels();
  //p.updatePixels();
  println(p.pixels.length);
  println(p.pixels[0]);
  println(hex(p.pixels[0]));
}

void draw()
{
  image(p,0,0);
}
void mousePressed()
{
  p.loadPixels();
  int index= (mouseY *p.width) + mouseX;
   p.pixels[index] =color(255,0,0);
   p.pixels[index+1]=color(255,0,0);
   p.pixels[index+p.width] = color(255,0,0); 
   p.pixels[index+p.width+1]=color(255,0,0);
   p.updatePixels();
}
