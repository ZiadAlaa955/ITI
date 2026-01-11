#include <iostream>
#include <vector>
#include "SimpleGraphics.h"

using namespace std;

class Point {
	int x;
	int y;
public:
	Point() = default;
	Point(int x, int y) : x(x), y(y) {}
	
	int getX() { return x; }
	int getY() { return y; }
};

class Circle {
	Point center;
	int radius;
public:
	Circle() = default;
	Circle(int x, int y, int radius) : center(x, y), radius(radius) {}

	void draw() {
		drawCircle(center.getX(), center.getY(), radius);
	}
};

class Rectangle {
	Point ul, lr;
public:
	Rectangle() = default;
	Rectangle(int x1, int y1, int x2, int y2) : ul(x1, y1), lr(x2, y2) {}

	void draw() {
		drawRect(ul.getX(), ul.getY(), lr.getX(), lr.getY());
	}
};

class Line {
	Point start, end;
public:
	Line() = default;
	Line(int x1, int y1, int x2, int y2) : start(x1, y1), end(x2, y2) {}

	void draw() {
		drawLine(start.getX(), start.getY(), end.getX(), end.getY());
	}
};

class Triangle {
	Point a, b, c;
public:
	Triangle() = default;
	Triangle(int a1, int b1, int a2, int b2, int a3, int b3) :a(a1, b1), b(a2, b2), c(a3, b3) {}

	void draw() {
		drawTriangle(a.getX(), a.getY(), b.getX(), b.getY(), c.getX(), c.getY());
	}
};

class Picture {
	Circle** circles; int cNum;
	Rectangle** rectangles; int rNum;
	Line** lines; int lNum;
	Triangle** triangles; int tNum;

public:
	Picture() :circles(nullptr), rectangles(nullptr), lines(nullptr), triangles(nullptr), cNum(0), rNum(0), lNum(0), tNum(0) {}
	
	void addCircle(int n, Circle** circles) {
		cNum = n;
		this->circles = circles;
	}
	void addRectangle(int n, Rectangle** rectangles) {
		rNum = n;
		this->rectangles = rectangles;
	}
	void addLine(int n, Line** lines) {
		lNum = n;
		this->lines = lines;
	}
	void addTriangle(int n, Triangle** triangles) {
		tNum = n;
		this->triangles = triangles;
	}

	void paint() {
		for (int i = 0; i < cNum; i++)circles[i]->draw();
		for (int i = 0; i < rNum; i++)rectangles[i]->draw();
		for (int i = 0; i < lNum; i++)lines[i]->draw();
		for (int i = 0; i < tNum; i++)triangles[i]->draw();
	}

};

int main()
{
	initScreen();
	/*Shapes*/
	Circle** circleArray = new Circle * [2];
	Rectangle** rectArray = new Rectangle * [1];
	Line** lineArray = new Line * [2];
	Triangle** triArray = new Triangle * [1];

	circleArray[0] = new Circle(30, 10, 8);
	circleArray[1] = new Circle(90, 30, 5);
	rectArray[0] = new Rectangle(5, 5, 115, 35);
	lineArray[0] = new Line(5, 5, 115, 35);
	lineArray[1] = new Line(115, 5, 5, 35);
	triArray[0] = new Triangle(60, 10, 50, 20, 70, 20);

	Picture pic;
	pic.addCircle(2, circleArray);
	pic.addRectangle(1, rectArray);
	pic.addTriangle(1, triArray);
	pic.addLine(2, lineArray);

	pic.paint();
	renderScreen();

	return 0;
}