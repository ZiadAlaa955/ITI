#include "Payment.hpp"

using namespace std;
class MasterCard : public Payment
{

private:
    string cardNumber;
    string cvv;

public:
    MasterCard(string cardNumber, string cvv);
    void makePayment() override;
};