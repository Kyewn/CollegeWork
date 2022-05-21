//Infinite counter
int counter =0;

void setup(){
size(1000,500);
fill(255);
stroke(255);
}

void draw(){
background(0);
textSize(100);
textAlign(CENTER,CENTER);
text(counter,width/2,height/2);
//** Remove if statement and leave counter++ to run infinitely **
if (counter == 100)
  noLoop();
else 
  counter++;
}
