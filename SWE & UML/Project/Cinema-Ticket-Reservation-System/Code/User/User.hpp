#ifndef USER_FILE
#define USER_FILE

#include <iostream>
#include <ctime>
#include "../System/System.hpp"
#include "../Movie/Movie.hpp"
#include "../Ticket/Ticket.hpp"
#include "../Payment/MasterCard.hpp"
#include "../Person/Person.hpp"

using namespace std;

class User : public Person
{
    vector<Ticket> tickets;
    Payment *payment;

public:
    Showtime selectShowtime(Movie &movie, float time);

    vector<int> selectSeat(Showtime &showtime, int numberOfSeats);

    void makeTicket(Movie &movie, Showtime &showtime, vector<int> &seats);

    void completeReservation(Movie &movie, Showtime &showtime, vector<int> &seats);

    float calculateTickets(vector<Ticket> &tickets);

    Payment *selectPaymentMethod();

    vector<Ticket> getTickets();
};

#endif