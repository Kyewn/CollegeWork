#include <windows.h>
#include <gl/glut.h>
#include "object.h"

using namespace std;

GLfloat angle = 0.0;
Object sprite = Object(0, 300, 1.0, 1.0, 2.0, 2.0);
Object sprite2 = Object(400, 300, 1.0, 1.0, 2.0, 2.0);
Object sprite3 = Object(400, 300, 1.0, 1.0, 2.0, 2.0);

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
	
	// Render code here
	glColor3f(1.0f, .0, .0);
	sprite.translate(sprite.xVel, 0.0);
	sprite.drawPoint(sprite.x, sprite.y, 5.0);
	if(sprite.x >= 799) {
		sprite.x = 0.0;
	}

	glColor3f(.0, 1.0f, .0);
	sprite2.orbit(400, 300, 100, angle, 0.1);
	sprite2.drawPoint(sprite2.x, sprite2.y, 10.0);
	
	glColor3f(.0, .0, 1.0f);
	if (sprite3.width > 200 && sprite3.height > 200)
		sprite3.enlarge = false;
	else if (sprite3.width < 2 && sprite3.height < 2)
		sprite3.enlarge = true;

	if (sprite3.enlarge)
		sprite3.scale(1.01f, 1.01f);
	else
		sprite3.scale(0.99f, 0.99f);
		
	sprite3.drawPoint(sprite3.x, sprite3.y, sprite3.width);
	
	glutSwapBuffers();
	glutPostRedisplay();
	glFlush();
	glFinish();
}
int main(){
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowSize(800, 600);
	glutInitWindowPosition(0, 0);
	glutCreateWindow("2D objects");
	glutDisplayFunc(render); // Load render function.
	glutMainLoop(); // Loop frame forever.
	
	system("PAUSE");
	return 0;
}
