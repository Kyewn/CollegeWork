PVector v1 = new PVector(1,1);
PVector v2 = new PVector(20,13);

void setup() {
size(500,500);
background(255);
noStroke();
}

void draw(){
}

void mousePressed(){
  float r = random(0, 255);
  float g = random(0, 255);
  float b = random(0, 255);
  color col = color(r,g,b);
 
  myFlower(mouseX, mouseY, int(random(10,45)), col);
  PVector v3 = v1.add(v2);
  println(v3.x, v3.y);
}

void myFlower(int x, int y, int s, color col){
int n=9;
float angle =2*PI/n;
for(int i=0; i<n;i++){
fill(col, 50);
ellipse(x+s*cos(angle*i),y+s*sin(angle*i),s,s);
}
}
