//Initial Tutorial 
//Week-1 

//====================================================================================================
//  Every line beginning with // is ignored by Processing
//  when you run the program.

//  To run this program, click the triangle in the circle at 
//  the upper left of the window.
//  To find out more about the functions used below, refer 
//  to the Processing AP.
//  The link in on the course web page.

//  The function calls or code in this program are executed 
//  from the top to the bottom one at a time. 
//  None are skipped and none are repeated.


//  The first line of code below these comments is a function 
//  call.
//  This is calling the size function.
//  The arguments of the function are used by Processing to 
//  set the size of the graphics window.
//  Alter the arguments to be sure you understand what the 
//  first and second
//     arguments do the size of the window.
size( 400, 400 );

// This function call smooths out the jagged lines of the  
// circles.
// Run this one time and then comment this line out with two   
// and run it again to see the difference.
smooth( );

// This draws a circle at the (0, 0 ) coordinate point.   
// The circle is 100 pixels in diameter.
ellipse(  0, 0, 100, 100);

// This draws one in the center of the window if the window  
// is 400 x 400:
ellipse( 200, 200, 50, 50 );

// This set of code draws a red rectangel near the bottom left  
// corner:
fill( 255, 0, 0 );
rect( 50, 350, 45, 35);

// This set of code draws a yellow circle with blue line or  
// stroke around it in the upper right corner:
fill( 255, 255, 0 );
stroke( 0, 0, 255 ); 
ellipse( 350, 50, 33, 33);


// This set of code draws a yellow circle with blue line or  
// stroke around it in the lower right corner:
// The blue line in the upper right corner is difficult to  
//  see to this code makes the line or stroke bigger.
strokeWeight( 10 ); 
ellipse( 350, 350, 33, 33);

// IMPORTANT
// The colors and width of the stroke do not change until  
// your code changes them.  
// Once you set them, they stay set that way until changed  
// by your code.
