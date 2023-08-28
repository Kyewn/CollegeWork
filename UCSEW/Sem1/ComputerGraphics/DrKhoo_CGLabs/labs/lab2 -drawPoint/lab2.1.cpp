#include <gl/glut.h>
using namespace std;

void render(){
	glClearColor (0.0, 1.0, 0.0, 1.0); //RHBA
	glClear(GL_COLOR_BUFFER_BIT); //Load frame buffer
	glFlush();
	glFinish();
}

int main(){
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(1280, 720);
	glutInitWindowPosition(50, 100);
	glutCreateWindow("Viewport01");
	glutDisplayFunc(render);// Load render function
	glutMainLoop();
	system("PAUSE");
	return 0;
}
