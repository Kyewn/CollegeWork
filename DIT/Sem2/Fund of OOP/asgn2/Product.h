#ifndef PRODUCT_H
#define PRODUCT_H
#include <iostream>
using namespace std;
// Product class (superclass)
class Product {
	private:
		int productNumber, quantity;
		string productName;
		double price;
	public:
		// Constructors for Product
		Product() {
			productName = "Name Unknown";
		}
		Product(int num, string name, double pr, int qty) {
			productNumber = num;
			productName = name;
			price = pr;
			quantity = qty;
		}
		// Getter and setter methods for Product
		void setProductNumber(int num) {
			productNumber = num;
		}
		void setProductName(string n) {
			productName = n;
		}
		void setPrice(double p) {
			price = p;
		}
		void setQuantity(int qty) {
			quantity = qty;
		}
		int getProductNumber() {
			return productNumber;
		}
		string getProductName() {
			return productName;
		}
		double getPrice() {
			return price;
		}
		int getQuantity() {
			return quantity;
		}
		// Query methods for Product
		void display() {
			cout << "Product Number: " << productNumber << endl
				 << "Product Name: " << productName << endl
				 << "Price: " << price << endl
				 << "Quantity: " << quantity << endl;
		}
};
#endif
