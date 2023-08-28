#include "guardpostObject.h"
GuardpostObject::GuardpostObject() {
	this->x = 0;
	this->y = 0;
	size = 1;
	transformOnce = true;
}
GuardpostObject::GuardpostObject(GLfloat x, GLfloat y) {
	this->x = x;
	this->y = y;
}
GuardpostObject::~GuardpostObject(){}

void GuardpostObject::drawPoint(GLfloat x, GLfloat y, GLfloat size){
	glPushMatrix();
	glPointSize(size);
	glBegin(GL_POINTS);
		glVertex2i(x, y);
	glEnd();
	glPopMatrix();	
}
void GuardpostObject::drawLine(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat thickness){
	glPushMatrix();
	glLineWidth(thickness);
	glBegin(GL_LINES);
		glVertex2i(x1,y1);
		glVertex2i(x2,y2);
	glEnd();
	glPopMatrix();	
}
void GuardpostObject::drawTriangle(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat x3, GLfloat y3){
	glPushMatrix();
	glBegin(GL_TRIANGLES);
		glVertex2i(x1,y1);
		glVertex2i(x2,y2);
		glVertex2i(x3,y3);
	glEnd();
	glPopMatrix();
}
void GuardpostObject::drawQuad(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat x3, GLfloat y3, GLfloat x4, GLfloat y4){
	glPushMatrix();
	glBegin(GL_QUADS);
		glVertex2i(x1,y1);
		glVertex2i(x2,y2);
		glVertex2i(x3,y3);
		glVertex2i(x4,y4);
	glEnd();
	glPopMatrix();
}
void GuardpostObject::drawRect(GLfloat x, GLfloat y, GLfloat width, GLfloat height){
	for (this->x=x; this->x<x+width; this->x++) {
		for (this->y=y; this->y<y+height; this->y++) {
			this->drawPoint(this->x, this->y, 1);
		}
	}
}
void GuardpostObject::drawGradRect(GLfloat x, GLfloat y, GLfloat width, GLfloat height) {
	for (this->x=x; this->x<x+width; this->x++) {
		for (this->y=y; this->y<y+height; this->y++) {
			glColor3f((this->y - y)*0.5f/height,0.7f+(this->y - y)*0.1f/height,1.0f-(this->y - y)*0.1f/height);
			this->drawPoint(this->x, this->y, 1);
		}
	}
}
void GuardpostObject::drawRegularPolygon(GLfloat cx, GLfloat cy, GLfloat radius, GLint side, GLfloat orientation, GLfloat width, GLfloat height) {
	if(side >= 3){
		glPushMatrix();
		GLint xp, yp;
		glBegin(GL_POLYGON);
			for (int i=0; i<side; i++){
				xp = (int)(cx + width * radius * cos(orientation + 2 * 3.14159265 / side * i));
				yp = (int)(cy + width * radius * sin(orientation + 2 * 3.14159265 / side * i));
				glVertex2i(xp,yp);
			}
		glEnd();
		glPopMatrix();
	} else {
		cerr << "Could not render polygon with less than three sides." << endl;
	}
}
void GuardpostObject::drawSineCurve(GLfloat int0, GLfloat int1, double off, double a){
	for(this->x = int0; this->x < int1; this->x++){
		this->y += a*sin(off + this->x * 3.14159265/180);
		this->drawPoint(this->x, this->y, 5.0);
	}
} 

void GuardpostObject::translate(GLfloat tX, GLfloat tY){
	this->x = this->x + tX;
	this->y = this->y + tY;
}
void GuardpostObject::scale(GLfloat s){
	this->size = this->size * s;
}
void GuardpostObject::rotate(GLfloat t, GLfloat pX, GLfloat pY){
	glTranslated(pX, pY, 0);
	glRotatef(t, 0.0f, 0.0f, 1.0f);
	glTranslated(-pX, -pY, 0);
}


