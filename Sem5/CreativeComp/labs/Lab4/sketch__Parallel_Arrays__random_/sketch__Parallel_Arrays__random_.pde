
//  Advantages of Using Arrays

// change this number to change the number of squares.
final int MAX = 1;

/*
  This code does not use the iniitilizer list.  
  It uses the new opertor which allocates memory for the array.
  Each element is set to zero for the ints and to a special 
  value called null for the color. 
  
  For loops are used to traverse the arrays and assign
  randomly generate values.
  
  There are five arrays in this code.
  In all five arrays the [zero]th element is used
  to specify the zeroth rectangle:
     its x and y value
     its edge length
     its deltaX and deltaY values
     its color
     
  When arrays are used like this, they are called 
  parallel arrays.
*/

int [ ] x, y, edge, dX, dY;
color[ ] col;

void setup( )
{
  size( 600, 500 );
  
  x = initInt( 0, width );
  y = initInt( 0, height );
  edge = initInt( 5, 25 );
  dX = initInt( 2, 15 );
  dY = initInt( 2, 15 );
  
  col= initCol( );
}

void draw( )
{
   fill( 255, 10 );
   rect( 0, 0, width, height );
   drawRects( );
   moveRects( );
   
   println(frameRate);
}

void moveRects( )
{
     for ( int i = 0; i < x.length; i++)
  {
    x[ i ] += dX[ i ];
    y[ i ] += dY[ i ];  
  }  
}

void drawRects( )
{
   for ( int i = 0; i < x.length; i++)
  {
     fill( col[i] );
     rect( x[i]%width, y[i]%height, edge[i], edge[i]);
  } 
}

int[ ] initInt( int low, int high )
{
   int [ ] temp = new int[ MAX ];
   for (int i = 0; i <  temp.length; i++)
   {
      temp[ i ] = int(random( low, high ) ); 
   }
   return temp;
}

color[ ] initCol(  )
{
   color[ ] tempColor = new color[ MAX ];
   for (int i = 0; i <  tempColor.length; i++)
   {
      int redValue = int( random( 255) );
      int greenValue = int( random( 255) );
      int blueValue = int( random( 255 ) );
      tempColor[ i ] = color( redValue, greenValue, blueValue ); 
   }
   return tempColor;
}
