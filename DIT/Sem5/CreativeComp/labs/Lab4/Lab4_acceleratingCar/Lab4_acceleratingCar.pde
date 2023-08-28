int x,y;
float speed;
void setup(){
size(600,600);
x=0;
y=300;
speed=0;
}
void draw(){
background(255,255,255);
drawmyCar(x);
x=int(x+speed);
if(x+100 >width)
noLoop();
if(x<width/2)
speed=speed+0.10;
else
speed =speed -0.10;
}

void drawmyCar(int x) {
//Draw the car body
fill(150,150,150);
rect(x, y-30,100,20);
quad(x+20,y-30,x+30,y-45,x+60,y-45,x+70,y-30);
fill(0,0,0);
ellipse(x+20,y-10,20,20);
ellipse(x+80,y-10,20,20);
}
