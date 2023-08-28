#ifndef _SPACE_H_
#define _SPACE_H_
#include <string>
#include <GL/glut.h>

using namespace std;

struct Window{
	string title;
	GLint offsetX, offsetY;
	GLint width, height;
};

struct ViewFrustum{
	GLdouble eyeX, eyeY, eyeZ;
	GLdouble refX, refY, refZ;
	GLdouble upX, upY, upZ;
	GLdouble nearZ, farZ;
	GLdouble fov; // Angle in Y direction.
	GLdouble ar;
};

struct WorldTransform {
	GLdouble tX, tY, tZ;
	GLdouble rotateX, rotateY, rotateZ;
	GLdouble sX, sY, sZ;
	
	void translate(GLfloat dX, GLfloat dY, GLfloat dZ) {
		tX += dX; tY += dY; tZ += dZ;
	}
	void rotate(GLfloat dX, GLfloat dY, GLfloat dZ) {
		rotateX += dX; rotateY += dY; rotateZ += dZ;
	}	
};

struct LocalTransform {
	GLdouble displaceAmount;
	GLdouble rotateAmount;
	GLint mouseX, mouseY;
	bool isLeftMousePressed, isRightMousePressed;
	
};

#endif
