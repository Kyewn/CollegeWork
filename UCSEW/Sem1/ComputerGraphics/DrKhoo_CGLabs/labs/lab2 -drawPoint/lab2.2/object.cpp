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