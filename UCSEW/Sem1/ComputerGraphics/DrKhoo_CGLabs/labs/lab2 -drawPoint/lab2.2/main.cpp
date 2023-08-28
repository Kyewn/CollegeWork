#include <windows.h>
#include "object.h"
#include <gl/glut.h>
using namespace std;

Object drawObject = Object();

void render() {
	// Background color
	glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
	
	// Canvas settings
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0, 800, 0, 600); // Canvas size: 800x600
	
	glClear(GL_COLOR_BUFFER_BIT);

	// Render code
	glColor3f(1.0f, 0.0f, 0.0f); // Set red brush
	drawObject.drawPoint(400, 300, 5);

	glFlush();
	glFinish();
}

int main() {
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(800,600);
	glutInitWindowPosition(0,0);
	glutCreateWindow("Primitives!");
	glutDisplayFunc(render);
	glutMainLoop();
	
	system("PAUSE");
	return 0;
}
