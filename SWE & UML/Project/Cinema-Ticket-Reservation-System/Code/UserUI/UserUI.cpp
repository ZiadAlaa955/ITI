#include "UserUI.hpp"
#include "../Movie/Movie.hpp"
#include "../System/System.hpp"
#include <iostream>
#include <array>
#include <cstdlib>
#include <conio.h>
#include <string>
#include <iomanip>

using namespace std;

UserUI::UserUI() { user = new User(); }

void UserUI::printMenu()
{
    array<string, 4> menuItems = {"Reserve Ticket", "View Reserved Tickets", "Sign Out", "Exit"};
    int selected = 0;
    bool flag = true;

    system("");

    while (flag)
    {
        system("cls");
        cout << "\033[38m" << "Main Menu" << "\033[0m" << endl;
        cout << "--------------" << endl;

        for (int i = 0; i < menuItems.size(); ++i)
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
            selected = (selected - 1) % menuItems.size();
            break;
        }
        case 80:
        {
            selected = (selected + 1) % menuItems.size();
            break;
        }
        case 13:
        {
            system("cls");

            switch (selected)
            {
            case 0:
                reserveTicket();
                break;
            case 1:
                viewReservedTickets();
                break;
            case 2:
            {
                UI ui;
                UI *client = ui.login();
                if (client)
                    client->printMenu();
                flag = false;
                break;
            }
            case 3:
                cout << "Cya!" << endl;
                flag = false;
                break;
            }

            if (flag && selected < 2)
            {
                cout << endl;
                cout << "\033[32m" << "Press any key to return to menu!" << "\033[0m" << endl;
                _getch();
            }
            break;
        }
        case 27:
        {
            cout << "Cya!" << endl;
            flag = false;
            break;
        }
        }
    }
}

///////////////////// User Functions ///////////////
void UserUI::reserveTicket()
{
    string currentDate = System::getTodayDate();
    int selected = 0;
    bool flag = true;
    vector<Movie> availableMovies;

    while (flag)
    {
        availableMovies = System::searchMoviebydate(currentDate);
        system("cls");

        cout << "\033[38m" << "Reserve Ticket - Movies on " << currentDate << "\033[0m" << endl;
        cout << "-----------------------------------------------------------" << endl;
        cout << "\033[33m" << "Press D to change date | Press ESC to go back" << "\033[0m" << endl;
        cout << "-----------------------------------------------------------" << endl;

        if (availableMovies.empty())
        {
            cout << "\033[31m" << "No movies available on this date." << "\033[0m" << endl;
            cout << "Press D to select a different date or ESC to go back." << endl;
        }
        else
        {
            for (int i = 0; i < availableMovies.size(); i++)
            {
                if (i == selected)
                {
                    cout << "\033[32m" << "> " << availableMovies[i].get_title() << "\033[0m" << endl;
                    cout << "  Description: " << availableMovies[i].get_desc() << endl;
                    cout << "  Genre: " << availableMovies[i].get_genre() << endl;
                    cout << "  Rating: " << availableMovies[i].get_rating() << endl;
                    cout << "  Duration: " << availableMovies[i].get_duration() << " hours" << endl;
                    cout << endl;
                }
                else
                {
                    cout << "  " << availableMovies[i].get_title() << endl;
                }
            }
        }

        int key = _getch();

        switch (key)
        {
        case 72:
        {
            if (!availableMovies.empty())
            {
                selected = (selected - 1 + availableMovies.size()) % availableMovies.size();
            }
            break;
        }
        case 80:
        {
            if (!availableMovies.empty())
            {
                selected = (selected + 1) % availableMovies.size();
            }
            break;
        }
        case 13:
        {
            if (!availableMovies.empty())
            {
                system("cls");
                string movieTitle = availableMovies[selected].get_title();
                Movie *selectedMovie = System::searchMoviebytitle(movieTitle);
                selectShowtime(*selectedMovie, currentDate);
                flag = false;
            }
            break;
        }
        case 'D':
        case 'd':
        {
            system("cls");
            cout << "\033[38m" << "Enter new date (DD/MM/YYYY): " << "\033[0m";
            cin.ignore();
            getline(cin, currentDate);
            selected = 0;
            break;
        }
        case 27:
        {
            flag = false;
            break;
        }
        }
    }
}

void UserUI::selectShowtime(Movie &selectedMovie, string date)
{
    int selected = 0;
    bool flag = true;

    while (flag)
    {
        system("cls");

        cout << "\033[38m" << "Choose a Showtime for " << selectedMovie.get_title()
             << " on " << date << "\033[0m" << endl;
        cout << "-----------------------------------------------------------" << endl;
        cout << "\033[33m" << "Press ESC to go back" << "\033[0m" << endl;
        cout << "-----------------------------------------------------------" << endl;

        vector<Showtime> &showtimes = selectedMovie.getShowTimes();
        vector<Showtime *> times;

        for (auto &showtime : showtimes)
        {
            if (showtime.getDate() == date)
            {
                times.push_back(&showtime);
            }
        }

        if (times.empty())
        {
            cout << "\033[31m" << "No showtimes available for this movie on " << date << "." << "\033[0m" << endl;
            return;
        }

        for (int i = 0; i < times.size(); i++)
        {
            if (i == selected)
            {
                cout << fixed << setprecision(2) << "\033[32m" << "> Time: " << times[i]->getTime() << "\033[0m" << endl;
            }
            else
            {
                cout << fixed << setprecision(2) << "  Time: " << times[i]->getTime() << endl;
            }
        }

        int key = _getch();

        switch (key)
        {
        case 72:
        {
            selected = (selected - 1 + times.size()) % times.size();
            break;
        }
        case 80:
        {
            selected = (selected + 1) % times.size();
            break;
        }
        case 13:
        {
            system("cls");
            Showtime &selectedShowtime = *times[selected];
            selectSeats(selectedMovie, selectedShowtime);
            flag = false;
            break;
        }
        case 27:
        {
            flag = false;
            break;
        }
        }
    }
}
void UserUI::selectSeats(Movie &selectedMovie, Showtime &selectedShowtime)
{
    system("cls");

    cout << "\033[38m" << "Seat Selection for " << selectedMovie.get_title() << "\033[0m" << endl;
    cout << "Date: " << selectedShowtime.getDate() << " | Time: " << selectedShowtime.getTime() << endl;
    cout << "-----------------------------------------------------------" << endl;
    cout << "\033[32mGreen\033[0m = Available | \033[31mRed\033[0m = Reserved" << endl;
    cout << "-----------------------------------------------------------" << endl;

    selectedShowtime.displaySeats(7, 4);

    cout << "\033[25;0H";
    cout << "-----------------------------------------------------------" << endl;

    if (!selectedShowtime.hasAvailableSeats())
    {
        cout << "\033[31m" << "No seats available for this movie on " << selectedShowtime.getDate() << " at " << selectedShowtime.getTime() << "." << "\033[0m" << endl;
        return;
    }

    int numberOfSeats;

    do
    {
        cout << "How many seats do you want to reserve? ";
        cin >> numberOfSeats;

        if (numberOfSeats <= 0 || numberOfSeats > selectedShowtime.getSeats())
        {
            cout << "\033[31m" << "Invalid number of seats!" << "\033[0m" << endl;
        }
    } while (numberOfSeats <= 0 || numberOfSeats > selectedShowtime.getSeats());

    vector<int> selectedSeats = user->selectSeat(selectedShowtime, numberOfSeats);

    float seatPrice = 250.0f;
    float totalPrice = numberOfSeats * seatPrice;

    system("cls");
    cout << "\033[38m" << "======= RESERVATION SUMMARY =======" << "\033[0m" << endl;
    cout << "---------------------------------------------" << endl;
    cout << "Movie: " << selectedMovie.get_title() << endl;
    cout << "Date: " << selectedShowtime.getDate() << " | Time: " << selectedShowtime.getTime() << endl;
    cout << "Seats: ";
    for (int i = 0; i < selectedSeats.size(); i++)
    {
        cout << selectedSeats[i];
        if (i < selectedSeats.size() - 1)
            cout << ", ";
    }
    cout << endl;

    cout << "Price per seat: $" << seatPrice << endl;
    cout << "------------------------------------------" << endl;
    cout << "\033[32m" << "Total Amount: $" << totalPrice << "\033[0m" << endl;
    cout << "---------------------------------------------" << endl;

    cout << "Press ENTER to proceed to payment or ESC to cancel..." << endl;

    int key = _getch();

    if (key == 13)
    {
        user->completeReservation(selectedMovie, selectedShowtime, selectedSeats);
    }
    else if (key == 27)
    {
        for (int seat : selectedSeats)
        {
            selectedShowtime.releaseSeat(seat);
        }

        cout << "\033[31m" << "Reservation cancelled!" << "\033[0m" << endl;
    }
}

void UserUI::viewReservedTickets()
{
    system("cls");
    cout << "\033[38m" << "======= YOUR RESERVED TICKETS =======" << "\033[0m" << endl;
    cout << "---------------------------------------------" << endl;

    vector<Ticket> userTickets = user->getTickets();

    if (userTickets.empty())
    {
        cout << "\033[31m" << "No tickets found." << "\033[0m" << endl;
    }
    else
    {
        for (int i = 0; i < userTickets.size(); i++)
        {
            cout << "\033[32m" << "Ticket #" << (i + 1) << "\033[0m" << endl;
            cout << "Movie: " << userTickets[i].getMovieTitle() << endl;
            cout << "Date: " << userTickets[i].getDate() << " | Time: " << userTickets[i].getTime() << endl;
            cout << "Seats: ";
            vector<int> seats = userTickets[i].getSeats();
            for (int j = 0; j < seats.size(); j++)
            {
                cout << seats[j];
                if (j < seats.size() - 1)
                    cout << ", ";
            }
            cout << endl;
            cout << "Price: $" << userTickets[i].getPrice() << endl;
            cout << "---------------------------------------------" << endl;
        }

        float totalSpent = user->calculateTickets(userTickets);
        cout << "\033[33m" << "Total Spent: $" << totalSpent << "\033[0m" << endl;
    }
}
