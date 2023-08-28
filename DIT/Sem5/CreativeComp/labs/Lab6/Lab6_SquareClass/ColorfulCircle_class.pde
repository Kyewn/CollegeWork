class ColorCircle {
   //fields or variables
    float x,y,size, dX, dY;
    color col;
  
  //functions
  
  void setup()
  {
    size =random(40,200);
    x=random(size/2,500-size/2);
    y= random(size/2,500-size/2);
    dX= random(3,10);
    dY = random(3,10);
    col = color(random(256),random(256), random(256));
  }
  void move()
  {
    x +=dX;
    if (x+size/2>width || x<size/2)
    {
      dX = -dX;
    }
    y+=dY;
    if(y+size/2 > height|| y<size/2)
    {
      dY=-dY;
    }
  }
  void drawCircle() {
    fill(col);
    ellipse(x,y,size,size);
}
}
