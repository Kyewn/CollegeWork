#ifndef _OJBECT_H_
#define _OBJECT_H_
#include <iostream>
#include "math.h"
#include <GL/glut.h>

using namespace std;

class Object{
public:
	Object();
	Object(GLfloat x, GLfloat y);
	Object(GLfloat x, GLfloat y, GLfloat width, GLfloat height);
	Object(GLfloat x, GLfloat y, GLfloat width, GLfloat height, GLfloat xVel, GLfloat yVel);
	~Object();
	
	// 2D primitives
	void drawPoint(GLfloat x, GLfloat y, GLfloat size);
	void drawLine(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat thickness);
	void drawTriangle(GLfloat x1, GLfloat y1,
					  GLfloat x2, GLfloat y2,
					  GLfloat x3, GLfloat y3);
	void drawQuad(GLfloat x1, GLfloat y1,
				  GLfloat x2, GLfloat y2,
				  GLfloat x3, GLfloat y3,
				  GLfloat x4, GLfloat y4);
	void drawRect(GLfloat x, GLfloat y, GLfloat width, GLfloat height);
	void drawRegularPolygon(GLfloat cx, GLfloat cy, GLfloat radius, GLint side, GLfloat orientation, GLfloat width, GLfloat height);
	void drawSineCurve(GLfloat int0, GLfloat int1);
	
	// 2D transformation
	void translate(GLfloat tX, GLfloat tY);
	void rotate(GLfloat t, GLfloat pX, GLfloat pY);
	void orbit(GLfloat cx, GLfloat cy, GLfloat radius, GLfloat& angle, GLfloat torque);
	void scale(GLfloat sX, GLfloat sY);
	
	GLfloat x, y, width, height, xVel, yVel;
	GLboolean scaleOnce, enlarge;
};

#endif