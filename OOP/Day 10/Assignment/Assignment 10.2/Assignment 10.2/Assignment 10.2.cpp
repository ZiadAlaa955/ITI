#include <iostream>

using namespace std;

class Shape {
protected:
	int x, y;
	string color;
public:
	Shape() {
		x = 0;
		y = 0;
		color = "none";
	}
	Shape(int point, string c) :x(point), y(point), color(c) {}
	Shape(int pointX, int pointY, string c) :x(pointX), y(pointY), color(c) {}

	void setX(int n) { x = n; }
	void setY(int n) { y = n; }
	void setColor(string c) { color = c; }

	int getX() { return x; }
	int getY() { return y; }
	string getColor() { return color; }

	void displayPoints() {
		cout << "X: " <<  x << ", Y: " << y << endl;
	}
};

class Circle : public Shape {
	int radius;
public:
	Circle() {
		radius = 0;
	}
	Circle(int pointX, int pointY, int radius, string color) :Shape(pointX, pointY, color), radius(radius) {}

	void setRadius(int r) { radius = r; }
	int getRadius() { return radius; }

	void displayPoints() {
		Shape::displayPoints();
		cout << "radius: " << radius << endl;
	}
};

int main()
{
	Circle c1(10,20,5,"Red");
	c1.displayPoints();
	cout << "-----------------------" << endl;
	Shape s1(5, 6, "Blue");
	s1.displayPoints();
}