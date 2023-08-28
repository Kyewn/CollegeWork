#ifndef _DRAW_H_
#define _DRAW_H_

#include <iostream>
#include <string>
#include "math.h"
#include <GL/glut.h>
using namespace std;

class Draw {
	public:
		Draw();
		~Draw();


		// Primitives
		void arc(GLfloat x, GLfloat y, GLfloat xRad, GLfloat yRad, GLfloat angle, GLfloat angleOffset ,
				 GLfloat colorR, GLfloat colorG, GLfloat colorB);
		void quad(GLfloat x, GLfloat y, GLfloat width, GLfloat height,
			      GLfloat startColorR, GLfloat startColorG, GLfloat startColorB,
			      GLfloat endColorR, GLfloat endColorG, GLfloat endColorB);
		void triangle(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat x3, GLfloat y3,
					 	     GLfloat colorR, GLfloat colorG, GLfloat colorB);
			    
		// Car dashboard objects
		void gauge(GLfloat x, GLfloat y, GLfloat xRad, GLfloat yRad, GLfloat thickness, GLfloat angle, GLfloat angleOffset, 
				   GLfloat colorR, GLfloat colorG, GLfloat colorB);
	    void headerBorder(GLfloat x, GLfloat y, GLfloat width, GLfloat height, GLfloat thickness, 
					      GLfloat colorR, GLfloat colorG, GLfloat colorB); 
		void speedIcon(GLfloat x, GLfloat y, GLfloat radius);
		void rpmIcon(GLfloat x, GLfloat y, GLfloat radius);
		void tempIcon(GLfloat x, GLfloat y, GLfloat radius, GLfloat stalkHeight, GLfloat stalkWidth, GLfloat colorR, GLfloat colorG, GLfloat colorB);
		void text(GLfloat x, GLfloat y, const char* text, GLint length, void* font, GLfloat colorR, GLfloat colorG, GLfloat colorB);
};

#endif
