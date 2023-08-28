#include "world.h"
#include "treeRand.h"
const int VW = 1280;
const int VH = 720;

World::World() {
	
}

World::~World() {
	
}

void World::drawDashboard(GLfloat scaleX, GLfloat scaleY, GLfloat translateY,
						GLfloat fuelAngle, GLfloat rpmAngle, GLfloat speedAngle,
						bool isLeftSignalOn, bool isRightSignalOn) {
	//Variables
	string text;
	GLfloat fuelCenterx = 850;
	GLfloat fuelCentery = 370;
	GLfloat tempCenterx = 850;
	GLfloat tempCentery = 300;
	GLfloat VW = 1280;
	GLfloat VH = 720;
	
	//Creating Dashboards
	DashboardObject leftSignal = DashboardObject();
	DashboardObject rightSignal = DashboardObject();
	DashboardObject leftCarBase = DashboardObject(VW/2-190,VH/2-25);
	DashboardObject leftCarPointer = DashboardObject((VW/2)-190,(VH/2)-25);
	DashboardObject leftCarMarker = DashboardObject((VW/2)-190,(VH/2)-25);
	DashboardObject rightCarBase = DashboardObject((VW/2)+190,(VH/2)-25);
	DashboardObject fuelCarPointer = DashboardObject(fuelCenterx,fuelCentery);
	DashboardObject fuelCarMarker = DashboardObject(fuelCenterx,fuelCentery);
	DashboardObject tempCarPointer = DashboardObject(tempCenterx,tempCentery);
	DashboardObject tempCarMarker = DashboardObject(tempCenterx,tempCentery);
	DashboardObject middleCarBase = DashboardObject(VW/2,VH/2);
	DashboardObject middleCarPointer = DashboardObject(VW/2,VH/2);
	DashboardObject middleCarMarker = DashboardObject(VW/2,VH/2);

	glTranslatef(VW/2,VH/2+translateY, 0);
	glScalef(scaleX, scaleY, 1);
	glTranslatef(-VW/2+235, -VH/2+75-translateY, 0);
		
	//Render the left and right signal
	glColor3f(0.0f,1.0f,0.0f);
	if (isLeftSignalOn) {
		leftSignal.drawRect(270,405,10,10);
		leftSignal.drawTriangle(270,400,270,420,260,410);
	}
	if (isRightSignalOn) {
		rightSignal.drawRect(520,405,10,10);
		rightSignal.drawTriangle(530,400,530,420,540,410);			
	}
	glTranslatef(-235, -75, 0);
	
	//Create the base of the left meter
	glColor3f(1.0f,0.0f,0.0f);
	leftCarBase.drawRegularPolygon(leftCarBase.x,leftCarBase.y,125,50,0,1,1);
	glColor3f(0.0f,0.0f,0.0f);
	leftCarBase.drawRegularPolygon(leftCarBase.x,leftCarBase.y,120,50,0,1,1);
	
	//Rendering the marker of the left meter
	glTranslatef(VW/2,VH/2+translateY, 0);
	glScalef(scaleX, scaleY, 1);
	glColor3f(0.5f,0.5f,0.5f);
			
	leftCarMarker.translate(-10,-3);
	leftCarMarker.rotate(-90,VW/2-300, VH/2-20);
	leftCarMarker.drawRect(leftCarMarker.x,leftCarMarker.y,20,6);
	
	glLoadIdentity();
	glTranslatef(VW/2,VH/2+translateY, 0);
	glScalef(scaleX, scaleY, 1);
	glTranslatef(-VW/2, -VH/2-translateY, 0);
	for (int i=-110; i>=-270; i-=20){
		glLoadIdentity();
		glTranslatef(VW/2+45,VH/2+translateY-20, 0);
		glScalef(scaleX, scaleY, 1);
		glTranslatef(-VW/2+45, -VH/2-translateY+20, 0);
		
		leftCarMarker.translate(-21,-5);
		leftCarMarker.rotate(360-i-10,VW/2-300, VH/2-20);
		leftCarMarker.drawRect(leftCarMarker.x,leftCarMarker.y,15,4);
		
		glLoadIdentity();
		glTranslatef(VW/2+45,VH/2+translateY-20, 0);
		glScalef(scaleX, scaleY, 1);
		glTranslatef(-VW/2+45, -VH/2-translateY+20, 0);	
		
		leftCarMarker.translate(-16,-5);
		leftCarMarker.rotate(360-i,VW/2-300, VH/2-20);
		leftCarMarker.drawRect(leftCarMarker.x,leftCarMarker.y,20,6);
		
		glLoadIdentity();
		glTranslatef(VW/2,VH/2+translateY, 0);
		glScalef(scaleX, scaleY, 1);
		glTranslatef(-VW/2, -VH/2-translateY, 0);
	}
	
	//Rendering the text of the left meter
	text = "x1000rpm";
	drawText(text.data(),text.size(), VW/4-33, 140,GLUT_BITMAP_9_BY_15);
	
	
	//Rendering the state of gear
	glColor3f(1.0,0.0f,0.0f);
	glTranslatef(250, 70, 0);
	leftCarBase.drawLine(223,185,238,185,4);
	leftCarBase.drawLine(225,185,225,210,4);
	leftCarBase.drawLine(223,210,238,210,4);
	leftCarBase.drawLine(240,187,240,208,4);
	glTranslatef(-250, -70, 0);

	//Rendering the pointer of the left meter
	leftCarPointer.rotate(rpmAngle, leftCarPointer.x,leftCarPointer.y);
	leftCarPointer.drawGradRect(leftCarPointer.x,leftCarPointer.y,113,6);
	glLoadIdentity();
	glTranslatef(VW/2,VH/2+translateY, 0);
	glScalef(scaleX, scaleY, 1);
	glTranslatef(-VW/2, -VH/2-translateY, 0);
	glColor3f(0.5f,0.5f,0.5f);
	leftCarBase.drawRegularPolygon(leftCarBase.x,leftCarBase.y,23,50,0,1,1);
	
	//Create the base of the right meter
	glColor3f(1.0f,0.0f,0.0f);
	rightCarBase.drawRegularPolygon(rightCarBase.x,rightCarBase.y,125,50,0,1,1);
	glColor3f(0.0f,0.0f,0.0f);
	rightCarBase.drawRegularPolygon(rightCarBase.x,rightCarBase.y,120,50,0,1,1);
	
	//Rendering the marker of the fuel meter
	glColor3f(0.5f,0.5f,0.5f);
	fuelCarMarker.translate(55,-3);
	fuelCarMarker.rotate(30,fuelCenterx,fuelCentery);
	fuelCarMarker.drawRect(fuelCarMarker.x,fuelCarMarker.y,15,6);
	glLoadIdentity();
	glTranslatef(VW/2,VH/2+translateY, 0);
	glScalef(scaleX, scaleY, 1);
	glTranslatef(-VW/2, -VH/2-translateY, 0);
	for (int i=90; i<=150; i+=60){
		fuelCarMarker.translate(-10,-5);
		fuelCarMarker.rotate(i-30,fuelCenterx,fuelCentery);
		fuelCarMarker.drawRect(fuelCarMarker.x,fuelCarMarker.y,10,4);
		glLoadIdentity();
		glTranslatef(VW/2,VH/2+translateY, 0);
		glScalef(scaleX, scaleY, 1);
		glTranslatef(-VW/2, -VH/2-translateY, 0);
		fuelCarMarker.translate(-15,-5);
		fuelCarMarker.rotate(i,fuelCenterx,fuelCentery);
		fuelCarMarker.drawRect(fuelCarMarker.x,fuelCarMarker.y,15,6);
		glLoadIdentity();
		glTranslatef(VW/2,VH/2+translateY, 0);
		glScalef(scaleX, scaleY, 1);
		glTranslatef(-VW/2, -VH/2-translateY, 0);
	}
	
	//Rendering the marker of the temperature meter
	tempCarMarker.translate(55,-3);
	tempCarMarker.rotate(-150,tempCenterx,tempCentery);
	tempCarMarker.drawRect(tempCarMarker.x,tempCarMarker.y,15,6);
	glLoadIdentity();
	glTranslatef(VW/2,VH/2+translateY, 0);
	glScalef(scaleX, scaleY, 1);
	glTranslatef(-VW/2, -VH/2-translateY, 0);
	for (int i=-90; i<=-30; i+=60){
		tempCarMarker.translate(-10,-5);
		tempCarMarker.rotate(i-30,tempCenterx,tempCentery);
		tempCarMarker.drawRect(tempCarMarker.x,tempCarMarker.y,10,4);
		glLoadIdentity();
		glTranslatef(VW/2,VH/2+translateY, 0);
		glScalef(scaleX, scaleY, 1);
		glTranslatef(-VW/2, -VH/2-translateY, 0);
		tempCarMarker.translate(-15,-5);
		tempCarMarker.rotate(i,tempCenterx,tempCentery);
		tempCarMarker.drawRect(tempCarMarker.x,tempCarMarker.y,15,6);
		glLoadIdentity();
		glTranslatef(VW/2,VH/2+translateY, 0);
		glScalef(scaleX, scaleY, 1);
		glTranslatef(-VW/2, -VH/2-translateY, 0);
	}
	
	
	//Rendering the text of the right meter
	text = "fuel";
	drawText(text.data(),text.size(),VW/2-120, 120,GLUT_BITMAP_8_BY_13);
	text = "temp(°C)";
	drawText(text.data(),text.size(),VW/2-130, 80,GLUT_BITMAP_8_BY_13);

	//Rendering the pointer of the fuel meter
	fuelCarPointer.translate(0,-3);
	fuelCarPointer.rotate(fuelAngle,fuelCenterx,fuelCentery);
	fuelCarPointer.drawGradRect(fuelCarPointer.x,fuelCarPointer.y,70,6);
	glLoadIdentity();
	glTranslatef(VW/2,VH/2+translateY, 0);
	glScalef(scaleX, scaleY, 1);
	glTranslatef(-VW/2, -VH/2-translateY, 0);
	glColor3f(0.5f,0.5f,0.5f);
	rightCarBase.drawRegularPolygon(fuelCenterx,fuelCentery,15,45,0,1,1);
	
	//Rendering the pointer of the temperature meter
	tempCarPointer.translate(0,-3);
	tempCarPointer.rotate(-105,tempCenterx,tempCentery);
	tempCarPointer.drawGradRect(tempCarPointer.x,tempCarPointer.y,70,6);
	glLoadIdentity();
	glTranslatef(VW/2,VH/2+translateY, 0);
	glScalef(scaleX, scaleY, 1);
	glTranslatef(-VW/2, -VH/2-translateY, 0);	
	glColor3f(0.5f,0.5f,0.5f);
	rightCarBase.drawRegularPolygon(tempCenterx,tempCentery,15,45,0,1,1);
	
	//Create the base of the middle meter
	glColor3f(1.0f,0.0f,0.0f);
	middleCarBase.drawRegularPolygon(middleCarBase.x,middleCarBase.y,150,50,0,1,1);
	glColor3f(0.0f,0.0f,0.0f);
	middleCarBase.drawRegularPolygon(middleCarBase.x,middleCarBase.y,145,50,0,1,1);
	
	//Rendering the marker of the middle meter
	glColor3f(0.5f,0.5f,0.5f);
	middleCarMarker.translate(108,-4);
	middleCarMarker.rotate(-20,VW/2,VH/2);
	middleCarMarker.drawRect(middleCarMarker.x,middleCarMarker.y,25,8);
	glLoadIdentity();
	glTranslatef(VW/2,VH/2+translateY, 0);
	glScalef(scaleX, scaleY, 1);
	for (int i=0; i<=200; i+=20){
		glLoadIdentity();
		glTranslatef(VW/2,VH/2+translateY, 0);
		glScalef(scaleX, scaleY, 1);
		glTranslatef(-VW/2, -VH/2-translateY, 0);
		middleCarMarker.translate(-20,-6);
		middleCarMarker.rotate(i-10,VW/2,VH/2);
		middleCarMarker.drawRect(middleCarMarker.x,middleCarMarker.y,20,4);
		glLoadIdentity();
		glTranslatef(VW/2,VH/2+translateY, 0);
		glScalef(scaleX, scaleY, 1);
		glTranslatef(-VW/2, -VH/2-translateY, 0);
		middleCarMarker.translate(-25,-6);
		middleCarMarker.rotate(i,VW/2,VH/2);
		middleCarMarker.drawRect(middleCarMarker.x,middleCarMarker.y,25,8);
		glLoadIdentity();
		glTranslatef(VW/2,VH/2+translateY, 0);
		glScalef(scaleX, scaleY, 1);
		glTranslatef(-VW/2, -VH/2-translateY, 0);
	}
	
	text = "Speed";
	drawText(text.data(),text.size(), VW/4+68, 50, GLUT_BITMAP_9_BY_15);
	
	//Rendering the pointer of the middle meter
	middleCarPointer.translate(0,-4);
	middleCarPointer.rotate(speedAngle,VW/2,VH/2);
	middleCarPointer.drawGradRect(middleCarPointer.x,middleCarPointer.y,133,8);
	glLoadIdentity();
	glTranslatef(VW/2,VH/2+translateY, 0);
	glScalef(scaleX, scaleY, 1);
	glTranslatef(-VW/2, -VH/2-translateY, 0);
	glColor3f(0.5f,0.5f,0.5f);
	middleCarBase.drawRegularPolygon(middleCarBase.x,middleCarBase.y,30,50,0,1,1);
}

void World::drawPerspectivePlane(GLfloat x, GLfloat y, GLfloat width, GLfloat height, GLfloat triWidth) {
	this->drawer.drawRect(x, y, width, height);
	this->drawer.drawTriangle(x, y, x, y + height, x - triWidth, y);
	this->drawer.drawTriangle(x + width, y, x + width, y + height, x + width + triWidth, y);
} 

void World::drawTree(GLfloat x, GLfloat y, GLfloat angle, GLfloat length, TreeRand treeRand) {
   if(length < 10) {
      return;
   }

   // Draw the trunk of the tree
   glLineWidth(length/10);
   glColor3f(0.5, 0.3, 0.1);
   glBegin(GL_LINES);
      glVertex2f(x, y);
      glVertex2f(x + length*cos(angle), y + length*sin(angle));
   glEnd();
		
   // Draw the branches of the tree
   float leftAngle = angle + (M_PI/6 + (treeRand.leftAngleRand/RAND_MAX - 0.5)/4);
   float rightAngle = angle - (M_PI/8 + (treeRand.rightAngleRand/RAND_MAX - 0.5)/4);
   float lowerLeftAngle = angle + (M_PI/2 + (treeRand.lowerLeftAngleRand/RAND_MAX - 0.5)/4);
   float lowerRightAngle = angle - (M_PI/4 + (treeRand.lowerRightAngleRand/RAND_MAX - 0.5)/4);
   float branchLength = length/2 + (treeRand.branchLengthRand/RAND_MAX - 0.5)*length/4;

   drawTree(x + length*cos(angle), y + length*sin(angle), leftAngle, branchLength, treeRand);
   drawTree(x + length*cos(angle), y + length*sin(angle), rightAngle, branchLength, treeRand);
   drawTree(x + length*cos(angle), y + length*sin(angle), lowerLeftAngle, branchLength, treeRand);
   drawTree(x + length*cos(angle), y + length*sin(angle), lowerRightAngle, branchLength, treeRand);
}

void World::drawCloud1() {
	glPushMatrix();
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(565,385,28,50,0,1,1);
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(600,400,39,50,0,1,1);
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(650,400,46,50,0,1,1);
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(700,400,42,50,0,1,1);
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(740,390,25,50,0,1,1);
		
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(550,350,46,50,0,1,1);
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(600,350,30,50,0,1,1);
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(650,350,29,50,0,1,1);
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(700,350,30,50,0,1,1);
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(750,350,44,50,0,1,1);
		
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(565,300,32,50,0,1,1);
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(600,300,45,50,0,1,1);
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(650,300,47,50,0,1,1);
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(700,300,37,50,0,1,1);
		glColor3f(1.0f,1.0f,1.0f);
		drawer.drawRegularPolygon(730,305,29,50,0,1,1);
	glPopMatrix();
}

void World::drawCloud2() {
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(550,400,37,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(600,400,48,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(650,400,34,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(700,400,45,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(750,400,41,50,0,1,1);
	
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(550,350,35,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(600,350,50,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(650,350,50,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(700,350,35,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(750,350,31,50,0,1,1);
	
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(550,300,47,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(600,300,42,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(650,300,27,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(700,300,32,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(750,300,39,50,0,1,1);
}

void World::drawCloud3() {
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(600,400,42,50,0,1,1);

	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(575,350,35,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(625,350,39,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(675,350,33,50,0,1,1);
	
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(550,300,49,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(600,300,39,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(650,300,45,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(700,300,40,50,0,1,1);
	glColor3f(1.0f,1.0f,1.0f);
	drawer.drawRegularPolygon(750,300,39,50,0,1,1);
}

void World::drawGuardPost(GLfloat x, GLfloat y, GLfloat length, GLfloat angle) {
	//Creating Guard Post Objects
	GuardpostObject guardPostBuilding = GuardpostObject(x-(length/2)-50,y);
	GuardpostObject guardPostGlass = GuardpostObject(x-(length/2)-40,y+75);
	GuardpostObject guardPostBeam = GuardpostObject(x-(length/2),y+75);
	
	//Render the beam and making it movable
	glColor3f(1.0f,0.0f,0.0f);
	guardPostBeam.rotate(angle,guardPostBeam.x,guardPostBeam.y);
	guardPostBeam.drawLine(guardPostBeam.x,guardPostBeam.y,x+(length/2),y+75,10);
	glLoadIdentity();
	
	//Rendering the building and the glass
	glColor3f(0.5f,0.5f,0.5f);
	guardPostBuilding.drawRect(guardPostBuilding.x,guardPostBuilding.y,100,150);
	glColor3f(0.5f,0.8f,0.9f);
	guardPostGlass.drawGradRect(guardPostGlass.x,guardPostGlass.y,80,60);
}

void World::drawZombie(GLfloat x, GLfloat y, GLfloat angle) {
	//Zombie body
	glColor3f(0.0f, 0.4f, 0.0f); // Dark Green colour
	drawer.drawQuad(x+0, y+200, x+0, y+0, x+150, y+0, x+150, y+200); // Rectangle
	glColor3f(1.0f, 0.0f, 0.0f); // Red colour
	drawer.drawLine(x+25, y+180, x+25, y+170, 10.0); // Line
	drawer.drawLine(x+45, y+160, x+45, y+150, 10.0); // Line
	drawer.drawLine(x+100, y+150, x+100, y+90, 10.0); // Line	
	drawer.drawLine(x+90, y+70, x+90, y+40, 30.0); // Line
	drawer.drawLine(x+120, y+60, x+120, y+10, 30.0); // Line
	
	//Zombie head
	glColor3f(0.3f, 0.2f, 0.2f); // Brown colour
	drawer.drawQuad(x+20, y+300, x+20, y+200, x+130, y+200, x+130, y+300); // Rectangle
	glColor3f(1.0f, 0.0f, 0.0f); // Red colour
	drawer.drawQuad(x+40, y+280, x+40, y+260, x+50, y+260, x+50, y+280); // Eyes
	drawer.drawQuad(x+100, y+280, x+100, y+260, x+110, y+260, x+110, y+280); // Eyes
	glColor3f(0.0f, 0.0f, 0.0f); // Black colour
	drawer.drawQuad(x+50, y+240, x+50, y+230, x+100, y+230, x+100, y+240); // Mouth
	drawer.drawQuad(x+40, y+230, x+40, y+210, x+110, y+210, x+110, y+230); // Mouth
	glColor3f(1.0f, 0.0f, 0.0f); // Red colour
	drawer.drawLine(x+60, y+240, x+60, y+200, 5.0); // Line
	drawer.drawLine(x+50, y+240, x+50, y+230, 5.0); // Line
	drawer.drawLine(x+100, y+230, x+100, y+210, 5.0); // Line
	drawer.drawLine(x+80, y+210, x+90, y+190, 5.0); // Line
	
	//Zombie arms	
	glColor3f(0.3f, 0.2f, 0.2f); // Brown colour
	drawer.drawQuad(x-50, y+200, x-50, y+80, x+0, y+80, x+0, y+200); // Arm
	drawer.drawQuad(x+150, y+200, x+150, y+0, x+200, y+0, x+200, y+200); // Arm
	glColor3f(0.0f, 0.4f, 0.0f); // Dark Green colour
	drawer.drawQuad(x-50, y+200, x-50, y+130, x+0, y+130, x+0, y+200); // Sleeve
	drawer.drawQuad(x+150, y+200, x+150, y+130, x+200, y+130, x+200, y+200); // Sleeve
	glColor3f(1.0f, 1.0f, 1.0f); // White colour
	drawer.drawQuad(x-35, y+80, x-35, y+30, x-15, y+30, x-15, y+80); // Arm
	glColor3f(1.0f, 0.0f, 0.0f); // Red colour
	drawer.drawLine(x-31, y+80, x-31, y+40, 3.0); // Line
	drawer.drawLine(x-18, y+80, x-18, y+60, 3.0); // Line
	
	//Zombie legs
	glColor3f(0.0f, 0.5f, 0.5f);//Blue-Green
	drawer.drawQuad(x+0, y-200, x+0, y+0, x+150, y+0, x+150, y-200); // Rectangle
	glColor3f(0.3f, 0.2f, 0.2f); // Brown colour
	drawer.drawQuad(x+75, y-80, x+75, y-200, x+150, y-200, x+150, y-80); // Leg exposed
	glColor3f(0.0f, 0.0f, 0.0f); // Black colour
	drawer.drawLine(x+75, y-50, x+75, y-200, 2.0); // Line
	glColor3f(1.0f, 0.0f, 0.0f); // Red colour
	drawer.drawLine(x+105, y-100, x+105, y-110, 45.0); // Line
	drawer.drawLine(x+90, y-100, x+90, y-180, 5.0); // Line
	drawer.drawLine(x+110, y-100, x+110, y-140, 5.0); // Line	
}

void World::drawDroplet(GLfloat x, GLfloat y, GLfloat length, GLfloat width) {
	glPushMatrix();
		glColor3f(0, 0, 1);
		drawer.drawTriangle(x, y, x-width/2, y+length, x+width/2, y+length);
		drawer.drawRegularPolygon(x, y+length, width/2, 69, 0, 1, 1);
		glColor3f(1, 1, 1);
		drawer.drawRegularPolygon(x+width/6, y+length, width/5, 69, 0, 1, 1);
	glPopMatrix();
}

void World::drawText(const char* text, GLint length, GLint x, GLint y, void* font){
	glPushMatrix();
	glMatrixMode(GL_PROJECTION);
	double* matrix = new double[16];
	glGetDoublev(GL_PROJECTION_MATRIX,matrix);
	glLoadIdentity();
	glOrtho(0,800,0,600,-5,5);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	glPushMatrix();
		glLoadIdentity();
		glRasterPos2i(x, y);
		for(int i=0; i<length; i++){
			glutBitmapCharacter(font,(int)text[i]);
		}
	glPopMatrix();
	glMatrixMode(GL_PROJECTION);
	glLoadMatrixd(matrix);
	glMatrixMode(GL_MODELVIEW);
	glPopMatrix();		
}

void World::drawParagraph(GLfloat x, GLfloat y, GLint noOfLines, string lines[], GLfloat lineSpacing) {
	GLfloat yPos = y;
	glPushMatrix();
	for (int i = 0; i<noOfLines; i++) {
		this->drawText(lines[i].data(), lines[i].size(), x, yPos, GLUT_BITMAP_HELVETICA_18);
		yPos -= lineSpacing;
	}
	glPopMatrix();
}
