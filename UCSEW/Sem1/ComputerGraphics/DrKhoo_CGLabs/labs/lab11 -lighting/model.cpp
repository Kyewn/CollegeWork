#include <GL/glut.h>
#include "model.h"
using namespace Model;

void Teapot::draw(){
	glColor3f(1.0f, 1.0f, 0.0f);
	glFrontFace(GL_CW);
	glutSolidTeapot(5);
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
void Box::draw(){
	static GLfloat vertices[8][3] = {
		{ 
			-5.0f, -5.0f, 5.0f
		},
		{ 
			5.0f, -5.0f, 5.0f
		},
		{ 
			5.0f, -5.0f, -5.0f
		},
		{ 
			-5.0f, -5.0f, -5.0f
		},
		{ 
			-5.0f, 5.0f, 5.0f
		},
		{ 
			5.0f, 5.0f, 5.0f
		},
		{ 
			5.0f, 5.0f, -5.0f
		},
		{ 
			-5.0f, 5.0f, -5.0f
		},
	};
	
	static int face[6*4] = {
		3, 0, 4, 7, 
		3, 2, 1, 0,
		2, 3, 7, 6,
		1, 2, 6, 5,
		4, 5, 6, 7,
		0, 1, 5, 4
	};
	
	static GLfloat normals[6][3] = {
		{
			-1.0f, 0.0f, 0.0f
		},
		{
			0.0f, -1.0f, 0.0f
		},
		{
			0.0f, 0.0f, -1.0f
		},		
		{
			1.0f, 0.0f, 0.0f
		},
		{
			0.0f, 1.0f, 0.0f
		},
		{
			0.0f, 0.0f, 1.0f
		}
	};
	
	static const GLfloat colors[6][3] = {
		{
			1.0f, 0.0f, 0.0f
		},
		{
			0.0f, 1.0f, 0.0f
		},
		{
			0.0f, 0.0f, 1.0f
		},		
		{
			1.0f, 1.0f, 0.0f
		},
		{
			0.0f, 1.0f, 1.0f
		},
		{
			1.0f, 0.0f, 1.0f
		}
	};
	
	int n = 6;
	int noOfVerticesPerFace = 4;
	
	int no = 0;
	for (int i = 0; i < n; i++) {
		glColor3fv(colors[i]);
		glBegin(GL_POLYGON);
		glNormal3fv(normals[i]);
		for (int j=0; j<noOfVerticesPerFace; j++) {
			glVertex3fv(vertices[face[no++]]);
		}
		glEnd();
	}
}
void World::draw(){
	glPushMatrix();
		glTranslatef(.0, .0, 10.0f);
		teapot.draw();
	glPopMatrix();

	glPushMatrix();
		glTranslatef(.0, -3.0f, .0);
		glScalef(1.0f, 1.0f, 1.0f);
		// teapot.draw();
		// sphere.draw();
		// torus.draw();
		box.draw();
	glPopMatrix();
}
