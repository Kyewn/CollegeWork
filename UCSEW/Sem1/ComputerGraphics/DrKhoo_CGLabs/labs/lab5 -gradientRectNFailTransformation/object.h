#ifndef _OBJECT_H_
#define _OBJECT_H_
#include <iostream>
#include "math.h"
#include <GL/glut.h>
using namespace std;

class Object {
    public:
    	GLfloat x,y;
    	
        Object();
        Object(GLfloat x, GLfloat y);
        ~Object();
    
        void drawPoint(GLfloat x, GLfloat y, GLfloat size);
        void drawLine(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat thickness);
        void drawTriangle(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat x3, GLfloat y3);
        void drawQuad(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat x3, GLfloat y3, GLfloat x4, GLfloat y4);
        void drawRect(GLfloat x, GLfloat y, GLfloat width, GLfloat height);
		void drawRegularPolygon(GLfloat cx, GLfloat cy, GLfloat radius, GLint side, GLfloat orientation, GLfloat width, GLfloat height);
		
		// 2D transformation
		void translate(GLfloat tx, GLfloat ty);		
};
#endif
