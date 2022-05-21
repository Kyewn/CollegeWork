int xposArr[] = new int[10];
int yposArr[] = new int[10];

void setup() {
  size(500,500);
  for (int i = 0; i < xposArr.length; i++) {
    xposArr[i] = 0;
    yposArr[i] = 0;
  }
}  

void draw() {
  background(255);
  for (int i =0; i< xposArr.length-1; i++) {
    xposArr[i] = xposArr[i+1];
    yposArr[i] = yposArr[i+1];
  }
  
  xposArr[xposArr.length-1] = mouseX;
  yposArr[yposArr.length-1] = mouseY;  
  
   for (int i =0; i< xposArr.length; i++) {
     fill(200 - i*10);
     noStroke();
     ellipse(xposArr[i],yposArr[i], i,i);
  }
}
