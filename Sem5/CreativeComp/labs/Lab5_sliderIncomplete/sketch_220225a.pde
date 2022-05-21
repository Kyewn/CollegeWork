final int arrSize = 6;
char charArr[] = {'A','B','C','D','E','F'};
PImage imgArr[] = new PImage[arrSize];

void setup() {
  size(700,700);
  background(0);
  noStroke();
  for (int i=0; i<arrSize; i++) {
    imgArr[i] = loadImage("data/p"+i+".jpg");
  }
}

void draw() {
  fill(255);
  textSize(24);
  textAlign(CENTER);
  text("Arr index: ", width/2, 100);
  text("Arr value: ", width/2, 200);
  
  drawSlider();
  imageMode(CENTER);
//  img(imgArr[i], width/2, 400);

}

void drawSlider() {
  int sliderCtnW = width/2;
  int sliderBtnW = 50;
  int sliderH = 20;
  
  float sliderX = width/2 - sliderCtnW/2;
  float sliderBtnX = sliderX;
  
  //slider
  rect(width/2 - sliderCtnW/2, 550, sliderCtnW, sliderH);
  if (mousePressed) {
      if (mouseX >= sliderX && mouseY >= 550 && mouseY <= 550+sliderH && mouseX <= sliderX + sliderCtnW) {
        if (!(mouseX > sliderBtnX+sliderBtnW)) {
          fill(255);
          rect(pmouseX, 550, sliderBtnW, sliderH);
          float newX = mouseX - sliderBtnW/2;   
          sliderBtnX = newX + sliderBtnW/2;  
          if (mouseX > sliderX+sliderBtnW/2 && mouseX < sliderX + sliderCtnW - sliderBtnW/2) {
            fill(0,0,255);
            rect(newX, 550, sliderBtnW, sliderH);                  
          } else {
            fill(0,0,255);
            rect(sliderBtnX, 550, sliderBtnW, sliderH);
          }
        } else {
            fill(0,0,255);
            rect(sliderBtnX, 550, sliderBtnW, sliderH);
        }
      } else {
          fill(0,0,255);
          rect(sliderBtnX, 550, sliderBtnW, sliderH);
      }
  } else {
    fill(0,0,255);
    rect(sliderBtnX, 550, sliderBtnW, sliderH);
  }
}
