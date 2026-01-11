#include "MasterCard.hpp"

using namespace std;

MasterCard::MasterCard(string cardNumber, string cvv)
    : cardNumber(cardNumber), cvv(cvv) {}

void MasterCard::makePayment()
{
    std::cout << "Payment by master card is done successfully" << std::endl;
}