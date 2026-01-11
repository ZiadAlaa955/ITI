#include "User.hpp"
#include <vector>
#include <stdexcept>
#include <iostream>
#include <conio.h>
#include <array>
using namespace std;

Showtime User::selectShowtime(Movie &movie, float time)
{
    for (auto &showtime : movie.getShowTimes())
    {
        if (showtime.getTime() == time)
        {
            return showtime;
        }
    }
    throw runtime_error("Showtime not found");
}

vector<int> User::selectSeat(Showtime &showtime, int numberOfSeats)
{
    vector<int> seats;

    cout << "Enter seat numbers one at a time:" << endl;

    for (int i = 0; i < numberOfSeats; i++)
    {
        int seatNumber;
        cout << "Seat " << (i + 1) << ": ";
        cin >> seatNumber;

        if (seatNumber < 1 || seatNumber > showtime.getSeats())
        {
            cout << "\033[31m" << "Seat " << seatNumber << " does not exist. Please choose a different seat." << "\033[0m" << endl;
            i--;
            continue;
        }
        else if (showtime.checkSeatAvailability(seatNumber) == false)
        {
            cout << "\033[31m" << "Seat " << seatNumber << " is already reserved. Please choose a different seat." << "\033[0m" << endl;
            i--;
            continue;
        }

        seats.push_back(seatNumber);
        showtime.reserveSeat(seatNumber);
    }

    return seats;
}

void User::makeTicket(Movie &movie, Showtime &showtime, vector<int> &seats)
{
    float seatPrice = 250.0f;
    float totalPrice = seats.size() * seatPrice;

    Ticket newTicket(movie.get_title(), showtime.getDate(), showtime.getTime(), totalPrice, seats);
    tickets.push_back(newTicket);
}

void User::completeReservation(Movie &movie, Showtime &showtime, vector<int> &seats)
{
    std::system("cls");
    cout << "\033[38m" << "======= PAYMENT =======" << "\033[0m" << endl;

    float seatPrice = 250.0f;
    float totalAmount = seats.size() * seatPrice;
    cout << "Total Amount: $" << totalAmount << endl;
    cout << "-----------------------------------------------------------" << endl;

    // Payment method selection
    payment = selectPaymentMethod();

    if (payment != nullptr)
    {
        payment->makePayment();

        makeTicket(movie, showtime, seats);

        std::system("cls");
        cout << "\033[32m" << "======================================" << "\033[0m" << endl;
        cout << "\033[32m" << "  RESERVATION COMPLETED SUCCESSFULLY!  " << "\033[0m" << endl;
        cout << "\033[32m" << "======================================" << "\033[0m" << endl;
        cout << endl;

        // Display the latest ticket details
        Ticket latestTicket = tickets.back();
        cout << "Movie: " << latestTicket.getMovieTitle() << endl;
        cout << "Date: " << latestTicket.getDate() << " | Time: " << latestTicket.getTime() << endl;
        cout << "Seats: ";
        vector<int> ticketSeats = latestTicket.getSeats();
        for (int i = 0; i < ticketSeats.size(); i++)
        {
            cout << ticketSeats[i];
            if (i < ticketSeats.size() - 1)
                cout << ", ";
        }
        cout << endl;
        cout << "Total Paid: $" << latestTicket.getPrice() << endl;
        cout << "---------------------------------------------" << endl;
        cout << "\033[33m" << "Thank you!" << "\033[0m" << endl;
    }
    else
    {
        for (int seat : seats)
        {
            showtime.releaseSeat(seat);
        }

        cout << "\033[31m" << "Payment cancelled!" << "\033[0m" << endl;
    }
}

float User::calculateTickets(vector<Ticket> &tickets)
{
    float total = 0;
    for (auto &ticket : tickets)
    {
        total += ticket.getPrice();
    }
    return total;
}

Payment *User::selectPaymentMethod()
{
    int selected = 0;
    bool flag = true;
    array<string, 2> menuItems = {"MasterCard", "Cancel Payment"};
    while (flag)
    {
        std::system("cls");
        cout << "\033[38m" << "Select Payment Method" << "\033[0m" << endl;
        cout << "-----------------------------" << endl;

        for (int i = 0; i < menuItems.size(); i++)
        {
            if (i == selected)
            {
                cout << "\033[32m" << "> " << menuItems[i] << "\033[0m" << endl;
            }
            else
            {
                cout << "  " << menuItems[i] << endl;
            }
        }

        int key = _getch();

        switch (key)
        {
        case 72:
        {
            selected = (selected - 1 + menuItems.size()) % menuItems.size();
            break;
        }
        case 80:
        {
            selected = (selected + 1) % menuItems.size();
            break;
        }
        case 13:
        {
            if (selected == 0)
            {
                std::system("cls");
                cout << "\033[38m" << "MasterCard Payment" << "\033[0m" << endl;
                cout << "-----------------------------" << endl;

                string cardNumber;
                string cvv;
                do
                {
                    cout << "Enter Card Number: ";
                    cin >> cardNumber;
                    if (cardNumber.length() != 16)
                    {
                        cout << "\033[31m" << "Invalid card number. Please enter a 16-digit card number." << "\033[0m" << endl;
                    }
                } while (cardNumber.length() != 16);

                do
                {
                    cout << "Enter CVV: ";
                    cin >> cvv;
                    if (cvv.length() != 3)
                    {
                        cout << "\033[31m" << "Invalid CVV. Please enter a 3-digit CVV." << "\033[0m" << endl;
                    }
                } while (cvv.length() != 3);

                return new MasterCard(cardNumber, cvv);
            }
            else
            {
                return nullptr;
            }
        }
        case 27:
        {
            return nullptr;
        }
        }
    }

    return nullptr;
}

vector<Ticket> User::getTickets()
{
    return tickets;
}