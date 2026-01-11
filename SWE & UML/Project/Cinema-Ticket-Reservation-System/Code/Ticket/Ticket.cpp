#include "Ticket.hpp"

Ticket::Ticket(std::string movieTitle, std::string date, float time, float price, std::vector<int> seats)
    : movieTitle(movieTitle), date(date), time(time), price(price), seats(seats) {}