//Import packages
#include <windows.h>
#include <gl/glut.h>
#include <string>
#include <sstream>
#include <vector>
#include "world.h"
#include "treeRand.h"
using namespace std; //Using the standard library

World world = World();
DashboardObject drawer = DashboardObject();
const GLfloat VW = 1280;
const GLfloat VH = 720;

// World settings
const GLfloat skyHeight = 200;
const GLfloat surfaceHeight = 300;
const GLfloat dashboardHeight = VH-skyHeight-surfaceHeight;	

// Road settings
const GLfloat topMarkerScaleConst = 1.0;
const GLfloat midMarkerScaleConst = 2.5;
const GLfloat btmMarkerScaleConst = 2.5;
const GLfloat scaleIncrement = 0.3;
const GLfloat scaleDecrement = 0.1;
const GLfloat maxScaleSpeed = 0.69;

const GLfloat turnScaleIncrement = 1.0;

const GLfloat roadXOrigin = (VW-(VW-VW/2))/2;
const GLfloat roadYOrigin = VH-skyHeight-surfaceHeight;
const GLfloat markerXOrigin = -3;
const GLfloat markerYOrigin = -40;

const GLfloat roadWidth = VW-VW/2;
const GLfloat markerWidth = 6;
const GLfloat markerHeight = 10;
const GLfloat roadTriangleWidth = VW - (VW-300);
const GLfloat markerTriangleWidth = 2;
	
GLfloat topMarkerScale = topMarkerScaleConst;
GLfloat midMarkerScale = midMarkerScaleConst;
GLfloat btmMarkerScale = btmMarkerScaleConst;
GLfloat scaleSpeed = 0;

// Tree settings
TreeRand straightLeftTreeRand = TreeRand();
TreeRand straightRightTreeRand = TreeRand();
const GLfloat maxTreeScaleFactor = 7.0;

const GLfloat straightLeftTreeXOrigin = roadXOrigin - roadTriangleWidth/2;
const GLfloat straightLeftTreeYOrigin = dashboardHeight + surfaceHeight;
const GLfloat farViewTreeScaleConst = 1.0;
GLfloat straightLeftTreeScaleX = farViewTreeScaleConst;
GLfloat straightLeftTreeScaleY = farViewTreeScaleConst;

const GLfloat straightRightTreeXOrigin = roadXOrigin + roadWidth + roadTriangleWidth/2;
const GLfloat straightRightTreeYOrigin = dashboardHeight + surfaceHeight;
GLfloat straightRightTreeScaleX = farViewTreeScaleConst + 3.0;
GLfloat straightRightTreeScaleY = farViewTreeScaleConst + 3.0;

// Dashboard settings
const GLfloat emptyFuelAngle = 150;
const GLfloat fullFuelAngle = 30;
GLfloat fuelAngle = fullFuelAngle;
GLfloat fuelDecrement = 0.5;

const GLfloat noSpeedAngle = -160;
const GLfloat maxSpeedAngle = -300;
GLfloat speedAngle = noSpeedAngle;
GLfloat speedIncrement = 25.5;
GLfloat speedDecrement = 20.5;

const GLfloat noRpmAngle = -90;
const GLfloat maxRpmAngle = -205;
GLfloat rpmAngle = noRpmAngle;
GLfloat rpmIncrement = 10.5;
GLfloat rpmDecrement = 20.5;

bool isLeftSignalOn = false;
bool isRightSignalOn = false;

// Game settings
bool isShowStraightScene = true;
bool isShowLeftScene = false;
bool isShowRightScene = false;
bool isShowMutantScene = false;
bool isShowGuardPostScene = false;
bool isShowInitOverlay = true;
bool isShowGameOverOverlay = false;
bool isShowSuccessOverlay = false;
bool isShowActionOverlay = false;

const GLint turningSceneFrameCount = 7;
GLint turningSceneFrame = 0;
const GLint resultSceneFrameCount = 25;
GLint resultSceneFrame = 0;

const GLfloat distanceGoal = 16;
GLfloat distanceTravelled = 0;
bool isAccelerating = false;

const int combinationCount = 4;
const char combinationArr[] = {
	'l', 'r', 'l', 'r',
};
vector<char> userCombination(combinationCount);
int currentCount = 0;

// Guard Post settings
const GLfloat closedGpAngle = 0;
const GLfloat openGpAngle = 60;
GLfloat GpAngle = closedGpAngle;

template <typename T>
string ToString(T val)
{
    stringstream stream;
    stream << val;
    return stream.str();
}

//	Mutant settings
const GLfloat initMutantScale = 0.3;
const GLfloat mutantScaleSpeed = 0.05;
GLfloat mutantScale = initMutantScale;

void resetStraightRoadSceneVars(){
	//	Road markers
	topMarkerScale = topMarkerScaleConst;
	midMarkerScale = midMarkerScaleConst;
	btmMarkerScale = btmMarkerScaleConst;
	
	// Trees
	straightLeftTreeScaleX = farViewTreeScaleConst;
	straightLeftTreeScaleY = farViewTreeScaleConst;
	straightRightTreeScaleX = farViewTreeScaleConst + 3.0;
	straightRightTreeScaleY = farViewTreeScaleConst + 3.0;
	
	// Game
	distanceTravelled = 0;
}

void resetGame() {
	resetStraightRoadSceneVars();
	
	fuelAngle = fullFuelAngle;
	fuelDecrement = 0.5;
	scaleSpeed = 0;
	
	speedAngle = noSpeedAngle;
	speedIncrement = 25.5;
	speedDecrement = 20.5;
	
	rpmAngle = noRpmAngle;
	rpmIncrement = 10.5;
	rpmDecrement = 20.5;
	
	isShowStraightScene = true;
	isShowLeftScene = false;
	isShowRightScene = false;
	isShowMutantScene = false;
	isShowGuardPostScene = false;
	isShowInitOverlay = true;
	isShowGameOverOverlay = false;
	isShowSuccessOverlay = false;
	isShowActionOverlay = false;
	
	userCombination.clear();
	currentCount = 0;

	GpAngle = closedGpAngle;
	mutantScale = initMutantScale;
}

void checkCombinationOnComplete() {
	for (int i = 0; i < combinationCount; i++) {
		if (combinationArr[i] != userCombination.at(i)) {	
			isShowMutantScene = true;
		}
	}
	isShowGuardPostScene = true;
	isShowStraightScene = false;
}

void drawStraightRoadScene() {
	// == Logic ==
	// Distance goal
	if (distanceTravelled >= distanceGoal) {
		isShowActionOverlay = true;
	} else {
		isShowActionOverlay = false;
	}
	
	// Road scaling animation
	if (topMarkerScale <= midMarkerScaleConst) {
		GLfloat midTopScaleDiff = midMarkerScaleConst;
		GLfloat midBtmScaleDiff = btmMarkerScaleConst;
		GLfloat midTopSteps = midTopScaleDiff;
		GLfloat midBtmSteps = midBtmScaleDiff / midTopScaleDiff;
		
		topMarkerScale += scaleSpeed;
		midMarkerScale += scaleSpeed / midTopSteps;
		btmMarkerScale += scaleSpeed / midBtmSteps;
	} else {
		topMarkerScale = topMarkerScaleConst;
		midMarkerScale = midMarkerScaleConst;
		btmMarkerScale = btmMarkerScaleConst;
	}
	
	// Tree scaling animation
	if (straightLeftTreeScaleX <= maxTreeScaleFactor) {
		straightLeftTreeScaleX += scaleSpeed;
		straightLeftTreeScaleY += scaleSpeed;
	} else {
		straightLeftTreeScaleX = farViewTreeScaleConst;
		straightLeftTreeScaleY = farViewTreeScaleConst;
		straightLeftTreeRand = TreeRand();
	}	
	
	if (straightRightTreeScaleX <= maxTreeScaleFactor) {
		straightRightTreeScaleX += scaleSpeed;
		straightRightTreeScaleY += scaleSpeed;
	} else {
		straightRightTreeScaleX = farViewTreeScaleConst;
		straightRightTreeScaleY = farViewTreeScaleConst;
		straightRightTreeRand = TreeRand();
	}		
	
	// Fuel animation
	if (!isShowInitOverlay)	{
		if (fuelAngle < emptyFuelAngle) {
			fuelAngle += fuelDecrement;
		} else {
			fuelAngle = emptyFuelAngle;
		}
	}

	if (fuelAngle == emptyFuelAngle) {
		isShowStraightScene = false;
		isShowMutantScene = true;
	}
	
	// == Drawing ==	
	// Sky
	glPushMatrix();
		glColor3f(.75, 0.5, 0);
		drawer.drawRect(0, VH-skyHeight, VW, skyHeight);
	glPopMatrix();
	
	// Clouds
	glPushMatrix();
		glTranslatef(VW/2, VH/2, 0);	
		glScalef(0.5, 0.5, 1);
		glTranslatef(-VW/2, -VH/2, 0);
		glTranslatef(-1200, 670, 0);				
		world.drawCloud1();	
				
		glLoadIdentity();
		
		glTranslatef(VW/2, VH/2, 0);
		glScalef(1.5, 1.5, 1);
		glTranslatef(-VW/2, -VH/2, 0);		
		glTranslatef(270, 245, 0);
		world.drawCloud2();	
	
		glLoadIdentity();
		
		glTranslatef(VW/2, VH/2, 0);
		glScalef(1.25, 1.25, 1);
		glTranslatef(-VW/2, -VH/2, 0);
		glTranslatef(-200, 250, 0);		
		world.drawCloud3();													
	glPopMatrix();

	// Sidewalk
	glPushMatrix();
		glColor3f(0.505882352941176, 0.113725490196078, 0);
		drawer.drawRect(0, VH-skyHeight-surfaceHeight, VW, surfaceHeight);
	glPopMatrix();
		
	// Road
	glPushMatrix(); 						
		glColor3f(0.2, 0.2, 0.2);
		world.drawPerspectivePlane(roadXOrigin, roadYOrigin, roadWidth, surfaceHeight, roadTriangleWidth);

		glPushMatrix();		
			// Road markers
			glColor3f(1.0, 1.0, 1.0);
			glTranslatef(VW/2, VH-skyHeight, 0);
			glScalef(1.0, topMarkerScale, 1.0);
			world.drawPerspectivePlane(markerXOrigin, markerYOrigin, markerWidth, markerHeight, markerTriangleWidth);

			glScalef(1.0, midMarkerScale, 1.0);
			world.drawPerspectivePlane(markerXOrigin, markerYOrigin, markerWidth, markerHeight, markerTriangleWidth);
			
			glScalef(1.0, btmMarkerScale, 1.0);
			world.drawPerspectivePlane(markerXOrigin, markerYOrigin, markerWidth, markerHeight, markerTriangleWidth);
		glPopMatrix();
	glPopMatrix();
	
	// Trees
	glPushMatrix();
		glTranslatef(straightLeftTreeXOrigin + 200, VH, 0.0);
		glScalef(straightLeftTreeScaleX, straightLeftTreeScaleY, 1.0);
		world.drawTree(-200, straightLeftTreeYOrigin - VH, M_PI/2, 120, straightLeftTreeRand);
		glLoadIdentity();

		glTranslatef(straightRightTreeXOrigin - 200, VH, 0.0);
		glScalef(straightRightTreeScaleX, straightRightTreeScaleY, 1.0);		
		world.drawTree(200, straightRightTreeYOrigin - VH, M_PI/2, 120, straightRightTreeRand);
	glPopMatrix();	
	
	// Dashboard                          
	glPushMatrix();
		glColor3f(0, 0, 0);
		// Additional overhead dashboard cover
		drawer.drawTriangle(VW/2-300, VH-skyHeight-surfaceHeight, VW/2-250,VH-skyHeight-surfaceHeight, VW/2-250, VH-skyHeight-surfaceHeight+50);
		drawer.drawRect(VW/2-250, VH-skyHeight-surfaceHeight, (VW/2+250)-(VW/2-250), 50);
		drawer.drawTriangle(VW/2+250, VH-skyHeight-surfaceHeight, VW/2+250, VH-skyHeight-surfaceHeight+50, VW/2+300,VH-skyHeight-surfaceHeight);
		
		// Draw background cover
		drawer.drawRect(0, VH-skyHeight-surfaceHeight-dashboardHeight, VW, dashboardHeight);
		
		// Main dashboard object
		world.drawDashboard(0.75, 0.75, -900, fuelAngle, rpmAngle, speedAngle, isLeftSignalOn, isRightSignalOn);
	glPopMatrix();

	// Distance goal
	if (!isShowInitOverlay) {
		string distanceGoalTitle = "Distance goal";
		string distanceGoalContent = ToString(distanceTravelled) + " / " + ToString(distanceGoal);
		glPushMatrix();
			glColor4f(0, 0, 0, 0.7);
			drawer.drawRect(VW-200, VH-120, 180, 100);
			glColor3f(1, 1, 1);
			world.drawText(distanceGoalTitle.data(), distanceGoalTitle.size(), VW-590, VH-170, GLUT_BITMAP_HELVETICA_18);
			if (distanceTravelled > distanceGoal) {
				glColor3f(0, 1.0, .2);	
			} else {
				glColor3f(1.0, 0, .2);
			}
			world.drawText(distanceGoalContent.data(), distanceGoalContent.size(), VW-590, VH-195, GLUT_BITMAP_HELVETICA_18);
		glPopMatrix();
	}
	
	// == Postprocessing ==
	// Release increments if relevant key is released
	scaleSpeed -= scaleDecrement;
	if (scaleSpeed < 0) {
		scaleSpeed = 0;
	}			

	if (!isAccelerating) {
		rpmAngle += rpmDecrement;
		if (rpmAngle > noRpmAngle) {
			rpmAngle = noRpmAngle;
		}		
	}

	if (!isAccelerating) {
		speedAngle += speedDecrement;
		if (speedAngle > noSpeedAngle) {
			speedAngle = noSpeedAngle;
		}		
	}

	isAccelerating = false;
}

void drawLeftRoadScene() {
	// Tree scaling animation
	if (straightLeftTreeScaleX <= maxTreeScaleFactor) {
		straightLeftTreeScaleX += turnScaleIncrement;
		straightLeftTreeScaleY += turnScaleIncrement;
	} else {
		straightLeftTreeScaleX = farViewTreeScaleConst;
		straightLeftTreeScaleY = farViewTreeScaleConst;
		straightLeftTreeRand = TreeRand();
	}	
	
	if (straightRightTreeScaleX <= maxTreeScaleFactor) {
		straightRightTreeScaleX += turnScaleIncrement;
		straightRightTreeScaleY += turnScaleIncrement;
	} else {
		straightRightTreeScaleX = farViewTreeScaleConst;
		straightRightTreeScaleY = farViewTreeScaleConst;
		straightRightTreeRand = TreeRand();
	}		
	
	// Fuel animation
	if (!isShowInitOverlay)	{
		if (fuelAngle < emptyFuelAngle) {
			fuelAngle += fuelDecrement;
		} else {
			fuelAngle = emptyFuelAngle;
		}
	}

	if (fuelAngle == emptyFuelAngle) {
		isShowStraightScene = false;
		isShowMutantScene = true;
	}
	
	if (turningSceneFrame % 2 == 1) {
		isLeftSignalOn = true;
	} else {
		isLeftSignalOn = false;	
	}
	
	glPushMatrix();
		glTranslatef(VW/2, VH/2, 0);
		glRotatef(10, 0, 0, 1.0);
		glTranslatef(-VW/2, -VH/2, 0);
		// == Drawing ==
		// Sky
		glPushMatrix();
			glColor3f(.75, 0.5, 0);
			drawer.drawRect(0, VH-skyHeight, VW+200, skyHeight+200);
		glPopMatrix();
		
		// Clouds
		glPushMatrix();
			glTranslatef(VW/2, VH/2, 0);	
			glScalef(0.5, 0.5, 1);
			glTranslatef(-VW/2, -VH/2, 0);
			glTranslatef(-1200, 670, 0);				
			world.drawCloud1();	
					
			glLoadIdentity();
			
			glTranslatef(VW/2, VH/2, 0);
			glScalef(1.5, 1.5, 1);
			glTranslatef(-VW/2, -VH/2, 0);		
			glTranslatef(270, 245, 0);
			world.drawCloud2();	
		
			glLoadIdentity();
			
			glTranslatef(VW/2, VH/2, 0);
			glScalef(1.25, 1.25, 1);
			glTranslatef(-VW/2, -VH/2, 0);
			glTranslatef(-200, 250, 0);		
			world.drawCloud3();													
		glPopMatrix();
	
		// Sidewalk
		glPushMatrix();
			glColor3f(0.505882352941176, 0.113725490196078, 0);
			drawer.drawRect(0, VH-skyHeight-surfaceHeight-400, VW+200, surfaceHeight+400);
		glPopMatrix();
			
		// Road
		glPushMatrix(); 						
			glColor3f(0.2, 0.2, 0.2);
			drawer.drawRegularPolygon(VW/2, 0, VH-skyHeight, 69, 0, 1, 1);
			drawer.drawRect(0,0, VW/2, VH-skyHeight);
			glColor3f(0.505882352941176, 0.113725490196078, 0);
			drawer.drawRegularPolygon(0, 0, VH-skyHeight, 69, 0, 1, 1);
		glPopMatrix();
		
		// Trees
		glPushMatrix();
			glTranslatef(straightLeftTreeXOrigin-150, VH, 0.0);
			glScalef(straightLeftTreeScaleX, straightLeftTreeScaleY, 1.0);
			world.drawTree(-75, straightLeftTreeYOrigin - VH, M_PI/2, 120, straightLeftTreeRand);
			glLoadIdentity();
	
			glTranslatef(straightRightTreeXOrigin - 200, VH, 0.0);
			glScalef(straightRightTreeScaleX, straightRightTreeScaleY, 1.0);		
			world.drawTree(200, straightRightTreeYOrigin - VH, M_PI/2, 120, straightRightTreeRand);
		glPopMatrix();	
	glPopMatrix();	
		
	// Dashboard
	glPushMatrix();
		glColor3f(0, 0, 0);
		// Additional overhead dashboard cover
		drawer.drawTriangle(VW/2-300, VH-skyHeight-surfaceHeight, VW/2-250,VH-skyHeight-surfaceHeight, VW/2-250, VH-skyHeight-surfaceHeight+50);
		drawer.drawRect(VW/2-250, VH-skyHeight-surfaceHeight, (VW/2+250)-(VW/2-250), 50);
		drawer.drawTriangle(VW/2+250, VH-skyHeight-surfaceHeight, VW/2+250, VH-skyHeight-surfaceHeight+50, VW/2+300,VH-skyHeight-surfaceHeight);
		
		// Draw background cover
		drawer.drawRect(0, VH-skyHeight-surfaceHeight-dashboardHeight, VW, dashboardHeight);
		
		// Main dashboard object
		world.drawDashboard(0.75, 0.75, -900, fuelAngle, rpmAngle, speedAngle, isLeftSignalOn, isRightSignalOn);
	glPopMatrix();
	
	// Sweat droplets
	GLfloat dropletAngle1 = -20;
	GLfloat dropletAngle2 = -28;
	glPushMatrix();
		glTranslatef(VW*3/4 + 100, VH*1.1/4, 0);
		glRotatef(dropletAngle1, 0, 0 , 1);
		world.drawDroplet(0, 0, 65, 35);
		glTranslatef(-1 * (VW*3/4 + 100), 0, 0);
		glTranslatef(VW*3.1/4 + 100, 0, 0);
		glRotatef(dropletAngle2, 0, 0 , 1);
		world.drawDroplet(0, 0, 30, 15);
	glPopMatrix();
	
	// == Post processing ==
	// Frame count management
	turningSceneFrame++;
	
	if(turningSceneFrame > turningSceneFrameCount) {
		turningSceneFrame = 0;
		isLeftSignalOn = false;
		isShowLeftScene = false;
		resetStraightRoadSceneVars();
		isShowStraightScene = true;
			
		if (currentCount == combinationCount) {
			checkCombinationOnComplete();
		}
	}
}

void drawRightRoadScene() {
	// Tree scaling animation
	if (straightLeftTreeScaleX <= maxTreeScaleFactor) {
		straightLeftTreeScaleX += turnScaleIncrement;
		straightLeftTreeScaleY += turnScaleIncrement;
	} else {
		straightLeftTreeScaleX = farViewTreeScaleConst;
		straightLeftTreeScaleY = farViewTreeScaleConst;
		straightLeftTreeRand = TreeRand();
	}	
	
	if (straightRightTreeScaleX <= maxTreeScaleFactor) {
		straightRightTreeScaleX += turnScaleIncrement;
		straightRightTreeScaleY += turnScaleIncrement;
	} else {
		straightRightTreeScaleX = farViewTreeScaleConst;
		straightRightTreeScaleY = farViewTreeScaleConst;
		straightRightTreeRand = TreeRand();
	}		
	
	// Fuel animation
	if (!isShowInitOverlay)	{
		if (fuelAngle < emptyFuelAngle) {
			fuelAngle += fuelDecrement;
		} else {
			fuelAngle = emptyFuelAngle;
		}
	}

	if (fuelAngle == emptyFuelAngle) {
		isShowStraightScene = false;
		isShowMutantScene = true;
	}
	
	if (turningSceneFrame % 2 == 1) {
		isRightSignalOn = true;
	} else {
		isRightSignalOn = false;	
	}
	
	glPushMatrix();
		glTranslatef(VW/2, VH/2, 0);
		glRotatef(-10, 0, 0, 1.0);
		glTranslatef(-VW/2, -VH/2, 0);
		// == Drawing ==
		// Sky
		glPushMatrix();
			glColor3f(.75, 0.5, 0);
			drawer.drawRect(-200, VH-skyHeight, VW+200, skyHeight+200);
		glPopMatrix();
		
		// Clouds
		glPushMatrix();
			glTranslatef(VW/2, VH/2, 0);	
			glScalef(0.5, 0.5, 1);
			glTranslatef(-VW/2, -VH/2, 0);
			glTranslatef(-1200, 670, 0);				
			world.drawCloud1();	
					
			glLoadIdentity();
			
			glTranslatef(VW/2, VH/2, 0);
			glScalef(1.5, 1.5, 1);
			glTranslatef(-VW/2, -VH/2, 0);		
			glTranslatef(270, 245, 0);
			world.drawCloud2();	
		
			glLoadIdentity();
			
			glTranslatef(VW/2, VH/2, 0);
			glScalef(1.25, 1.25, 1);
			glTranslatef(-VW/2, -VH/2, 0);
			glTranslatef(-200, 250, 0);		
			world.drawCloud3();													
		glPopMatrix();
	
		// Sidewalk
		glPushMatrix();
			glColor3f(0.505882352941176, 0.113725490196078, 0);
			drawer.drawRect(-200, VH-skyHeight-surfaceHeight-400, VW+200, surfaceHeight+400);
		glPopMatrix();
			
		// Road
		glPushMatrix(); 						
			glColor3f(0.2, 0.2, 0.2);
			drawer.drawRegularPolygon(VW/2, 0, VH-skyHeight, 69, 0, 1, 1);
			drawer.drawRect(VW/2,0, VW/2, VH-skyHeight);
			glColor3f(0.505882352941176, 0.113725490196078, 0);
			drawer.drawRegularPolygon(VW, 0, VH-skyHeight, 69, 0, 1, 1);
		glPopMatrix();
		
		// Trees
		glPushMatrix();
			glTranslatef(straightLeftTreeXOrigin + 200, VH, 0.0);
			glScalef(straightLeftTreeScaleX, straightLeftTreeScaleY, 1.0);
			world.drawTree(-200, straightLeftTreeYOrigin - VH, M_PI/2, 120, straightLeftTreeRand);
			glLoadIdentity();
	
			glTranslatef(straightRightTreeXOrigin + 150, VH, 0.0);
			glScalef(straightRightTreeScaleX, straightRightTreeScaleY, 1.0);		
			world.drawTree(25, straightRightTreeYOrigin - VH, M_PI/2, 120, straightRightTreeRand);
		glPopMatrix();	
	glPopMatrix();	
		
	// Dashboard
	glPushMatrix();
		glColor3f(0, 0, 0);
		// Additional overhead dashboard cover
		drawer.drawTriangle(VW/2-300, VH-skyHeight-surfaceHeight, VW/2-250,VH-skyHeight-surfaceHeight, VW/2-250, VH-skyHeight-surfaceHeight+50);
		drawer.drawRect(VW/2-250, VH-skyHeight-surfaceHeight, (VW/2+250)-(VW/2-250), 50);
		drawer.drawTriangle(VW/2+250, VH-skyHeight-surfaceHeight, VW/2+250, VH-skyHeight-surfaceHeight+50, VW/2+300,VH-skyHeight-surfaceHeight);
		
		// Draw background cover
		drawer.drawRect(0, VH-skyHeight-surfaceHeight-dashboardHeight, VW, dashboardHeight);
		
		// Main dashboard object
		world.drawDashboard(0.75, 0.75, -900, fuelAngle, rpmAngle, speedAngle, isLeftSignalOn, isRightSignalOn);
	glPopMatrix();
	
	// Sweat droplets
	GLfloat dropletAngle1 = 20;
	GLfloat dropletAngle2 = 28;
	glPushMatrix();
		glTranslatef(VW/4 - 100, VH*1.1/4, 0);
		glRotatef(dropletAngle1, 0, 0 , 1);
		world.drawDroplet(0, 0, 65, 35);
		glTranslatef(-1 * (VW/4 - 100), 0, 0);
		glTranslatef(VW*1.1/4 - 165, 0, 0);
		glRotatef(dropletAngle2, 0, 0 , 1);
		world.drawDroplet(0, 0, 30, 15);
	glPopMatrix();
	
	// == Post processing ==
	// Frame count management
	turningSceneFrame++;
	
	if(turningSceneFrame > turningSceneFrameCount) {
		turningSceneFrame = 0;
		isRightSignalOn = false;
		isShowRightScene = false;
		resetStraightRoadSceneVars();
		isShowStraightScene = true;
		
		if (currentCount == combinationCount) {
			checkCombinationOnComplete();
		}
	}
}

void drawMutantScene() {
	// == Logic ==
	// Distance goal
	if (distanceTravelled >= distanceGoal) {
		isShowActionOverlay = true;
	} else {
		isShowActionOverlay = false;
	}
	
	// Road scaling animation
	if (topMarkerScale <= midMarkerScaleConst) {
		GLfloat midTopScaleDiff = midMarkerScaleConst;
		GLfloat midBtmScaleDiff = btmMarkerScaleConst;
		GLfloat midTopSteps = midTopScaleDiff;
		GLfloat midBtmSteps = midBtmScaleDiff / midTopScaleDiff;
		
		topMarkerScale += scaleSpeed;
		midMarkerScale += scaleSpeed / midTopSteps;
		btmMarkerScale += scaleSpeed / midBtmSteps;
	} else {
		topMarkerScale = topMarkerScaleConst;
		midMarkerScale = midMarkerScaleConst;
		btmMarkerScale = btmMarkerScaleConst;
	}
	
	// Tree scaling animation
	if (straightLeftTreeScaleX <= maxTreeScaleFactor) {
		straightLeftTreeScaleX += scaleSpeed;
		straightLeftTreeScaleY += scaleSpeed;
	} else {
		straightLeftTreeScaleX = farViewTreeScaleConst;
		straightLeftTreeScaleY = farViewTreeScaleConst;
		straightLeftTreeRand = TreeRand();
	}	
	
	if (straightRightTreeScaleX <= maxTreeScaleFactor) {
		straightRightTreeScaleX += scaleSpeed;
		straightRightTreeScaleY += scaleSpeed;
	} else {
		straightRightTreeScaleX = farViewTreeScaleConst;
		straightRightTreeScaleY = farViewTreeScaleConst;
		straightRightTreeRand = TreeRand();
	}		
	
	// Fuel animation
	if (!isShowInitOverlay)	{
		if (fuelAngle < emptyFuelAngle) {
			fuelAngle += fuelDecrement;
		} else {
			fuelAngle = emptyFuelAngle;
		}
	}

	if (fuelAngle == emptyFuelAngle) {
		isShowStraightScene = false;
		isShowMutantScene = true;
	}
	
	// == Drawing ==	
	// Sky
	glPushMatrix();
		glColor3f(.75, 0.5, 0);
		drawer.drawRect(0, VH-skyHeight, VW, skyHeight);
	glPopMatrix();
	
	// Clouds
	glPushMatrix();
		glTranslatef(VW/2, VH/2, 0);	
		glScalef(0.5, 0.5, 1);
		glTranslatef(-VW/2, -VH/2, 0);
		glTranslatef(-1200, 670, 0);				
		world.drawCloud1();	
				
		glLoadIdentity();
		
		glTranslatef(VW/2, VH/2, 0);
		glScalef(1.5, 1.5, 1);
		glTranslatef(-VW/2, -VH/2, 0);		
		glTranslatef(270, 245, 0);
		world.drawCloud2();	
	
		glLoadIdentity();
		
		glTranslatef(VW/2, VH/2, 0);
		glScalef(1.25, 1.25, 1);
		glTranslatef(-VW/2, -VH/2, 0);
		glTranslatef(-200, 250, 0);		
		world.drawCloud3();													
	glPopMatrix();

	// Sidewalk
	glPushMatrix();
		glColor3f(0.505882352941176, 0.113725490196078, 0);
		drawer.drawRect(0, VH-skyHeight-surfaceHeight, VW, surfaceHeight);
	glPopMatrix();
		
	// Road
	glPushMatrix(); 						
		glColor3f(0.2, 0.2, 0.2);
		world.drawPerspectivePlane(roadXOrigin, roadYOrigin, roadWidth, surfaceHeight, roadTriangleWidth);

		glPushMatrix();		
			// Road markers
			glColor3f(1.0, 1.0, 1.0);
			glTranslatef(VW/2, VH-skyHeight, 0);
			glScalef(1.0, topMarkerScale, 1.0);
			world.drawPerspectivePlane(markerXOrigin, markerYOrigin, markerWidth, markerHeight, markerTriangleWidth);

			glScalef(1.0, midMarkerScale, 1.0);
			world.drawPerspectivePlane(markerXOrigin, markerYOrigin, markerWidth, markerHeight, markerTriangleWidth);
			
			glScalef(1.0, btmMarkerScale, 1.0);
			world.drawPerspectivePlane(markerXOrigin, markerYOrigin, markerWidth, markerHeight, markerTriangleWidth);
		glPopMatrix();
	glPopMatrix();
	
	// Trees
	glPushMatrix();
		glTranslatef(straightLeftTreeXOrigin + 200, VH, 0.0);
		glScalef(straightLeftTreeScaleX, straightLeftTreeScaleY, 1.0);
		world.drawTree(-200, straightLeftTreeYOrigin - VH, M_PI/2, 120, straightLeftTreeRand);
		glLoadIdentity();

		glTranslatef(straightRightTreeXOrigin - 200, VH, 0.0);
		glScalef(straightRightTreeScaleX, straightRightTreeScaleY, 1.0);		
		world.drawTree(200, straightRightTreeYOrigin - VH, M_PI/2, 120, straightRightTreeRand);
	glPopMatrix();	
	
	// Mutant
	glPushMatrix();
		glTranslatef(VW/2-75, VH-skyHeight+50, 0);
		glScalef(mutantScale, mutantScale, 0);
		world.drawZombie(0, 0, 0.0f);
	glPopMatrix();
	
	// Dashboard                          
	glPushMatrix();
		glColor3f(0, 0, 0);
		// Additional overhead dashboard cover
		drawer.drawTriangle(VW/2-300, VH-skyHeight-surfaceHeight, VW/2-250,VH-skyHeight-surfaceHeight, VW/2-250, VH-skyHeight-surfaceHeight+50);
		drawer.drawRect(VW/2-250, VH-skyHeight-surfaceHeight, (VW/2+250)-(VW/2-250), 50);
		drawer.drawTriangle(VW/2+250, VH-skyHeight-surfaceHeight, VW/2+250, VH-skyHeight-surfaceHeight+50, VW/2+300,VH-skyHeight-surfaceHeight);
		
		// Draw background cover
		drawer.drawRect(0, VH-skyHeight-surfaceHeight-dashboardHeight, VW, dashboardHeight);
		
		// Main dashboard object
		world.drawDashboard(0.75, 0.75, -900, fuelAngle, rpmAngle, speedAngle, isLeftSignalOn, isRightSignalOn);
	glPopMatrix();
	
	// == Post processing ==
	// Mutant scale increment
	mutantScale += mutantScaleSpeed;
	
	// Frame count management
	resultSceneFrame++;
	
	if(resultSceneFrame > resultSceneFrameCount) {
		resultSceneFrame = 0;
		isShowGameOverOverlay = true;
	}
}

void drawGuardPostScene() {
	// == Drawing ==
	// Sky
	glPushMatrix();
		glColor3f(.75, 0.5, 0);
		drawer.drawRect(0, VH-skyHeight, VW, skyHeight);
	glPopMatrix();
	
	// Clouds
	glPushMatrix();
		glTranslatef(VW/2, VH/2, 0);	
		glScalef(0.5, 0.5, 1);
		glTranslatef(-VW/2, -VH/2, 0);
		glTranslatef(-1200, 670, 0);				
		world.drawCloud1();	
				
		glLoadIdentity();
		
		glTranslatef(VW/2, VH/2, 0);
		glScalef(1.5, 1.5, 1);
		glTranslatef(-VW/2, -VH/2, 0);		
		glTranslatef(270, 245, 0);
		world.drawCloud2();	
	
		glLoadIdentity();
		
		glTranslatef(VW/2, VH/2, 0);
		glScalef(1.25, 1.25, 1);
		glTranslatef(-VW/2, -VH/2, 0);
		glTranslatef(-200, 250, 0);		
		world.drawCloud3();													
	glPopMatrix();

	// Sidewalk
	glPushMatrix();
		glColor3f(0.505882352941176, 0.113725490196078, 0);
		drawer.drawRect(0, VH-skyHeight-surfaceHeight, VW, surfaceHeight);
	glPopMatrix();
		
	// Road
	glPushMatrix(); 						
		glColor3f(0.2, 0.2, 0.2);
		world.drawPerspectivePlane(roadXOrigin, roadYOrigin, roadWidth, surfaceHeight, roadTriangleWidth);

		glPushMatrix();		
			// Road markers
			glColor3f(1.0, 1.0, 1.0);
			glTranslatef(VW/2, VH-skyHeight, 0);
			glScalef(1.0, topMarkerScale, 1.0);
			world.drawPerspectivePlane(markerXOrigin, markerYOrigin, markerWidth, markerHeight, markerTriangleWidth);

			glScalef(1.0, midMarkerScale, 1.0);
			world.drawPerspectivePlane(markerXOrigin, markerYOrigin, markerWidth, markerHeight, markerTriangleWidth);
			
			glScalef(1.0, btmMarkerScale, 1.0);
			world.drawPerspectivePlane(markerXOrigin, markerYOrigin, markerWidth, markerHeight, markerTriangleWidth);
		glPopMatrix();
	glPopMatrix();
	
	// Dashboard
	glPushMatrix();
		glColor3f(0, 0, 0);
		// Additional overhead dashboard cover
		drawer.drawTriangle(VW/2-300, VH-skyHeight-surfaceHeight, VW/2-250,VH-skyHeight-surfaceHeight, VW/2-250, VH-skyHeight-surfaceHeight+50);
		drawer.drawRect(VW/2-250, VH-skyHeight-surfaceHeight, (VW/2+250)-(VW/2-250), 50);
		drawer.drawTriangle(VW/2+250, VH-skyHeight-surfaceHeight, VW/2+250, VH-skyHeight-surfaceHeight+50, VW/2+300,VH-skyHeight-surfaceHeight);
		
		// Draw background cover
		drawer.drawRect(0, VH-skyHeight-surfaceHeight-dashboardHeight, VW, dashboardHeight);
		
		// Main dashboard object
		world.drawDashboard(0.75, 0.75, -900, fuelAngle, noRpmAngle, noSpeedAngle, isLeftSignalOn, isRightSignalOn);
	glPopMatrix();
	
	//Guard Post
	glPushMatrix();
		world.drawGuardPost(VW/2, VH-skyHeight, 400, GpAngle);
	glPopMatrix();
	
	// == Post processing ==
	// Frame count management
	resultSceneFrame++;
	
	if (GpAngle < openGpAngle && resultSceneFrame > 5) {GpAngle += 5;}
	
	if(resultSceneFrame > resultSceneFrameCount) {
		resultSceneFrame = 0;
		isShowSuccessOverlay = true;
	}
}

void drawInitOverlay() {
	string header = "Escape the Mutant";
	string nextLine = "Enter 'W' to start.";
	string lines[] = {
		"A mutant is on your trail! You must escape to the nearest defense to save yourself.", 
		"Unfortunately. There are multiple unknown turns ahead, and your fuel is limited...",
		"Looks like you have to entrust your luck on this one.",
	};
	string instructions[] = {
		"W - Drive forward",
		"A - Strafe left (only when prompted)", 
		"D - Strafe left (only when prompted)",
	};
	const GLfloat overlayMargin = 75;
	glPushMatrix();
		glColor4f(0, 0, 0, 0.75);
		drawer.drawQuad(overlayMargin, overlayMargin, VW-overlayMargin, overlayMargin, VW-overlayMargin, VH-overlayMargin, overlayMargin, VH-overlayMargin);
		glColor3f(0, 1.0, .2);
		world.drawText(header.data(), header.size(), VW/8, VH/2+100, GLUT_BITMAP_TIMES_ROMAN_24);
		glColor3f(1.0, 1.0, 1.0);
		world.drawParagraph(VW/8, VH/2, 3, lines, 20);
		world.drawParagraph(VW/8, VH/2-100, 3, instructions, 20);
		glColor3f(0, 1.0, .2);
		world.drawText(nextLine.data(), nextLine.size(), VW/4+25, VH/2-200, GLUT_BITMAP_TIMES_ROMAN_24);
	glPopMatrix();
}

void drawActionOverlay() {
	string leftLine = "Turn Left (A)";
	string connectorLine = "OR";
	string rightLine = "Turn Right (D)";
	glPushMatrix();
		glColor3f(0, 0, 0);
		drawer.drawRect(VW/2-160, VH-116, 120, 30);
		drawer.drawRect(VW/2+52, VH-116, 125, 30);
		glColor3f(.3, 0, 1.0);
		world.drawText(leftLine.data(), leftLine.size(), VW/8+145, VH/2+150, GLUT_BITMAP_HELVETICA_18);
		glColor3f(1, 1, 1);
		world.drawText(connectorLine.data(), connectorLine.size(), VW/8+235, VH/2+150, GLUT_BITMAP_HELVETICA_12);
		glColor3f(1.0, 1.0, 0);
		world.drawText(rightLine.data(), rightLine.size(), VW/8+275, VH/2+150, GLUT_BITMAP_HELVETICA_18);
	glPopMatrix();
}

void drawGameOverOverlay() {
	string title = "Game over";
	string desc = "Try again by pressing 'K'";
	glPushMatrix();
		glColor3f(0, 0, 0);
		drawer.drawRect(0, 0, VW, VH);
		glColor3f(1.0, 0, 0);
		world.drawText(title.data(), title.size(), VW/8, VH/2, GLUT_BITMAP_TIMES_ROMAN_24);
		glColor3f(1, 1, 1);
		world.drawText(desc.data(), desc.size(), VW/8, VH/2-30, GLUT_BITMAP_HELVETICA_18);
	glPopMatrix();
}

void drawSuccessOverlay() {
	string title = "Successfully escaped the mutant!";
	string desc = "Play again by pressing 'K'";
	glPushMatrix();
		glColor3f(0, 0, 0);
		drawer.drawRect(0, 0, VW, VH);
		glColor3f(0, 1.0, 0.2);
		world.drawText(title.data(), title.size(), VW/8, VH/2, GLUT_BITMAP_TIMES_ROMAN_24);
		glColor3f(1, 1, 1);
		world.drawText(desc.data(), desc.size(), VW/8, VH/2-30, GLUT_BITMAP_HELVETICA_18);
	glPopMatrix();
}

//Rendering process begins
void render(){
	//Setting up the mode of OpenGL
	glClearColor(0.0f,0.0f,0.0f,1.0f);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0,VW,0,VH);	
	glClear(GL_COLOR_BUFFER_BIT);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	
	// Scenes
	if (isShowStraightScene) {
		drawStraightRoadScene();		
	} else if (isShowLeftScene) {
		drawLeftRoadScene();
	} else if (isShowRightScene) {
		drawRightRoadScene();
	} else if (isShowMutantScene) {
		drawMutantScene();
	} else if (isShowGuardPostScene) {
		drawGuardPostScene();
	}
	
	// Overlays
	if (isShowInitOverlay) {
		drawInitOverlay();
	} else if (isShowGameOverOverlay) {
		drawGameOverOverlay();
	} else if (isShowSuccessOverlay) {
		drawSuccessOverlay();
	} else if (isShowActionOverlay) {
		drawActionOverlay();
	}
	
	glFlush();
	glutSwapBuffers();
	glutPostRedisplay();
	glFinish();
}

//Keyboard event
void onKeyPress(unsigned char key, GLint x, GLint y) {
	if ((key == 'w' || key == 'W') && isShowStraightScene) {
		if (isShowInitOverlay) {
			isShowInitOverlay = false;
		}
		
		isAccelerating = true;
		// RPM animation
		if (rpmAngle > maxRpmAngle) {
			rpmAngle -= rpmIncrement;
		} else {
			rpmAngle = maxRpmAngle;
		}

		// Speed animation
		if (speedAngle > maxSpeedAngle) {
			speedAngle -= speedIncrement;
		} else {
			speedAngle = maxSpeedAngle;
		}
		
		if (scaleSpeed < maxScaleSpeed) {
			scaleSpeed += scaleIncrement;			
		} else if (scaleSpeed + scaleIncrement >= maxScaleSpeed) {
			scaleSpeed = maxScaleSpeed;
		}
			
		distanceTravelled += scaleSpeed;
	}	
	
	if ((key == 'a' || key == 'A') && isShowActionOverlay) {
		userCombination.push_back('l');
		currentCount++;
		isShowActionOverlay = false;
		isShowStraightScene = false;
		isShowLeftScene = true;
	}
	
	if ((key == 'd' || key == 'D') && isShowActionOverlay) {
		userCombination.push_back('r');
		currentCount++;
		isShowActionOverlay = false;
		isShowStraightScene = false;
		isShowRightScene = true;
	}

	if (key == 'k' || key == 'K') {
		if (isShowGameOverOverlay || isShowSuccessOverlay) {
			resetGame();
		}
	}
}

int main(){
	// Fix for initial gameplay, 
	// for some reason userCombination != combinationArr if it is still a correct combination
	userCombination.clear();
	
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE | GLUT_DEPTH);
	glutInitWindowSize(VW,VH);
	glutInitWindowPosition(0,0);
	glutCreateWindow("Escape the Mutant");
	
	glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
	glEnable(GL_BLEND);
  
	glutDisplayFunc(render);
	glutKeyboardFunc(onKeyPress);
	
	glutMainLoop();
	system("PAUSE");
	return 0;
}
