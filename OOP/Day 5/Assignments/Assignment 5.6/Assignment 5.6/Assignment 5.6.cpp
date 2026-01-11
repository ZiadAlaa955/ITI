#include <iostream>
using namespace std;

int main() {

    int x = 10;
    int* p = &x;   
    int** ptp = &p; 
    
    cout << "x  = " << x << endl; 
    cout << "pointer = " << *p << endl; 
    cout << "pointer to pointer = " << **ptp << endl; 

    cout << "Address of x: " << &x << endl;
    cout << "address of x by : " << p << endl;
    cout << "Value stored in ptp (address of p): " << ptp << endl;

    return 0;
}
