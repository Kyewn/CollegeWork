#include <windows.h>
#include <gl/glut.h>
using namespace std;

void render() {
	glClearColor(1.0f, 0.0f, 0.0f, 1.0f);
	glClear(GL_COLOR_BUFFER_BIT);
	glFlush();
	glFinish();
}

int main() {
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(800,600);
	glutInitWindowPosition(0,0);
	glutCreateWindow("Hello OpenGL!");
	glutDisplayFunc(render);
	glutMainLoop();
	
	system("PAUSE");
	return 0;
}
