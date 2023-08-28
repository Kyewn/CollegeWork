#ifndef _MODEL_H_
#define _MODEL_H_
#include "space.h"

namespace Model{
	class Teapot{
		public:
			void draw();
	};
	class Sphere{
		public:
			void draw();
	};
	class Torus{
		public:
			void draw();
	};
	class Box {
		public:
			void draw();
	};
	class World{
		public:
			Teapot teapot;
			Sphere sphere;
			Torus torus;
			Box box;
			void draw();
	};
};
#endif
