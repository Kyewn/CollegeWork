PImage p1,p2, p3;


int sliderX, sliderY, sliderWidth, sliderHeight;
int grayValue;

void setup( )
{
   size( 800, 400 );
 
   p1 = loadImage( "cat.jpg");
   p2 = loadImage( "cat2.jpg");
   p3 = loadImage( "cat3.jpg"); 
   textSize( 20 );
   textAlign(CENTER, CENTER);

   sliderX = 20;
   sliderY = height-50;
   sliderWidth = width - sliderX*2;
   sliderHeight = 20;
   
   grayValue = 255;
   
}

void draw( )
{
    background( 255 );

    modifyAndShowImage( );
    drawSlider( );

    //noLoop( );
}

void modifyAndShowImage( )
{
    p1.loadPixels( );
    
    for( int i = 0; i < p1.pixels.length; i++)
    {
       color c = p1.pixels[i] ;
       float r = red( c );
       float b = blue( c );
       float g = green( c );
       float sum = r + b + g;
       float average = sum/3;
       if (average > grayValue )
       {
           c = color( 0 );
           p3.pixels[i] = p2.pixels[i];
       }
       else
       {
           p3.pixels[i] = p1.pixels[i];
       }
     
       
    }
     p3.updatePixels( );
    image( p3, 400, 10, 300, 300);
}


void drawSlider( )
{
   fill( grayValue );
   // Container
   rectMode(CORNER);
   rect( sliderX, sliderY, sliderWidth, sliderHeight); 
   // Button
   int barX = int( map( grayValue, 0, 255, sliderX, sliderX+sliderWidth) );
   rectMode(CENTER);
   fill(255,0,0);
   rect( barX, sliderY+sliderHeight/2, 10, sliderHeight +20 );
   // Text value
   fill( 0 );
   text( grayValue, width/2, sliderY - 25 );
}
void mouseDragged( )
{
   grayValue = int( map( mouseX, sliderX, sliderX + sliderWidth, 0, 255 ) );
   grayValue = constrain(grayValue, 0, 255 );
}
