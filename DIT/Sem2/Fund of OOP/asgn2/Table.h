#ifndef TABLE_H
#define TABLE_H
#include "Product.h"
#include <iostream>
using namespace std;
// Table class (subclass)
class Table: public Product {
	private:
		string shape;
		double length, width, height;
	public:
		// Constructors for Table
		Table() {
			length = 1.0;
			width = 1.0;
			height = 1.0;
		}
		Table(int num, string name, double pr, int qty, string sh, double len, double w, double h): Product(num, name, pr, qty) {
			shape = sh;
			length = len;
			width = w;
			height = h;
		}
		// Getter and setter methods for Table
		void setShape(string s) {
			shape = s;
		}
		void setLength(double len) {
			length = len;
		}
		void setWidth(double w) {
			width = w;
		}
		void setHeight(double h) {
			height = h;
		}
		string getShape() {
			return shape;
		}
		double getLength() {
			return length;
		}
		double getWidth() {
			return width;
		}
		double getHeight() {
			return height;
		}
		// Query methods for Table
		void display() {
			Product::display();
			cout << "Shape: " << shape << endl
				 << "Length: " << length << endl
				 << "Width: " << width << endl
				 << "Height: " << height << endl;
		}
};
#endif
