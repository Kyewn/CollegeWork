#include "object.h"

// Default constructor
Object::Object() {

}

Object::~Object() {

}

void Object::drawPoint(GLfloat x, GLfloat y, GLfloat size) {
    // Render code
    glPushMatrix();
	glPointSize(size);
	glBegin(GL_POINTS);
		glVertex2i(x, y);
	glEnd();
	glPopMatrix();
}

void Object::drawLine(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat thickness) {
	glPushMatrix();
	glLineWidth(thickness);
	glBegin(GL_LINES);
		glVertex2i(x1, y1);
		glVertex2i(x2, y2);
	glEnd();
	glPopMatrix();
}

void Object::drawTriangle(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat x3, GLfloat y3) {
	glPushMatrix();
	glBegin(GL_TRIANGLES);
		glVertex2i(x1,y1);
		glVertex2i(x2,y2);
		glVertex2i(x3,y3);
	glEnd();
	glPopMatrix();
}

void Object::drawQuad(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat x3, GLfloat y3, GLfloat x4, GLfloat y4) {
	glPushMatrix();
	glBegin(GL_QUADS);
		glVertex2i(x1,y1);
		glVertex2i(x2,y2);
		glVertex2i(x3,y3);
		glVertex2i(x4,y4);
	glEnd();
	glPopMatrix();
}

void Object::drawRegularPolygon(GLfloat cx, GLfloat cy, GLfloat radius, GLint side, GLfloat orientation, GLfloat width, GLfloat height) {
	if (side >= 3) {
		glPushMatrix();
		GLint xp, yp;
		glBegin(GL_POLYGON);
			for (int i=0; i<side; i++) {
				xp = (int)(cx + width*radius*cos(orientation + 2 * 3.14159265/side*i));
				yp = (int)(cy + height*radius*sin(orientation + 2 * 3.14159265/side*i));
				glVertex2i(xp,yp);
			}
		glEnd();
		glPopMatrix();
	} else {
		cerr << "Could not render polygon with less than 3 sides" << endl;
	}
}

