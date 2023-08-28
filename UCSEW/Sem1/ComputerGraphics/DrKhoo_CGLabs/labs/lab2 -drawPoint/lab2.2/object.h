#ifndef _OBJECT_H_
#define _OBJECT_H_
#include <iostream>
#include "math.h"
#include <GL/glut.h>
using namespace std;

class Object {
    public:
        Object();
        ~Object();
    
        void drawPoint(GLfloat x, GLfloat y, GLfloat size);
};

#endif