float x ,y, speed, accel;

void setup() {
  size(600, 600);
  x = 0;
  y = 300;
  speed = 0;
  accel = 0.9;
}

void draw() {
  background(255);
  myCar();
  x += speed;
  speed += accel;
  if (x<0) {
    x=0;
    speed = 0;
  } else if (x+100 > width) {
    x=width-100;
    speed = 0;  
  }
}

void mousePressed() {
  accel = accel * -1;
}

void myCar() {
  fill(150,150,150);
  rect(x, y-30,100,20);
  quad(x+20,y-30,x+30,y-45,x+60,y-45,x+70,y-30);
  fill(0,0,0);
  ellipse(x+20,y-10,20,20);
  ellipse(x+80,y-10,20,20);
}
