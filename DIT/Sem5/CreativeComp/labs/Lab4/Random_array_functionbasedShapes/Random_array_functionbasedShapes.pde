// Class Code set12C
// Refer to the board notes bn12

final int MAX = 5;

int [ ] a;
int [ ] b;
color [ ] col;

void setup( )
{
   size( 300, 300 );
   
   a = new int [ MAX ];
   b = new int [ MAX ];
   col = new color[ MAX ];
   
   initializeIntegerArray( a );
   initializeIntegerArray( b );
   initializeColorArray( );
   
   drawBoxes( );   
}

void initializeIntegerArray( int [ ] anyArray )
{
  for( int i = 0; i < anyArray.length; i++ )
  {
     anyArray[ i ] = int( random( width ) );
  } 
}

void initializeColorArray(  )
{
  for( int i = 0; i < col.length; i++ )
  {
     col[ i ] = color( int( random(255 ) ),
                       int( random(255 ) ),
                       int( random(255 ) ) );
  } 
}

void drawBoxes( )
{
   for( int i = 0; i < a.length; i++ )
  {
     fill( col[i] );
     rect( a[i], b[i], random( width/5), random(height/5) );
  } 
}
