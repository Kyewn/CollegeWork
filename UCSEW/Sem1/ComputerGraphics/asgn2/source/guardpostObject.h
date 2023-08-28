#ifndef _GUARDPOST_OBJECT_H_
#define _GUARDPOST_OBJECT_H_
#include <iostream>
#include "math.h"
#include <cstdlib>
#include <GL/glut.h>
using namespace std;

class GuardpostObject { 
	public:
		GuardpostObject();
		GuardpostObject(GLfloat x, GLfloat y);
		~GuardpostObject();
		GLfloat x, y;
		GLfloat size;
		GLboolean transformOnce;
		void drawPoint(GLfloat x, GLfloat y, GLfloat size);
		void drawLine(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat thickness);
		void drawTriangle(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat x3, GLfloat y3);
		void drawQuad(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat x3, GLfloat y3, GLfloat x4, GLfloat y4);
		void drawRect(GLfloat x, GLfloat y, GLfloat width, GLfloat height);
		void drawGradRect(GLfloat x, GLfloat y, GLfloat width, GLfloat height);
		void drawRegularPolygon(GLfloat cx, GLfloat cy, GLfloat radius, GLint side, GLfloat orientation, GLfloat width, GLfloat height);
		void drawSineCurve(GLfloat int0, GLfloat int1, double off, double a);
		void translate(GLfloat tX, GLfloat tY);
		void scale(GLfloat s);
		void rotate(GLfloat t, GLfloat pX, GLfloat pY);
};
#endif
