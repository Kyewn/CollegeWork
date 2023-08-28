#ifndef _WORLD_H_
#define _WORLD_H_
#include "dashboardObject.h"
#include "guardpostObject.h"
#include "treeRand.h"
using namespace std;

class World {
	public:
		DashboardObject drawer = DashboardObject();
		
		World();
		~World();
		void drawDashboard(GLfloat scaleX, GLfloat scaleY, GLfloat translateY,
						GLfloat fuelAngle, GLfloat rpmAngle, GLfloat speedAngle,
						bool isLeftSignalOn, bool isRightSignalOn);
		void drawPerspectivePlane(GLfloat x, GLfloat y, GLfloat width, GLfloat height, GLfloat triWidth);
		void drawTree(GLfloat x, GLfloat y, GLfloat angle, GLfloat length, TreeRand treeRand);
		void drawCloud1();
		void drawCloud2();
		void drawCloud3();
		void drawGuardPost(GLfloat x, GLfloat y, GLfloat length, GLfloat angle);
		void drawZombie(GLfloat x, GLfloat y, GLfloat angle);
		void drawDroplet(GLfloat x, GLfloat y, GLfloat length, GLfloat width);
		void drawText(const char* text, GLint length, GLint x, GLint y, void* font);
		void drawParagraph(GLfloat x, GLfloat y, GLint noOfLines, string lines[], GLfloat lineSpacing);
};
#endif
