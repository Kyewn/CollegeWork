//Generate rows of squares based on mouseX
void setup(){
  size(640,480);
}
void draw(){
int currenloc=0;

//loop while it is within xPos range
while(currenloc<mouseX){
  rect(currenloc,mouseY,10,10);
  currenloc+=20;
}

}
