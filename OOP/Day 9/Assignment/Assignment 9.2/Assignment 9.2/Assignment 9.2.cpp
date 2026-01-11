#include <iostream>
#include <vector>
#include "SimpleGraphics.h"
using namespace std;

class Point {
	int x;
	int y;
public:
	Point() {
		x = 0;
		y = 0;
	}
	Point(int x, int y) : x(x), y(y) {}

	int getX() { return x; }
	int getY() { return y; }
};

class Circle {
	Point* center;
	int radius;
public:
	Circle() : center(new Point(0,0)), radius(0){}
	Circle(int x, int y, int radius) : center(new Point(x,y)),radius(radius) {}

	void draw() {
		drawCircle(center->getX(), center->getY(), radius);
	}
};

class Rectangle {
	Point* ul, * lr;
public:
	Rectangle() : ul(new Point(0, 0)), lr(new Point(0, 0)) {}
	
	Rectangle(int x1, int y1, int x2, int y2) : ul(new Point(x1, y1)), lr(new Point(x2, y2)) {}

	void draw() {
		drawRect(ul->getX(), ul->getY(), lr->getX(), lr->getY());
	}
};

class Line {
	Point* start, * end;
public:
	Line() : start(new Point(0, 0)), end(new Point(0, 0)) {}
	
	Line(int x1, int y1, int x2, int y2) :start(new Point(x1, y1)), end(new Point(x2, y2)) {}
	
	void draw() {
		drawLine(start->getX(), start->getY(), end->getX(), end->getY());
	}
};

class Triangle {
	Point* a, * b, * c;
public:
	Triangle() : a(new Point(0, 0)), b(new Point(0, 0)), c(new Point(0, 0)) {}
	
	Triangle(int a1, int b1, int a2, int b2, int a3, int b3) : a(new Point(a1, b1)), b(new Point(a2, b2)), c(new Point(a3, b3)) {}
	
	void draw() {
		drawTriangle(a->getX(), a->getY(), b->getX(), b->getY(), c->getX(), c->getY());
	}
};

class Ellipse
{
	Point* center;
	int xRadius;
	int yRadius;

public:
	Ellipse(int xCor, int yCor, int rX, int rY)
		: xRadius(rX), yRadius(rY), center(new Point(xCor, yCor)) {}

	void draw()
	{
		drawEllipse(center->getX(), center->getY(), yRadius, xRadius);

	}
};


class Picture {
	Circle** circles; int cNum;
	Rectangle** rectangles; int rNum;
	Line** lines; int lNum;
	Triangle** triangles; int tNum;
	Ellipse** ellipses; int eNum;

public:
	Picture() :circles(nullptr), rectangles(nullptr), lines(nullptr), triangles(nullptr), ellipses(nullptr), cNum(0), rNum(0), lNum(0), tNum(0), eNum(0) {}

	Picture(Picture& other)
	{
		this->cNum = other.cNum;
		this->rNum = other.rNum;
		this->lNum = other.lNum;
		this->tNum = other.tNum;
		this->eNum = other.eNum;
		this->circles = other.circles;
		this->rectangles = other.rectangles;
		this->lines = other.lines;
		this->triangles = other.triangles;
		this->ellipses = other.ellipses;

		for (int i = 0; i < cNum; i++)
		{
			circles[i] = new Circle(*other.circles[i]);
		}
		for (int i = 0; i < rNum; i++)
		{
			rectangles[i] = new Rectangle(*other.rectangles[i]);
		}
		for (int i = 0; i < lNum; i++)
		{
			lines[i] = new Line(*other.lines[i]);
		}
		for (int i = 0; i < tNum; i++)
		{
			triangles[i] = new Triangle(*other.triangles[i]);
		}
		for (int i = 0; i < eNum; i++)
		{
			this->ellipses[i] = new Ellipse(*other.ellipses[i]);
		}
	}


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
	void addEllipse(int n, Ellipse** ellipses) { 
		eNum = n; 
		this->ellipses = ellipses; 
	}

	void paint() {
		for (int i = 0; i < cNum; i++)circles[i]->draw();
		for (int i = 0; i < rNum; i++)rectangles[i]->draw();
		for (int i = 0; i < lNum; i++)lines[i]->draw();
		for (int i = 0; i < tNum; i++)triangles[i]->draw();
		for (int i = 0; i < eNum; i++)ellipses[i]->draw();
	}

};

int main()
{
	int c = 0, r = 0, l = 0, t = 0, e = 0; 
	int x1, y1, x2, y2, x3, y3, radius, rx, ry; 
	initScreen();

	Circle** circleArray = nullptr;
	Rectangle** rectArray = nullptr;
	Line** lineArray = nullptr;
	Triangle** triArray = nullptr;
	Ellipse** ellipseArray = nullptr;

	/*---------Circles---------*/
	cout << "Enter number of circles: ";
	cin >> c;
	if (c > 0) {
		circleArray = new Circle * [c];
		for (int i = 0; i < c; i++) {
			cout << "Enter circle " << i + 1 << " center (x, y) and radius: " << endl;
			cin >> x1 >> y1 >> radius;
			circleArray[i] = new Circle(x1, y1, radius);
		}
	}

	/*---------Rectangles---------*/
	cout << "Enter number of rectangles: ";
	cin >> r;
	if (r > 0) {
		rectArray = new Rectangle * [r];
		for (int i = 0; i < r; i++) {
			cout << "Enter rectangle " << i + 1 << " UL(x1, y1) and LR(x2, y2) coordinates: " << endl;
			cin >> x1 >> y1 >> x2 >> y2;
			rectArray[i] = new Rectangle(x1, y1, x2, y2);
		}
	}

	/*---------Lines---------*/
	cout << "Enter number of lines: ";
	cin >> l;
	if (l > 0) {
		lineArray = new Line * [l];
		for (int i = 0; i < l; i++) {
			cout << "Enter line " << i + 1 << " start(x1, y1) and end(x2, y2) coordinates: " << endl;
			cin >> x1 >> y1 >> x2 >> y2;
			lineArray[i] = new Line(x1, y1, x2, y2);
		}
	}

	/*---------Triangles---------*/
	cout << "Enter number of triangles: ";
	cin >> t;
	if (t > 0) {
		triArray = new Triangle * [t];
		for (int i = 0; i < t; i++) {
			cout << "Enter triangle " << i + 1 << " vertices (x1, y1, x2, y2, x3, y3) coordinates: " << endl;
			cin >> x1 >> y1 >> x2 >> y2 >> x3 >> y3;
			triArray[i] = new Triangle(x1, y1, x2, y2, x3, y3);
		}
	}

	/*-----------Ellipses-------------*/
	cout << "Enter number of ellipses: ";
	cin >> e;
	if (e > 0) {
		ellipseArray = new Ellipse * [e];
		for (int i = 0; i < e; i++) {
			cout << "Enter ellipse " << i + 1 << " center (x, y) and radii (rx, ry): " << endl;
			cin >> x1 >> y1 >> rx >> ry;
			ellipseArray[i] = new Ellipse(x1, y1, rx, ry);
		}
	}

	/*---------Picture---------*/
	Picture pic;
	pic.addCircle(c, circleArray);
	pic.addRectangle(r, rectArray);
	pic.addTriangle(t, triArray);
	pic.addLine(l, lineArray);
	pic.addEllipse(e, ellipseArray);

	pic.paint();

	renderScreen();

	return 0;
}

/*
1
30 35 4
1
15 25 45 60
1
25 40 35 40
1
10 25 50 25 30 10
1
40 15 5 8
*/





