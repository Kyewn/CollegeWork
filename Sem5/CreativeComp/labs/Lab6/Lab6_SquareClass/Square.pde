class Square {
  //fields or variables
  float x,y,edge, dX, dY;
  color col;

  //functions
  
  void setup()
  {
    edge =random(40,200);
    x=random(50,500-edge);
    y= random(50,500-edge);
    dX= random(3,10);
    dY = random(3,10);
    col = color(random(256),random(256), random(256));
  }
  void move()
  {
    x +=dX;
    if (x+edge>width || x<0)
    {
      dX = -dX;
    }
    y+=dY;
    if(y+edge > height|| y<0)
    {
      dY=-dY;
    }
  }
  void drawSquare() {
    fill(col);
    rect(x,y,edge,edge);
  }
}
