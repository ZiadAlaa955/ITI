#include <iostream>

class Payment
{

protected:
    float amount;

public:
    virtual void makePayment() = 0;
};