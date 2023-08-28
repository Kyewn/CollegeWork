#include <GL/glut.h>
#include "Model.h"

using namespace Model;

void Teapot::draw(){
	glColor3f(1.0f, 1.0f, 0.0f);
	glFrontFace(GL_CW);
	glutWireTeapot(5);
	glFrontFace(GL_CCW);
}
void Sphere::draw(){
	glColor3f(1.0f, 0.0f, 0.0f);
	glFrontFace(GL_CW);
	glutWireSphere(10, 24, 24); // Arg1=Radius arg2=Latitude, arg3=Longitude.
	glFrontFace(GL_CCW);
}
void Torus::draw(){
	glColor3f(0.0f, 1.0f, 0.0f);
	glFrontFace(GL_CW);
	glutWireTorus(5, 10, 24, 24); // Arg1=InnerRadius, arg2=OuterRadius, arg3=Latitude, arg4=Longitude
	glFrontFace(GL_CCW);
}
void World::draw(){
	glPushMatrix();
		// teapot.draw();
		// sphere.draw();
		torus.draw();
	glPopMatrix();
}