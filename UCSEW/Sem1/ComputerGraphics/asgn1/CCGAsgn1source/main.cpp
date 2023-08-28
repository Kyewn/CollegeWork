#include "draw.h"

const int VW = 1280;
const int VH = 720;
const float PI = 3.1415926;

Draw drawer = Draw();
string text;
	
void render() {
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0, VW, VH, 0); // Set canvas to 800×600 pixels.

	glClearColor(.0, .0, .0, 1.0);
	glClear(GL_COLOR_BUFFER_BIT);
	
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
			
	//	Header
	drawer.headerBorder(VW/7, 0, VW-VW*2/7, 100, 25, .25, .25, .25);
	drawer.tempIcon(VW-VW* 1.5/7, 50, 6, 24.0, 4.0, 1.0, 82/255.0, 82/255.0);
	text = "10:10AM";
	drawer.text(VW/2 - 20, 45, text.data(), text.size(), GLUT_BITMAP_HELVETICA_18, 1.0, 1.0, 1.0);
	text = "70'C";
	drawer.text(VW-VW* 1.4/7, 45, text.data(), text.size(), GLUT_BITMAP_HELVETICA_18, 1.0, 82/255.0, 82/255.0);
	drawer.triangle(15, 50, 70, 25, 70, 70, 1.0, 1.0, 222/255.0);
	drawer.triangle(VW-15, 50, VW-70, 25, VW-70, 70, 1.0, 1.0, 222/255.0);

	//	Gearbox
	drawer.quad(VW/2- 40, VH/4, 80, 80, 94/255.0, 215/255.0, 179/255.0, 107/255.0, 154/255.0, 247/255.0);
	drawer.quad(VW/2- 27.5, VH/4 + 12.5, 55, 55, .0, .0, .0, .0, .0, .0);
	
	text = "D";
	drawer.text(VW/2 - 5, VH/4 + 42, text.data(), text.size(), GLUT_BITMAP_HELVETICA_18, 94/255.0, 215/255.0, 179/255.0);
	
	//	Left gauge
	drawer.gauge(VW- VW* 3/4, VH* 3.5/5, 250, 300, 35, -PI, 0, 94/255.0, 215/255.0, 179/255.0);
	drawer.speedIcon(VW- VW* 3/4 - 60, VH* 3.3/5-190, 20);
	text = "SPEED";
	drawer.text(VW- VW* 3/4-10, VH* 3.3/5-185, text.data(), text.size(), GLUT_BITMAP_HELVETICA_18, 1.0, 1.0, 1.0);
	text = "70";
	drawer.text(VW- VW* 3/4- 10, VH* 3.3/5-95, text.data(), text.size(), GLUT_BITMAP_TIMES_ROMAN_24, 94/255.0, 215/255.0, 179/255.0);
	text = "km/h";
	drawer.text(VW- VW* 3/4- 15, VH* 3.3/5-65, text.data(), text.size(), GLUT_BITMAP_HELVETICA_18, 1.0, 1.0, 1.0);
	drawer.quad(VW- VW* 3/4 - 285, VH* 3.5/5 + 10, 35, 10, 94/255.0, 215/255.0, 179/255.0, 94/255.0, 215/255.0, 179/255.0);
	drawer.quad(VW- VW* 3/4 + 250, VH* 3.5/5 + 10, 35, 10, 94/255.0, 215/255.0, 179/255.0, 94/255.0, 215/255.0, 179/255.0);
	drawer.quad(VW- VW* 3/4, 150, 5, 10, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);

	//	Right gauge
	drawer.gauge(VW* 3/4, VH* 3.5/5, 250, 300, 35, -PI, 0, 107/255.0, 154/255.0, 247/255.0);
	drawer.rpmIcon(VW* 3/4 - 60, VH* 3.3/5-190, 20);
	text = "RPM";
	drawer.text(VW* 3/4-10, VH* 3.3/5-185, text.data(), text.size(), GLUT_BITMAP_HELVETICA_18, 1.0, 1.0, 1.0);
	text = "2.5";
	drawer.text(VW* 3/4- 10, VH* 3.3/5-95, text.data(), text.size(), GLUT_BITMAP_TIMES_ROMAN_24, 107/255.0, 154/255.0, 247/255.0);
	text = "x1000";
	drawer.text(VW* 3/4- 18, VH* 3.3/5-65, text.data(), text.size(), GLUT_BITMAP_HELVETICA_18, 1.0, 1.0, 1.0);
	drawer.quad(VW* 3/4 - 285, VH* 3.5/5 + 10, 35, 10, 107/255.0, 154/255.0, 247/255.0, 107/255.0, 154/255.0, 247/255.0);
	drawer.quad(VW* 3/4 + 250, VH* 3.5/5 + 10, 35, 10, 107/255.0, 154/255.0, 247/255.0, 107/255.0, 154/255.0, 247/255.0);	
	drawer.quad(VW* 3/4, 150, 5, 10, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);

	// Divider
	drawer.quad(15, VH - 130, VW-30, 5, .25, .25, .25, .25, .25, .25);
	
	// Oil meter
	drawer.quad(15, VH - 60, VW/4, 30, 190/255.0, 60/255.0, 60/255.0, 1.0, 190/255.0, 115/255.0);
	drawer.quad(15 + VW/8, VH - 76, 5, 10, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
	text = "E";
	drawer.text(15, VH - 76, text.data(), text.size(), GLUT_BITMAP_HELVETICA_12, 1.0, 190/255.0, 115/255.0);	
	text = "F";
	drawer.text(15 + VW/4 - 10, VH - 76, text.data(), text.size(), GLUT_BITMAP_HELVETICA_12, 1.0, 190/255.0, 115/255.0);	
	
	// Odometer
	drawer.quad(VW/2-VW/8, VH - 80, VW/4, 60, .25, .25, .25, .25, .25, .25);
	drawer.quad(VW/2-VW/8+5, VH - 75, VW/4-10, 50, .0,.0,.0,.0,.0,.0);
	text = "290789";
	drawer.text(VW/2- 30, VH - 45, text.data(), text.size(), GLUT_BITMAP_HELVETICA_18, 1.0, 1.0, 1.0);	

	// Proximity
	drawer.quad(VW-15-VW/4, VH - 60, VW/4, 30, 190/255.0, 60/255.0, 60/255.0, 1.0, 190/255.0, 115/255.0);	
	drawer.quad(VW-15-VW/4+ 30, VH - 60, 15, 30, .0, .0, .0, .0, .0, .0);
	drawer.quad(VW-15-VW/4+ 75, VH - 60, 15, 30, .0, .0, .0, .0, .0, .0);
	drawer.quad(VW-15-VW/4+ 120, VH - 60, 15, 30, .0, .0, .0, .0, .0, .0);	
	text = "PROXIMITY";
	drawer.text(VW-85, VH - 76, text.data(), text.size(), GLUT_BITMAP_HELVETICA_12, 1.0, 190/255.0, 115/255.0);		
	
	glLoadIdentity();
	
	glFlush();
	glFinish();
}

int main() {
	glutInitDisplayMode(GLUT_RGB | GLUT_SINGLE);
	glutInitWindowSize(VW, VH);
	glutInitWindowPosition(0, 0);
	glutCreateWindow("0204677 Lim Zhe Yuan - Assignment 1");
	glutDisplayFunc(render);
	glutMainLoop();
	
	return 0;
}
