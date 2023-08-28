class Circle {
   //fields or variables
    float x,y,size, dX, dY;
  
  //functions
  
  void setup()
  {
    size =random(40,200);
    x=random(size/2,500-size/2);
    y= random(size/2,500-size/2);
    dX= random(3,10);
    dY = random(3,10);
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
    fill(255);
    ellipse(x,y,size,size);
}
}
