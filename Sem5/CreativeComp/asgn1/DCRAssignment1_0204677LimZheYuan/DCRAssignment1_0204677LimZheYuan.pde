//--------CONSTANTS and VARIABLES---------
//Common configs
  //Snow quantity
final int snowQty = 30;
  //Car colours
final color carColors[] = {#e478f0, #614b10, #d6ca40, #d6843c, #596610, #105366 ,#10663e, #b01e28, #959ff0, #96248f};

//Background colors (green, dark blue)
        //start color = 164, 222, 217194, 220, 255
        //mid color = 35, 34, 87
        //end color = 75, 39, 105
final int start_bgR = 164; final int start_bgG = 222; final int start_bgB = 217;
final int mid_bgR = 35; final int mid_bgG = 34; final int mid_bgB = 87;
final int end_bgR = 75; final int end_bgG = 39; final int end_bgB = 105;
float bgR, bgG, bgB, bgR_night, bgG_night, bgB_night;
float opacity_start, opacity_end;

//Sun / moon
// sun color = 245, 245, 206
// moon color = 245, 245, 240
// flare color (fixed) = 255, 255, 235
final int sunR = 245; final int sunG = 245; final int sunB = 206 ;
final int moonR = 245; final int moonG = 245; final int moonB = 240;
final int flareR = 255; final int flareG = 255; final int flareB = 235;
final int coreSize = 190;
final int flareDistance = 45;
final int flareOpacity = 60;
// clouds
final int cloud1X = 100;
final int cloud2X = 65;
final int cloud2Y = 50;
final int cloud1W = 650;
final int cloud1H = 100;
final int cloud2W = 250;
final int cloud2H = 80;
final float maxTravelDis1 = 10;
final float maxTravelDis2 = 20;
float coreR, coreG, coreB;

//Snow effect
final int snowMaxSize = 12;
final float snowMaxFallSpeed = 1.5; //* snowSpeed > 1
final float snowMaxOffsetY = -800;
int snowSize[] = new int[snowQty];
float snowPosX[] = new float[snowQty];
float snowPosY[] = new float[snowQty];
float snowSpeed[] = new float[snowQty];

//Buildings
final int windowSize = 10;
final int windowSpacing = 10;
final float b1_startX = 0;
final float b2_startX = 120;
final float b3top_startX = 380;
final float b3bottom_startX = 240;
final float b4_startX = 410;

final float b1_endX = 100;
final float b2_endX = 220;
final float b3top_endX = 490;
final float b3bottom_endX = 406;
final float b4_endX = 800;
 
final float b1_startY = 290;
final float b2_startY = 200;
final float b3top_startY = 275;
final float b3bottom_startY = 350;
final float b4_startY = 350;

final float b3top_endY = 346;
final float base_endY = 540;
final float fore_endY = 550;
    
//Road
final int snowThickness  = 2;
final int topBorderSize  = 10;
final int btmBorderSize  = 20;
final int poleW = 10;
final int poleH = 15;
final float poleGap = 30; 
//Lamp post
final int postW = 5;
final int postH = -120;
final int handleW = 10;
final int handleH = 3;
final int bulbW = 15;
final int bulbH = 5;

//Cars
final int minCarW = 50; final int maxCarW = 70;
final int minCarH = 28; final int maxCarH = 35;
final float minOffsetX = -200;
final float maxOffsetX = -800;
final float maxCarSpeed = 2.5;
int carQty = 3;
color carColor[] = new color[carQty];
int carW[] = new int[carQty]; int carH[] = new int[carQty];
float carPosX[] = new float[carQty]; float carSpeed[] = new float[carQty];

//Lake
final int stoneW1_1 = 280;
final int stoneH1_1 = 100;
final int stoneW1_2 = 180;
final int stoneH1_2 = 40;
final int stoneW2_1 = 75;
final int stoneH2_1 = 35;
final int stoneW2_2 = 20;
final int stoneH2_2 = 15;
final int stoneW3 = 200;
final int stoneH3 = 90;
final int flatLandH = 32;
final int bushW1 = 350;
final int bushH1 = 240;
final int bushW2 = 200;
final int bushH2 = 140;
final int bushW3 = 120;
final int bushH3 = 60;
final int highlightSize = 2; 

void setup() {
  size(800,750);
  noStroke();
  //Snow arrays
  initializeFloatArr(snowPosX);
  initializeFloatArr(snowPosY);
  initializeFloatArr(snowSpeed);
  initializeIntArr(snowSize);
  //Car arrays
  initializeIntArr(carW);
  initializeIntArr(carH);
  initializeFloatArr(carPosX);
  initializeFloatArr(carSpeed);  
  for (int i=0;i < carQty; i++) {
    int randomColor = int(random(0, carColors.length));
    carColor[i] = carColors[randomColor];
  }
}

void draw() {
//Layer 1 - Changing background  
    fill(start_bgR,start_bgG, start_bgB);
    rect(0,0,width, height);
    opacity_start =  map(mouseX, 0, width/2, 0, 255);
    fill(mid_bgR, mid_bgG, mid_bgB, opacity_start);
    rect(0,0,width, height);
    opacity_end =  map(mouseX, width/2, width, 0, 255);
    fill(end_bgR, end_bgG, end_bgB, opacity_end);
    rect(0,0,width, height);

//Layer 2 - Sun/Moon/Cloud
  float core_posX, core_posY, flare_posX, flare_posY;  //XY Pos variables declared here because couldn't get width value in global context 
  int flareSize1 = coreSize + flareDistance;
  int flareSize2 = coreSize + 2*flareDistance;
  
  core_posX = width - width/5;
  core_posY = 100;
  flare_posX = core_posX;
  flare_posY = core_posY;
  //Draw flare
  fill(flareR, flareG, flareB, flareOpacity);
  ellipse(flare_posX, flare_posY, flareSize2, flareSize2);
  ellipse(flare_posX, flare_posY, flareSize1, flareSize1);
  //Draw core
  //coreR = sunR + mouseX * (moonR - sunR) / width;
  //coreG = sunG + mouseX * (moonG - sunG) / width;
  //coreB = sunB + mouseX * (moonB - sunB) / width;
  coreR = sunR + map(mouseX, 0, width, 0, moonR - sunR);
  coreG = sunG + map(mouseX, 0, width, 0, moonG - sunG);
  coreB = sunB + map(mouseX, 0, width, 0, moonB - sunB);
  fill(coreR, coreG, coreB);
  ellipse(flare_posX, flare_posY, coreSize, coreSize);
  
  //Clouds
  float whiteVal = map(mouseX, 0, width, 255, 210);
  float calc_cloud1X = map(mouseX, 0, width, cloud1X, cloud1X + maxTravelDis1);
  float calc_cloud2X = map(mouseX, 0, width, cloud2X, cloud2X + maxTravelDis2);
  fill(whiteVal,245);
  ellipse(calc_cloud1X, 0, cloud1W, cloud1H);
  ellipse(calc_cloud2X, cloud2Y, cloud2W, cloud2H);
    
//Layer 3 - Buildings
  drawBuildings(mouseX);

//Layer 4 - Road
  float roadY = height*2/3+13;
  float roadSurfaceY = roadY+snowThickness+topBorderSize+poleH;
  //Lamp post behind road
  drawPost(mouseX, roadSurfaceY);
  //Draw cars that can cover up lamp post
  drawCars(mouseX, roadSurfaceY);
  //Draw light ray that cover cars
  drawLightRay(mouseX, roadSurfaceY);
  
  //Thin layer of snow
  fill(255);
  rect(0, roadY, width, snowThickness);
  //Road border
  fill(0);
    //Top
  rect(0, roadY+snowThickness, width, topBorderSize);
    //Middle
  for (float x = 15; x<width; x+=poleW+poleGap) {
    rect(x, roadY+snowThickness+topBorderSize, poleW, poleH);
  }
    //Bottom
  rect(0, roadSurfaceY, width, btmBorderSize);
  
//Layer 5 - Lake
  float btmBorderY = roadSurfaceY+btmBorderSize;
  float lakeY = btmBorderY + 40; 

  //Lake
  fill(#c9f0ef, 150);
  rect(0, lakeY, width, height - lakeY);
  //Left stone
  fill(0);
  arc(0, lakeY, stoneW1_1, stoneH1_1, PI, TWO_PI);
  arc(120, lakeY, stoneW1_2, stoneH1_2, PI, TWO_PI);
  //Middle stone
  arc(width/2, lakeY, stoneW2_1, stoneH2_1, PI, TWO_PI);
  arc(width/2-60, lakeY+73, stoneW2_2, stoneH2_2, PI, TWO_PI);
  //Right stone
  arc(width, lakeY, stoneW3, stoneH3, PI, TWO_PI);
  
  //Stone shadow
  fill(80);
  //Left stone
  arc(0, lakeY, stoneW1_1, stoneH1_1, 0, PI);
  arc(120, lakeY, stoneW1_2, stoneH1_2, 0, PI);
  //Middle stone
  arc(width/2, lakeY, stoneW2_1, stoneH2_1, 0, PI);
  arc(width/2-60, lakeY+73, stoneW2_2, stoneH2_2, 0, PI);
  //Right stone
  arc(width, lakeY, stoneW3, stoneH3, 0, PI);
  
  //Land
  fill(#544c40);
  rect(0, height, width, -flatLandH);
  fill(200);
  arc(-10,height-25,300,30, PI, TWO_PI);
  arc(-20,height-25,200,60, PI, TWO_PI);
  fill(255);
  arc(130,height,250,50, PI, TWO_PI);
  arc(-30,height,350,80, PI, TWO_PI);
  
  //Highlights
  fill(255);
  ellipse(0, lakeY, stoneW1_1 + stoneW1_2, highlightSize);
  ellipse(width/2, lakeY, stoneW2_1+5, highlightSize);
  ellipse(width/2-60, lakeY+73, stoneW2_2+15, highlightSize);
  ellipse(width, lakeY, stoneW3+20, highlightSize);
  ellipse(175, lakeY+20, 220, highlightSize+2);
  ellipse(475, lakeY+70, 180, highlightSize+2);
  ellipse(width-105, height-120, 80, highlightSize+2);
  
  //Bush
  int berrySize = 20;
  fill(#022115);
  arc(width, height, bushW1, bushH1, PI, TWO_PI);
  arc(width-200, height, bushW2, bushH2, PI, TWO_PI);
  arc(width-300, height+10, bushW3, bushH3, PI, TWO_PI);
  //Berries
  fill(255);
  ellipse(width, height, berrySize, berrySize);
  ellipse(width-20, height-100, berrySize, berrySize);
  ellipse(width-60, height-40, berrySize, berrySize);
  ellipse(width-145, height-60, berrySize, berrySize);
  ellipse(width-200, height-20, berrySize, berrySize);
  ellipse(width-300, height-10, berrySize, berrySize);
  
//Layer 6 - Snowfall
  fill(255);
  for (int i=0; i<snowQty; i++) {
    ellipse(snowPosX[i], snowPosY[i], snowSize[i], snowSize[i]);
    //Set new snow position based on speed
    snowPosY[i] += snowSpeed[i];  
    //If go out of window height, loop again at different x position
    if (snowPosY[i] > height + snowSize[i]) {
        snowPosY[i] = -snowSize[i];
        snowPosX[i] = random(0,width);  
    }
  }
}

void initializeIntArr(int arr[]) {
  for (int i=0; i<arr.length; i++) {
    if (arr == snowSize)
      arr[i] = int(random(1,snowMaxSize));  
    else if (arr == carW)
      arr[i] = int(random(minCarW,maxCarW));
    else if (arr == carH)
      arr[i] = int(random(minCarH,maxCarH));
    else
      arr[i] = 0;
  }
} 

void initializeFloatArr(float arr[]) {
  for (int i=0; i<arr.length; i++) {  
     //Snowfall effect arrays
     if (arr == snowPosX)
        arr[i] = random(0, width);
     else if (arr == snowPosY) 
        arr[i] = random(snowMaxOffsetY, 0);
     else if (arr == snowSpeed) 
        arr[i] = random(1,snowMaxFallSpeed);
     // Car arrays
     else if (arr == carPosX)
       arr[i] = random(minOffsetX, maxOffsetX);
     else if (arr == carSpeed)
        arr[i] = random(1,maxCarSpeed);
     else
        arr[i] = 0;
  }
}

void drawBuildings(float mousex) {
   //Background layer
   //y-baseline: 600
      //Base layer - from left to right
      fill(0, 30);
      //1
      rect(30, 270, 86, 15);
      rect(105, 285, 11, 315);
      //2
      rect(224, 240, 12, 360);
      rect(236, 240, 140, 105);
      
      //Middle layer
      fill(0, 60);
      //1
      rect(0, 290, 100, 310);
      //2
      rect(120, 200, 100, 400);
      rect(160, 150, 3, 50);   
      //3
      fill(0, 60);
      rect(240, 350, 140, 250);
      rect(380, 275, 110, 71);
      rect(380, 346 , 26, 254);
    
   //Foreground layer
      fill(0,90);
      //Body
      rect(410, 350, 390, 250);
      //Tubes
      rect(520, 300, 100, 50);
      rect(640, 325, 50, 25);
      rect(730, 250, 50, 100);
    //--------------------------
   //Windows + cycle effect (buildings go left to right)
    int counterX=0, counterY=0;
    float dlCyclePerc = mousex / width; 
    
    fill(#fff5d6, 70); //window color
    //1st building
    for (float y=b1_startY+windowSpacing; y<base_endY-50; y+=windowSize+windowSpacing) {
      for (float x=b1_startX+10; x<b1_endX-windowSpacing; x+=windowSize+windowSpacing) {
          fill(#fff5d6, 70);
          rect(x,y,windowSize,windowSize);
            if (dlCyclePerc > 0.2 && dlCyclePerc < 0.8) {
              if ((counterY == 0 && counterX == 2) ||
                (counterY == 1 && counterX == 0) ||
                (counterY == 3 && (counterX == 2 || counterX == 3)) ||
                (counterY == 5 && counterX == 1) ||
                (counterY == 6 && (counterX == 0)) ||
                (counterY == 7 && counterX == 2)){
                fill(#fff5d6,200);
                rect(x,y,windowSize,windowSize);           
              }
            }
            if (dlCyclePerc > 0.4 && dlCyclePerc < 0.7) {
              if ((counterY == 1 && counterX == 3) ||
                (counterY == 2 && (counterX == 1 || counterX == 2)) ||
                (counterY == 4 && (counterX == 0 || counterX == 3)) ||
                (counterY == 5 && counterX == 3) ||
                (counterY == 8 && (counterX == 0 || counterX == 2))) {
                fill(#fff5d6,200);
                rect(x,y,windowSize,windowSize);           
              }
            }
            if (dlCyclePerc > 0.8) {
              if ((counterY == 3 && counterX == 2) ||
              (counterY == 5 && counterX == 1)){
                fill(#fff5d6,200);
                rect(x,y,windowSize,windowSize);
              }  
            }
        counterX++;
      }
      counterY++;
      counterX = 0;
    }
    counterX=0; counterY=0;
    //2nd building
    for (float y=b2_startY+windowSpacing; y<base_endY-100; y+=windowSize+windowSpacing) {
      for (float x=b2_startX+15; x<b2_endX-windowSpacing; x+=windowSize+windowSpacing) {
        fill(#fff5d6, 70);
        rect(x,y,windowSize,windowSize);
          if (dlCyclePerc > 0.2 && dlCyclePerc < 0.8) {
            if ((counterY == 1 && counterX == 2) ||
              (counterY == 3 && counterX == 0) ||
              (counterY == 5 && counterX == 1) ||
              (counterY == 6 && (counterX == 3)) ||
              (counterY == 7 && counterX == 2)){
              fill(#fff5d6,200);
              rect(x,y,windowSize,windowSize);           
            }
          }
          if (dlCyclePerc > 0.4 && dlCyclePerc < 0.7) {
            if ((counterY == 0 && counterX == 2) || 
              (counterY == 1 && (counterX == 0 || counterX == 1)) ||
              (counterY == 2 && counterX == 1) ||
              (counterY == 3 && counterX == 3) ||
              (counterY == 4 && (counterX == 1 || counterX == 3)) ||
              (counterY == 5 && (counterX == 2 || counterX == 3)) ||
              (counterY == 6 && (counterX == 0)) ||
              (counterY == 7 && counterX == 1) ||
              (counterY == 8 && counterX == 2)) {
              fill(#fff5d6,200);
              rect(x,y,windowSize,windowSize);           
            }
          }
          if (dlCyclePerc > 0.8 && counterY == 3 && counterX == 0){
              fill(#fff5d6,200);
              rect(x,y,windowSize,windowSize);
          }
        counterX++;
      }
      counterY++;
      counterX = 0;
    }
    counterX=0; counterY=0;
    //3rd building -top
    for (float y=b3top_startY+windowSpacing; y<b3top_endY-windowSpacing; y+=windowSize+windowSpacing) {
      for (float x=b3top_startX+10; x<b3top_endX; x+=windowSize+windowSpacing) {
        fill(#fff5d6, 70);
        rect(x,y,windowSize,windowSize);
          if (dlCyclePerc > 0.2 && dlCyclePerc < 0.8) {
            if ((counterY == 0 && counterX < 2) ||
              (counterY == 1 && counterX == 3) ||
              (counterY == 2 && (counterX == 1 || counterX == 4))){
              fill(#fff5d6,200);
              rect(x,y,windowSize,windowSize);           
            }
          }
          if (dlCyclePerc > 0.4 && dlCyclePerc < 0.7) {
            if ((counterY == 0 && counterX == 2) || 
              (counterY == 1 && counterX == 0) ||
              (counterY == 2 && counterX == 2)) {
              fill(#fff5d6,200);
              rect(x,y,windowSize,windowSize);           
            }
          }
          if (dlCyclePerc > 0.8) {
            if ((counterY == 0 && counterX == 0) ||
              (counterY == 2 && counterX == 1)) {
              fill(#fff5d6,200);
              rect(x,y,windowSize,windowSize);
            }
          }
        counterX++;
      }
      counterY++;
      counterX = 0;
    }
    counterX=0; counterY=0;
    //3rd building -bottom
    for (float y=b3bottom_startY+30; y<base_endY-20; y+=windowSize+5+windowSpacing) {
      for (float x=b3bottom_startX+15; x<b3bottom_endX; x+=windowSize+12+windowSpacing) {
        fill(#fff5d6, 70);
        rect(x,y,windowSize+12,windowSize+5);
          if (dlCyclePerc > 0.2 && dlCyclePerc < 0.8) {
            if ((counterY == 1 && counterX == 1) ||
              (counterY == 2 && (counterX == 0 || counterX == 4))) {
              fill(#fff5d6,200);
              rect(x,y,windowSize+12,windowSize+5);         
            }
          }
          if (dlCyclePerc > 0.4 && dlCyclePerc < 0.7) {
            if ((counterY == 0 && (counterX == 0 || counterX == 3)) ||
              (counterY == 1 && counterX == 1) ||
              (counterY == 2 && (counterX == 0 || counterX == 4)) ||
              (counterY == 3 && counterX == 2)) {
              fill(#fff5d6,200);
              rect(x,y,windowSize+12,windowSize+5);         
            }
          }
        counterX++;
      }
      counterY++;
      counterX = 0;
    }
    counterX=0; counterY=0;
    //4th building
    for (float y=b4_startY+80; y<fore_endY-20; y+=windowSize+5+windowSpacing) {
      for (float x=b4_startX+20; x<b4_endX; x+=windowSize+20+windowSpacing) {
        fill(#fff5d6, 70);
        rect(x,y,windowSize+20,windowSize+5);
          if (dlCyclePerc > 0.2 && dlCyclePerc < 0.8) {
            if ((counterY == 0 && (counterX == 1 || counterX == 3 || counterX == 4 || counterX == 7 || counterX == 9)) ||
              (counterY == 1 && (counterX == 2 || counterX == 5)) ||
              (counterY == 2 && (counterX == 0 || counterX == 2)) ||
              (counterY == 3 && (counterX == 6 || counterX == 8))) {
              fill(#fff5d6,200);
              rect(x,y,windowSize+20,windowSize+5);       
            }
          }
          if (dlCyclePerc > 0.4 && dlCyclePerc < 0.7) {
            if ((counterY == 1 && (counterX == 0 || counterX == 7 || counterX == 8)) ||
              (counterY == 2 && (counterX == 4 || counterX == 6)) ||
              (counterY == 3 && (counterX == 1 || counterX == 3))) {
              fill(#fff5d6,200);
              rect(x,y,windowSize+20,windowSize+5);        
            }
          }
          if (dlCyclePerc > 0.8) {
            if ((counterY == 1 && (counterX == 2 || counterX == 5)) ||
              (counterY == 2 && counterX == 0)) {
              fill(#fff5d6,200);
              rect(x,y,windowSize+20,windowSize+5);
            }
          }
        counterX++;
      }
      counterY++;
      counterX = 0;
    }
}

void drawPost(float mousex, float surfaceY) {
  final float postX = width/2-200;
  final float bulbX = postX + postW + handleW;
  final float bulbY = surfaceY + postH + 8;
  fill(0);
  //Lamp post
  rect(postX, surfaceY, postW, postH);
  //Horizontal handle
  rect(postX, surfaceY + postH + 10, postW+handleW, handleH);
  //Bulb
  if (mousex/width > 0.4)
    fill(#fff5d6);
  else 
    fill(#c9c5b5);
  rect(bulbX, bulbY, bulbW, bulbH+5);
  fill(0);
  rect(bulbX, bulbY, bulbW, bulbH);
}

void drawCars(float mousex, float surfaceY) {
  for (int i=0; i<carQty; i++) {
      //Car
      fill(carColor[i]);
      rect(carPosX[i], surfaceY, carW[i], -carH[i]);
      //Car lights
      fill(#c9c5b5,200);
      rect(carPosX[i]+carW[i], surfaceY-5, -10, -5);
      //Car lightrays - only on at night
      if (mousex/width > 0.4) {
        fill(#fff5d6);
        rect(carPosX[i]+carW[i], surfaceY-5, -10, -5);
        fill(#fff5d6, 130);
        quad(carPosX[i]+carW[i], surfaceY-5, carPosX[i]+carW[i]+30, surfaceY, carPosX[i]+carW[i]+30, surfaceY-20, carPosX[i]+carW[i], surfaceY-10);
      }
      //Move car by car speed
      carPosX[i] += carSpeed[i];
      //Loop car with other attributes when reached end of window
      if (carPosX[i] > width) {
          int randomColor = int(random(0, carColors.length));
          carPosX[i] = random(minOffsetX, maxOffsetX);
          carColor[i] = carColors[randomColor];
          carW[i] = int(random(minCarW,maxCarW));
          carH[i] = int(random(minCarH,maxCarH));
          carSpeed[i] = random(1,maxCarSpeed);
      }
  }
}

void drawLightRay(float mousex, float surfaceY) {
  final float postX = width/2-200;
  final float bulbX = postX + postW + handleW;
  final float bulbY = surfaceY + postH + 8;
  if (mousex/width > 0.4) {
    fill(#fff5d6, 130);
    quad(bulbX, bulbY+bulbH+5, bulbX-10, bulbY+bulbH+115, bulbX+bulbW+15, bulbY+bulbH+115, bulbX+bulbW, bulbY+bulbH+5);      
  }
}  
