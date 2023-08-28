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
#endif