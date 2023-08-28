#include <windows.h>
#include <gl/glut.h>
#include "object.h"

using namespace std;


GLfloat angle = 0.0;
GLfloat angle2 = 0.0;
GLfloat sineStart = 0;
GLfloat sineEnd = 0;
Object sprite01 = Object(0, 300, 1.0, 1.0, 0.1, 0.1);
Object sprite02 = Object(400, 300, 1.0, 1.0, 0.1, 0.1);
Object sprite03 = Object(400, 300, 1.0, 1.0, 0.1, 0.1);
Object sprite04 = Object(0, 0, 1.0, 1.0, 0.1, 0.1);
Object sprite05 = Object(400, 300, 1.0, 1.0, 0.1, 0.1);
Object sprite06 = Object(0, 300, 1.0, 1.0, 0.1, 0.1);
Object sprite07 = Object(0, 100, 1.0, 1.0, 0.1, 0.1);
Object sprite08 = Object(0, 200, 1.0, 1.0, 0.1, 0.1);

void init(){
	sprite03.enlarge = true;
}

string text;
// Argument 1: Text, a string of characters to be rendered.
// Argument 2: Length of text.
// Argument 3 & 4: Top left corner (x, y) position to start draw.
// Argument 5: Font
void drawText(const char *text, GLint length, GLint x, GLint y, void *font){
	glMatrixMode(GL_PROJECTION);
	double *matrix = new double[16];
	glGetDoublev(GL_PROJECTION_MATRIX, matrix);
	glLoadIdentity();
	
	glOrtho(0, 800, 0, 600, -5, 5);
	
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	
	glPushMatrix();
		glLoadIdentity();
		glRasterPos2i(x, y);
		for(int i=0; i<length; i++){
			glutBitmapCharacter(font, (int)text[i]);
		}
	glPopMatrix();
	
	glMatrixMode(GL_PROJECTION);
	glLoadMatrixd(matrix);
	glMatrixMode(GL_MODELVIEW);
}

void render(){
	glClearColor(1.0f, 1.0f, 1.0f, 1.0f); // white background
	
	// Canvas settings
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0, 800, 0, 600); // Set canvas to 800×600 pixels.
	
	glClear(GL_COLOR_BUFFER_BIT); // Load frame buffer.
	
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	
	// Translate object
	glColor3f(1.0f, 0.0f, 0.0f);
	sprite01.translate(sprite01.xVel, 0.0);
	sprite01.drawPoint(sprite01.x, sprite01.y, 5.0);
	if(sprite01.x >= 799)
		sprite01.x = 0.0;
	
	// Rotate object
	glColor3f(0.0f, 1.0f, 0.0f);
	sprite02.orbit(400, 300, 100, angle, 0.1);
	sprite02.drawPoint(sprite02.x, sprite02.y, 10.0);
	
	// Scale object
	glColor3f(0.0f, 0.0f, 1.0f);
	if(sprite03.width > 200 && sprite03.height > 200)
		sprite03.enlarge = false;
	if(sprite03.width < 2 && sprite03.height < 2)
		sprite03.enlarge = true;
	if(sprite03.enlarge)
		sprite03.scale(1.001, 1.001); // Enlarge
	else
		sprite03.scale(0.999, 0.999); // Shrink
	sprite03.drawPoint(sprite03.x, sprite03.y, sprite03.width);
	
	glColor3f(1.0f, .0, 1.0f);
	sprite04.translate(sprite04.xVel, .0);
	sprite04.drawTriangle(sprite04.x, sprite04.y, sprite04.x+100, sprite04.y, sprite04.x, sprite04.y+100);
	
	if (sprite04.x > 799) {
		sprite04.x = 0;
	}
	
	glColor3f(1.0f, 1.0f, 0.0f);
	sprite05.orbit(400, 300, 150, angle2, 0.5);
	sprite05.drawTriangle(sprite05.x-25, sprite05.y-25, sprite05.x+25, sprite05.y-25, sprite05.x, sprite05.y+25);
	
	glColor3f(1.0f, .5f, 1.0f);
	if (sprite06.width < 0.025) {
		sprite06.enlarge = true;
	}
	
	if (sprite06.width >= 2) {
		sprite06.enlarge = false;
	}
	
	if (sprite06.enlarge) {
		sprite06.scale(1.025, 1.025);
	} else {
		sprite06.scale(0.975, 0.975);
	}
	sprite05.drawRect(0, 300, sprite06.width * 100, sprite06.height * 100);
	
	glColor3f(0.5f, 0.1f, 0.9f);
	sprite07.drawSineCurve(sineStart++, 360+sineEnd++);
	if (sprite07.x > 799){
		sineStart = sineEnd = 0;
	}

	glColor3f(0.0f, 0.5f, 1.0f);
	sprite08.translate(sprite08.xVel, .0);
	sprite08.y += 0.23 * cos(sprite08.x*3.14159265/180);
	if (sprite08.x > 799) {
		sprite08.x = 0;
		sprite08.y = 200;
	}
	sprite07.drawPoint(sprite08.x, sprite08.y, 25);
	
	glutSwapBuffers(); // Swap foreground and background frames.
	glutPostRedisplay(); // Update the canvas display.
	glFlush();
	glFinish();
}
int main(){
	init();
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowSize(800, 600);
	glutInitWindowPosition(0, 0);
	glutCreateWindow("2D motion & animation");
	glutDisplayFunc(render); // Load render function.
	glutMainLoop(); // Loop frame forever.
	
	system("PAUSE");
	return 0;
}
