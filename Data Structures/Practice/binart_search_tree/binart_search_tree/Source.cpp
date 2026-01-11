#include <iostream>
using namespace std;


class Employee {
public:
    int id = 0;
    string name;

    Employee() : id(0), name("unknown"){}
    Employee(int id, string name, int age, double salary) : id(id), name(name){}
};

class Node {
public:
    Employee employee;
    Node* left;
    Node* right;

    Node() : left(nullptr), right(nullptr) {}
    Node(Employee e) : employee(e), left(nullptr), right(nullptr) {}
};

class BinarySearchTree {
    Node* root;
public:
    BinarySearchTree() :root(nullptr) {}
    BinarySearchTree(Node* root) : root(root) {}

    void insertNode(Employee employee) {

    }

};


int main() {

	return 0;
}