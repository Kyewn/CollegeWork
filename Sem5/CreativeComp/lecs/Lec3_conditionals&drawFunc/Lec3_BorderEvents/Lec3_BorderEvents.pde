// Controlling an object between the screen
// Coordinates.
int x=0;
int Sv=2;

void setup(){
size(480,480);
}

void draw(){
background(255);
//add the current moving speed
x = x + Sv; 

//if shape reaches window border
if(x > width || x < 0){
//Reverse(turn it around)
Sv = -Sv; 
}

stroke(0);
fill(175);
ellipse(x,100,40,40);
}
