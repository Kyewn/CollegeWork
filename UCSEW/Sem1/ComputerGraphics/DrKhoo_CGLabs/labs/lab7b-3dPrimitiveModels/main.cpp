#include <windows.h>
#include <gl/glut.h>
#include "object.h"
#include "space.h"
#include "model.h"

using Model::World;
using namespace std;

Window window;
ViewFrustum viewer;
World world;

void windowSettings(){
	window.title = "3D graphics";
	window.offsetX = 50;
	window.offsetY = 50;
	window.width = 800;
	window.height = 600;
}
void spaceSettings(){
	viewer.eyeX = 0.0; viewer.eyeY = 80.0; viewer.eyeZ = 30.0;
	viewer.refX = 0.0; viewer.refY = 0.0; viewer.refZ = 0.0;
	viewer.upX = 0.0; viewer.upY = 1.0; viewer.upZ = 0.0;
	viewer.nearZ = 0.1; viewer.farZ = 500.0;
	viewer.fov = 30.0;
	viewer.ar = static_cast<GLdouble>(window.width/window.height);
}
void init(){
	windowSettings();
	spaceSettings();
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
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	
	// 3D model rendering is here.
	world.draw();
	
	glFlush();
	glutSwapBuffers();
}

void perspectiveView(){
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	//gluPerspective(viewer.fov, viewer.ar, viewer.nearZ, viewer.farZ);
	
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	gluLookAt(viewer.eyeX, viewer.eyeY, viewer.eyeZ,
	          viewer.refX, viewer.refY, viewer.refZ,
			  viewer.upX, viewer.upY, viewer.upZ);
}

int main(){
	init();
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE | GLUT_DEPTH);
	glutInitWindowSize(window.width, window.height);
	glutInitWindowPosition(window.offsetX, window.offsetY);
	glutCreateWindow(window.title.c_str());
	glutDisplayFunc(render); // Load render function.
	
	perspectiveView(); // Set perspective view.
	
	glutMainLoop(); // Loop frame forever.
	
	system("PAUSE");
	return 0;
}
