#ifndef _TREE_RAND_H_
#define _TREE_RAND_H_
#include "math.h"
#include <cstdlib>
using namespace std;

class TreeRand {
	public:
		float leftAngleRand;
		float rightAngleRand;
		float lowerLeftAngleRand;
		float lowerRightAngleRand;
		float branchLengthRand;
		
		TreeRand();
		~TreeRand();
};
#endif
