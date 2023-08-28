#include <windows.h>
#include <gl/glut.h>
#include "object.h"

using namespace std;

Object sprite01 = Object();
Object sprite02 = Object(500, 25);
Object sprite03 = Object(500, 25);
Object sprite04 = Object(400, 300);
Object sprite05 = Object(500, 400);
Object sprite06 = Object(0, 100);

string text;

void render(){
	glClearColor(.0f, .0f, .0f, 1.0f); // white background
	
	// Canvas settings
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0, 800, 0, 600); // Set canvas to 800×600 pixels.
	
	glClear(GL_COLOR_BUFFER_BIT); // Load frame buffer.
	
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	
	// Render code here
	glColor3f(1.0f, 0.0f, 0.0f); // Set red brush
	sprite01.drawPoint(400, 300, 10);
	
	glColor3f(0.0f, 1.0f, 0.0f); // Set green brush
	sprite01.drawLine(0, 0, 300, 300, 3.0);
	
	glColor3f(0.0f, 0.0f, 1.0f); // Set blue brush
	sprite01.drawTriangle(0, 0, 0, 100, 100, 100);
	
	glColor3f(0.0f, 1.0f, 1.0f); // Set cyan brush
	sprite01.drawQuad(200, 200, 400, 200, 400, 400, 200, 400);
	
	glColor3f(1.0f, 1.0f, 0.0f); // Set yellow brush.
	sprite01.drawRegularPolygon(450, 450, 50, 24, 0, 1, 1);
	
	sprite02.drawRect(500, 25, 100, 100);
	
	// Global translation
	sprite03.x = 500;
	sprite03.y = 25;
	sprite03.translate(150, 0);
	sprite03.drawRect(sprite03.x, sprite03.y, 100, 100);
	
	// Local rotation
	glColor3f(1.0f, 0.0f, 1.0f); // Set magenta brush.
	sprite04.rotate(-90, 400, 300);
	sprite04.drawTriangle(350, 250, 450, 250, 400, 350);
	glLoadIdentity(); // Reset the transformation.	
	
	glColor3f(1.0f, 0.0f, 0.0f); // Set magenta brush.
	sprite04.drawPoint(400, 300, 5);
	
	// Scale - not working
	glColor3f(1.0f, 0.5f, 0.0f); // Set magenta brush.
	glTranslated(500, 400, 0);
	glScalef(2.0f, 2.0f, 1.0f);
	sprite05.drawRegularPolygon(500 , 400, 10, 5, 0, 0, 0);
	glLoadIdentity(); // Reset the transformation.	
	
	// Sine curve	
	sprite06.drawSineCurve(0, 799);
	
	// Draw text
	text = "Hello World";
	
	glColor3f(.5f, .5f, .5f);
	sprite06.drawText(text.data(), text.size(), 52, 550, GLUT_BITMAP_8_BY_13);
	
	glColor3f(1.0f, .0, .0);
	sprite06.drawText(text.data(), text.size(), 50, 550, GLUT_BITMAP_8_BY_13);
	
	
	glFlush();
	glFinish();
}

int main(){
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(800, 600);
	glutInitWindowPosition(0, 0);
	glutCreateWindow("2D objects");
	glutDisplayFunc(render); // Load render function.
	glutMainLoop(); // Loop frame forever.
	
	return 0;
}
