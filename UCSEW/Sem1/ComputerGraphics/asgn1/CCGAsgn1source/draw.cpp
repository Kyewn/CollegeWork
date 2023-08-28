#include "draw.h"

const float PI = 3.1415926;

Draw::Draw() {
}

Draw::~Draw() {
}

// Primitives
void Draw::triangle(GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2, GLfloat x3, GLfloat y3,
					 GLfloat colorR, GLfloat colorG, GLfloat colorB){
	glColor3f(colorR, colorG, colorB);
	glBegin(GL_TRIANGLES);
		glVertex2i(x1, y1);
		glVertex2i(x2, y2);
		glVertex2i(x3, y3);	
	glEnd();
}

void Draw::arc(GLfloat x, GLfloat y, GLfloat xRad, GLfloat yRad, GLfloat angle, GLfloat angleOffset, 
					  GLfloat colorR, GLfloat colorG, GLfloat colorB) {
	const int STEP = 500;
	
	glPushMatrix();
	glColor3f(colorR, colorG, colorB);
	glBegin(GL_POLYGON);
		for (int i = 0; i < STEP; i++) {
			float xp =  x + xRad * cos(angleOffset + angle / STEP * i);
			float yp = y + yRad * sin(angleOffset + angle / STEP * i);
			
			glVertex2i(xp, yp);
		}
	glEnd();
	glPopMatrix();
}

void Draw::quad(GLfloat x, GLfloat y, GLfloat width, GLfloat height,
			    GLfloat startColorR, GLfloat startColorG, GLfloat startColorB,
			    GLfloat endColorR, GLfloat endColorG, GLfloat endColorB) {
	float diffR = startColorR - endColorR;
	float diffG = startColorG - endColorG;
	float diffB = startColorB - endColorB; 
	glPushMatrix();
	glBegin(GL_POINTS);
		for (int xp = x; xp < x+width; xp++) {
			float colorR = startColorR - diffR / width * (xp - x);
			float colorG = startColorG - diffG / width * (xp - x);
			float colorB = startColorB - diffB / width * (xp - x);
			
			glPointSize(10);
			glColor3f(colorR, colorG, colorB);
			for (int yp = y; yp < y+height; yp++) {
				glVertex2i(xp, yp);
			}
		}
	glEnd();
	glPopMatrix();
}


// Car dashboard objects
void Draw::gauge(GLfloat x, GLfloat y, GLfloat xRad, GLfloat yRad, GLfloat thickness, GLfloat angle, GLfloat angleOffset, 
				 GLfloat colorR, GLfloat colorG, GLfloat colorB) {
				 				 	
	this->arc(x, y, xRad + thickness, yRad + thickness, angle, angleOffset, colorR, colorG, colorB);
	this->arc(x, y, xRad, yRad, 2*PI, 0, .0f, .0f, .0f);
}

void Draw::headerBorder(GLfloat x, GLfloat y, GLfloat width, GLfloat height, GLfloat thickness, 
					   GLfloat colorR, GLfloat colorG, GLfloat colorB) {					   	
	
	float innerWidth = width - 2*thickness;
	float innerHeight = height - thickness;

	// Colored area					   
	this->quad(x, 0, width, height, colorR, colorG, colorB, colorR, colorG, colorB);
	// Inner area
	this->quad(x + thickness, 0, innerWidth, innerHeight, .0,.0,.0, .0,.0,.0);
	// Left rounded edge
	this->gauge(x, 0, innerHeight, innerHeight, thickness, -2*PI, 0, colorR, colorG, colorB);
	// Right rounded edge
	this->gauge(x + width, 0, innerHeight, innerHeight, thickness, -2*PI, 0, colorR, colorG, colorB);
	// Inner concealer
	this->quad(x, 0, width, height - thickness, .0,.0,.0, .0,.0,.0);
}

void Draw::speedIcon(GLfloat x, GLfloat y, GLfloat radius) {
	this->gauge(x, y, radius, radius, 4, 3*PI/2, PI - PI*0.25, 1.0, 1.0, 1.0);
	this->arc(x,y, radius/3, radius/3, 2*PI, 0, 1.0, 1.0, 1.0);
	glPushMatrix();
		glMatrixMode(GL_MODELVIEW);
		glLoadIdentity();
		glTranslatef(x, y, .0f);
		glRotatef(45.0, .0, .0, 1.0);
		this->triangle(-radius/3, 0, radius/3, 0, 0, -radius, 1.0, 1.0, 1.0);
	glPopMatrix();
}


void Draw::rpmIcon(GLfloat x, GLfloat y, GLfloat radius) {
	this->gauge(x, y, radius, radius, 4, 3*PI/2, PI - PI*0.25, 1.0, 1.0, 1.0);
	float dotsRadius = PI / 3;
	
	// Inner circles
	for (int i = 0; i < 6; i++) {
		float xp = x + (radius - 10) * cos(-dotsRadius * i);
		float yp = y + (radius - 10) * sin(-dotsRadius * i);
		
		this->arc(xp, yp, 3, 3, 2*PI, 0, 1.0, 1.0, 1.0);	
	}
}

void Draw::tempIcon(GLfloat x, GLfloat y, GLfloat radius, GLfloat stalkHeight, GLfloat stalkWidth, GLfloat colorR, GLfloat colorG, GLfloat colorB) {
	this->arc(x, y, radius, radius, 2*PI, 0, colorR, colorG, colorB);
	this->quad(x-radius/2.0 + 0.5, y-stalkHeight, stalkWidth, stalkHeight, colorR, colorG, colorB, colorR, colorG, colorB);
	this->arc(x-radius/2.0 + 0.7 + stalkWidth/2, y-stalkHeight, stalkWidth/2, stalkWidth/2, 2*PI, 0, colorR, colorG, colorB);
	this->arc(x, y, radius-2, radius-2, PI, 0, 1.0, 1.0, 1.0);
}

void Draw::text(GLfloat x, GLfloat y, const char* text, GLint length, void* font, GLfloat colorR, GLfloat colorG, GLfloat colorB) {
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();

	glColor3f(colorR, colorG, colorB);
	glPushMatrix();
		glRasterPos2i(x, y);
		for (int i = 0; i<length; i++) {
			glutBitmapCharacter(font, (int) text[i]);
		}
	glPopMatrix();
}
