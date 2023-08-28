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
WorldTransform wt;
LocalTransform lt;

void windowSettings(){
	window.title = "3D graphics";
	window.offsetX = 50;
	window.offsetY = 50;
	window.width = 800;
	window.height = 600;
}
void spaceSettings(){
	viewer.eyeX = 0.0; viewer.eyeY = 20.0; viewer.eyeZ = 40.0;
	viewer.refX = 0.0; viewer.refY = 0.0; viewer.refZ = 0.0;
	viewer.upX = 0.0; viewer.upY = 1.0; viewer.upZ = 0.0;
	viewer.nearZ = 0.1; viewer.farZ = 500.0;
	viewer.fov = 60.0;
	viewer.ar = static_cast<GLdouble>(window.width/window.height);
}

void transformationSettings() {
	wt.tX = wt.tY = wt.tZ = 
	wt.rotateX = wt.rotateY = wt.rotateZ = 0.0;
	wt.sX = wt.sY = wt.sZ = lt.displaceAmount = 1.0;
	lt.rotateAmount = 2.0;	
}

void init(){
	windowSettings();
	spaceSettings();
	transformationSettings();
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
	
	glPushMatrix();
		glTranslatef(wt.tX, wt.tY, wt.tZ);
		glRotatef(wt.rotateX, 1.0f, 0.0f, 0.0f);
		glRotatef(wt.rotateY, 0.0f, 1.0f, 0.0f);
		glRotatef(wt.rotateZ, 0.0f, 0.0f, 1.0f);
		glScalef(wt.sX, wt.sY, wt.sZ);
		
		// 3D model rendering is here.
		world.draw();
	glPopMatrix();
	glFlush();
	glutSwapBuffers();
	glutPostRedisplay();
	glFinish();
}

void perspectiveView(){
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(viewer.fov, viewer.ar, viewer.nearZ, viewer.farZ);
	
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	gluLookAt(viewer.eyeX, viewer.eyeY, viewer.eyeZ,
	          viewer.refX, viewer.refY, viewer.refZ,
			  viewer.upX, viewer.upY, viewer.upZ);
}

void lighting() {
	static GLfloat diffuse[] = {1.0f, 1.0f, 1.0f, 1.0f};
	static GLfloat specular[] = {1.0f, 1.0f, 1.0f, 1.0f};
	static GLfloat ambient[] = {.0f, .0f, .0f, 1.0f};
	static GLfloat specularRef[] = {1.0f, 1.0f, 1.0f, 1.0f};
	static GLfloat position[] = {10.0f, 10.0f, 10.0f, 1.0f};
	short shininess = 127;
	
	glDisable(GL_LIGHTING);
	glLightfv(GL_LIGHT0, GL_DIFFUSE, diffuse);
	glLightfv(GL_LIGHT0, GL_SPECULAR, specular);
	glLightfv(GL_LIGHT0, GL_AMBIENT, ambient);
	glLightfv(GL_LIGHT0, GL_POSITION, position);
	glEnable(GL_LIGHT0);
	
	glColorMaterial(GL_FRONT, GL_AMBIENT_AND_DIFFUSE);
	glEnable(GL_COLOR_MATERIAL);
	
	glMaterialfv(GL_FRONT, GL_SPECULAR, specularRef);
	glMateriali(GL_FRONT, GL_SHININESS, shininess);
	glEnable(GL_NORMALIZE);
	glEnable(GL_LIGHTING);
}

// Mouse events
void onMousePress(GLint button, GLint state, GLint x, GLint y) {
	y = window.height - y;
	
	switch (button) {
		case GLUT_LEFT_BUTTON: 
			if (state == GLUT_DOWN && !lt.isLeftMousePressed) {
				lt.mouseX = x;
				lt.mouseY = y;
				lt.isLeftMousePressed = true;
			}
			if (state == GLUT_UP && lt.isLeftMousePressed) {
				lt.isLeftMousePressed = false;	
			}
			break;
		case GLUT_RIGHT_BUTTON: 
			if (state == GLUT_DOWN && !lt.isRightMousePressed) {
				lt.mouseX = x;
				lt.mouseY = y;
				lt.isRightMousePressed = true;
			}
			if (state == GLUT_UP && lt.isRightMousePressed) {
				lt.isRightMousePressed = false;	
			}
			break;
	}
}

void onMouseMove(GLint x, GLint y) {
	y = window.height - y;
	GLint dX = x - lt.mouseX;
	GLint dY = y - lt.mouseY;

	if (lt.isLeftMousePressed) {
		wt.rotate(-dY, dX, 0.0f);
	}	
	if (lt.isRightMousePressed) {
		wt.rotate(0.0f, 0.0f, dX);
	}
	lt.mouseX = x;
	lt.mouseY = y;
}

// Keyboard events
void onKeyboard(unsigned char key, GLint x, GLint y){
	GLfloat displaceX, displaceY, displaceZ;
	displaceX = displaceY = displaceZ = 0.0;
	switch (key) {
		case 'w': case 'W':
			displaceZ = -lt.displaceAmount;
			break;
		case 's': case 'S':
			displaceZ = lt.displaceAmount;
			break;
		case 'a': case 'A':
			displaceX = -lt.displaceAmount;
			break;
		case 'd': case 'D':
			displaceX = lt.displaceAmount;
			break;
		case 27:
			init();
			break;
	}
	wt.translate(displaceX, displaceY, displaceZ);
}

void onSpecialKeyboard(GLint key, GLint x, GLint y) {
	GLfloat displaceX, displaceY, displaceZ;
	displaceX = displaceY = displaceZ = 0.0;
	switch (key) {
		case GLUT_KEY_UP:
			displaceZ = -lt.displaceAmount;
			break;
		case GLUT_KEY_DOWN:
			displaceZ = lt.displaceAmount;
			break;
		case GLUT_KEY_LEFT:
			displaceX = -lt.displaceAmount;
			break;
		case GLUT_KEY_RIGHT:
			displaceX = lt.displaceAmount;
			break;
		case GLUT_KEY_HOME:
			init();
			break;
	}
	wt.translate(displaceX, displaceY, displaceZ);
}

int main(){
	init();
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE | GLUT_DEPTH);
	glutInitWindowSize(window.width, window.height);
	glutInitWindowPosition(window.offsetX, window.offsetY);
	glutCreateWindow(window.title.c_str());
	glutDisplayFunc(render); // Load render function.
	
	// Load event functions
	glutMouseFunc(onMousePress);
	glutMotionFunc(onMouseMove);
	glutKeyboardFunc(onKeyboard);
	glutSpecialFunc(onSpecialKeyboard);
	
	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LESS);
	glFrontFace(GL_CCW);
	glClearColor(.0, .0, .0, .0);
	glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);
	
	// Don't render faces that arent facing towards viewer - increase performance
	glEnable(GL_CULL_FACE);
	
	perspectiveView(); // Set perspective view.
	lighting();
	
	glutMainLoop(); // Loop frame forever.
	
	system("PAUSE");
	return 0;
}
