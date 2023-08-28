#include "treeRand.h"
TreeRand::TreeRand() {
   this->leftAngleRand = (float) rand();
   this->rightAngleRand = (float) rand();
   this->lowerLeftAngleRand = (float) rand();
   this->lowerRightAngleRand = (float) rand();
   this->branchLengthRand = (float) rand();	
}

TreeRand::~TreeRand(){
}
