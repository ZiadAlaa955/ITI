#include <iostream>
#include <cmath>
#include <algorithm>
#include <vector>

using namespace std;

const float pi = 3.14;

class GeoShape {
protected:
	float a, b;
public:
	GeoShape() = default;
	GeoShape(float dim) :a(dim), b(dim) {}
	GeoShape(float dim1, float dim2) :a(dim1), b(dim2) {}

	void setDim1(float dim1) { a = dim1; }
	void setDim2(float dim2) { b = dim2; }
	float getDim1() { return a; }
	float getDim2() { return b; }

	virtual	float clacArea() = 0;
	virtual float calcPerimeter() = 0;
	virtual float calcVolume() = 0;
	virtual void printShapeData() = 0;

	bool operator<(GeoShape& other) {
		return this->clacArea() < other.clacArea();
	}

	GeoShape& operator= (GeoShape& other)
	{
		this->a = other.a;
		this->b = other.b;

		return *this;
	}
};

class Rectangle : public GeoShape{
public:
	Rectangle() = default;
	Rectangle(float width, float height) :GeoShape(width, height) {}

	float clacArea() override
	{
		return a * b;
	}
	float calcPerimeter() override
	{
		return 2 * (a + b);
	}
	float calcVolume() override
	{
		return 0;
	}
	void printShapeData() override {
		cout << "----------------Rectangle------------" << endl;
		cout << "Width = " << a << ", Height = " << b << endl;
		cout << "Area = " << clacArea() << ", Perimeter = " << calcPerimeter() << endl;
	}

};

class Square : public Rectangle {
public:
	Square() = default;
	Square(float height) : Rectangle(height, height) {}

	float clacArea() override
	{
		return a * a;
	}
	float calcPerimeter() override
	{
		return 4 * a;
	}
	float calcVolume() override
	{
		return 0;
	}
	void printShapeData() override {
		cout << "----------------Square------------" << endl;
		cout << "Side = " << a << endl;
		cout << "Area = " << clacArea() << ", Perimeter = " << calcPerimeter() << endl;
	}
};

class Cube : public Square {
public:
	Cube() = default;
	Cube(float height) :Square(height) {}

	float clacArea() override
	{
		return 6 * (a * a);
	}
	float calcVolume() override
	{
		return a * a * a;
	}
	float calcPerimeter() override
	{
		return 0;
	}
	void printShapeData() override {
		cout << "----------------Cube------------" << endl;
		cout << "Side = " << a << endl;
		cout << "Area = " << clacArea() << ", Volume = " << calcVolume() << endl;
	}
};

class Circle : public GeoShape{
public:
	Circle() = default;
	Circle(float radius) :GeoShape(radius) {}

	float clacArea() override
	{
		return pi * a * b;
	}
	float calcPerimeter() override
	{
		return 2 * pi * a;
	}
	float calcVolume() override
	{
		return 0;
	}
	void printShapeData()override {
		cout << "----------------Circle------------" << endl;
		cout << "Radius = " << a;
		cout << "Area = " << clacArea() << ", Perimeter = " << calcPerimeter() << endl;
	}
};

class Triangle : public GeoShape{
	float c, height;
public:
	Triangle() = default;
	Triangle(float a, float b, float c, float height) :GeoShape(a, b), c(c), height(height) {}

	float clacArea() override
	{
		return 0.5 * b * height;
	}
	float calcPerimeter() override
	{
		return a + b + c;
	}
	float calcVolume() override
	{
		return 0;
	}
	void printShapeData() override {
		cout << "Sides: a=" << a << ", b(base)=" << b << ", c=" << c << ", Height: " << height <<  endl;
		cout << "Area = " << clacArea() << ", Perimeter = " << calcPerimeter() << endl;
	}
};

class Rhombus : public Rectangle{
public:
	Rhombus() = default;
	Rhombus(float d1, float d2) :Rectangle(d1, d2) {}

	float clacArea() override
	{
		return a * b * 0.5;
	}
	float calcPerimeter()override 
	{
		float half_a = a / 2.0f;
		float half_b = b / 2.0f;
		float side = sqrt((half_a * half_a) + (half_b * half_b));
		return 4.0f * side;
	}
	float calcVolume() override
	{
		return 0;
	}
	void printShapeData() override {
		cout << "----------------Rhombus------------" << endl;
		cout << "Diagonals: D1=" << a << ", D2=" << b << endl;
		cout << "Area = " << clacArea() << ", Volume = " << calcVolume() << endl;
	}
};

bool compareShapes(GeoShape* shape1, GeoShape* shape2){
	return shape1->clacArea() < shape2->clacArea();
}

void sortAscending(vector<GeoShape*>& shapes) {
	sort(shapes.begin(), shapes.end(), compareShapes);
	cout << "-----Ascending sorted Shapes-------" << endl;
	for (auto shape : shapes) {
		shape->printShapeData() ;
	}
}

void sortDescnding(vector<GeoShape*>& shapes) {
	sort(shapes.begin(), shapes.end(), compareShapes);
	reverse(shapes.begin(), shapes.end());
	cout << "-----Descending sorted Shapes-------" << endl;
	for (auto shape : shapes) {
		shape->printShapeData();
	}
}

int main()
{
	vector<GeoShape*> shapes;
	shapes.push_back(new Rectangle(20, 10));
	shapes.push_back(new Square(10));
	shapes.push_back(new Cube(10));
	shapes.push_back(new Circle(5));
	shapes.push_back(new Triangle(10, 10, 10, 10));
	shapes.push_back(new Rhombus(15, 20));
	
	Rectangle r1(10,10);
	Rectangle r2 = r1;
	r1.printShapeData();
	r2.printShapeData();
	cout << endl;
	compareShapes(shapes[0], shapes[1]) ? cout << "shape1 is smaller" : cout << "shape2 is smaller" << endl << endl;
	cout << "--------------------------" << endl;
	sortAscending(shapes);
	cout << "--------------------------" << endl << endl;
	sortDescnding(shapes);

}