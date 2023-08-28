// PIMAGE 
// USE IMAGE TRICKS!

float stiffness = 0.1; 
float damping = 0.9; 
float velocity = 0.0; 
float targetY; 
float y; 
float force;

PImage img1;
PImage img2;

void setup() {
    size(600, 600);
    noStroke();
  img1 = loadImage("image1.jpg");
  img2 = loadImage("image2.jpg");
  
}
 
void draw() {
	background(0);
    force = stiffness * (targetY - y); 
    velocity = damping * (velocity + force); 
    y += velocity; 
  
  image(img1,0, 0, width, y); 
  
    image(img2,0, y, width , height-y); 
  
    targetY = mouseY; 
}