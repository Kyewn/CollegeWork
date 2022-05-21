// Random Variables//
// random()
float r;
float g;
float b;
float a;
float diameter;
float x;
float y;
void setup(){
size (500,480);
background(255);
}
void draw(){
r =random(255);
g=random(255);
b=random(255);
a=random(255);
diameter=random(20);
x=random(width);
y=random(height);
noStroke();
fill(r,g,b,a);
ellipse(x,y,diameter,diameter);
}
