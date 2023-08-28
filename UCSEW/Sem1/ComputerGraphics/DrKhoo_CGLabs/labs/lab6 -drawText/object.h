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
	void drawText(const char* text, GLint length, GLfloat x, GLfloat y, void* font);
	// 2D transformation
	void translate(GLfloat tX, GLfloat tY);
	void rotate(GLfloat t, GLfloat pX, GLfloat pY);
	
	GLfloat x, y;
};

#endif
