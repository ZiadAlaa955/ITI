#include <iostream>
#include "AdminUI.hpp"
#include <array>
#include <cstdlib>
#include <conio.h>
#include <limits>
#include "../Movie/Movie.hpp"
#include "../System/System.hpp"
#include "../Admin/Admin.hpp"
using namespace std;

AdminUI::AdminUI() { admin = new Admin(); }

void AdminUI::printMenu()
{
    array<string, 9> menuItems = {"Add Movie", "Edit Movie", "Delete Movie",
                                  "List all Movies", "Create Showtime", "Edit Showtimes", "Delete Showtimes", "Sign Out", "Exit"};
    int selected = 0;
    bool flag = true;

    while (flag)
    {
        system("cls");
        cout << "\033[38m" << "Dashboard" << "\033[0m" << endl;
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
                addMovie();
                break;
            case 1:
                editMovie();
                break;
            case 2:
                deleteMovie();
                break;
            case 3:
                displayAllMovies();
                break;
            case 4:
                createShowtime();
                break;
            case 5:
                editShowtime();
                break;
            case 6:
                deleteShowtime();
                break;
            case 7:
            {
                UI ui;
                UI *client = ui.login();
                if (client)
                    client->printMenu();
                flag = false;
                break;
            }
            case 8:
                cout << "Cya!" << endl;
                flag = false;
                break;
            }

            if (flag && selected < 7)
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
void AdminUI::addMovie()
{
    string title, description, genre;
    float rating, duration;
    cout << "Add Movie" << endl;
    cout << "-----------------" << endl;
    cout << "\033[3;0H" << "Title: ";
    getline(cin, title);
    cout << "\033[3;" << 15 + title.length() << "H" << "Description: ";
    getline(cin, description);
    cout << "\033[4;0H" << "Genre: ";
    getline(cin, genre);
    cout << "\033[4;" << 15 + title.length() << "H" << "Rating: ";
    cin >> rating;
    cout << "\033[5;0H" << "Duration: ";
    cin >> duration;
    Movie movie(title, description, genre, rating, duration);
    admin->AddMovie(movie);
    cin.ignore(numeric_limits<streamsize>::max(), '\n');
}
void AdminUI::editMovie()
{
    string title;
    cout << "Edit Movie" << endl;
    cout << "-----------------" << endl;
    cout << "\033[3;0H" << "Enter Movie Name: ";
    getline(cin, title);
    Movie *movie = System::searchMoviebytitle(title);
    if (movie == nullptr)
    {
        cout << "Movie not found!" << endl;
        return;
    }

    string newDesc = movie->get_desc();
    string newGenre = movie->get_genre();
    float newRating = movie->get_rating();
    float newDuration = movie->get_duration();

    int selected = 0;
    bool editing = true;

    while (editing)
    {
        system("cls");
        cout << "Edit Movie" << endl;
        cout << "-----------------" << endl;
        cout << "Title: " << movie->get_title() << endl;
        cout << (selected == 0 ? "\033[32m> " : "  ") << "Description: " << newDesc << "\033[0m" << endl;
        cout << (selected == 1 ? "\033[32m> " : "  ") << "Genre: " << newGenre << "\033[0m" << endl;
        cout << (selected == 2 ? "\033[32m> " : "  ") << "Rating: " << newRating << "\033[0m" << endl;
        cout << (selected == 3 ? "\033[32m> " : "  ") << "Duration: " << newDuration << " hours\033[0m" << endl;
        cout << "\nPress ESC to save" << endl;

        int key = _getch();

        switch (key)
        {
        case 72: // UP arrow
            selected = (selected - 1 + 4) % 4;
            break;
        case 80:
            selected = (selected + 1) % 4;
            break;
        case 13:
        {
            system("cls");
            cout << "Edit Movie" << endl;
            cout << "-----------------" << endl;

            if (selected == 0)
            {
                cout << "New Description: ";
                getline(cin, newDesc);
            }
            else if (selected == 1)
            {
                cout << "New Genre: ";
                getline(cin, newGenre);
            }
            else if (selected == 2)
            {
                cout << "New Rating: ";
                cin >> newRating;
                cin.ignore();
            }
            else if (selected == 3)
            {
                cout << "New Duration in hours: ";
                cin >> newDuration;
                cin.ignore();
            }
            break;
        }
        case 27:
        {
            admin->modifyMovie(movie, newDesc, newGenre, newRating, newDuration);

            system("cls");
            cout << "\033[32mMovie Updated Successfully!\033[0m" << endl;
            editing = false;
            break;
        }
        }
    }
    return;
}
void AdminUI::deleteMovie()
{
    string title;
    cout << "Delete Movie" << endl;
    cout << "-----------------" << endl;
    cout << "\033[3;0H" << "Enter Movie Name: ";
    getline(cin, title);
    Movie *movie = System::searchMoviebytitle(title);
    if (movie == nullptr)
    {
        cout << "Movie not found!" << endl;
        return;
    }

    admin->deleteMovie(movie);
    cout << "Movie deleted successfully!" << endl;
    cout << "Movie not found!" << endl;
}
void AdminUI::displayAllMovies()
{
    cout << "All Movies" << endl;
    cout << "-----------------" << endl;
    for (auto &movie : System::movies)
    {
        cout << "Title: " << movie.get_title() << endl;
        cout << "Description: " << movie.get_desc() << endl;
        cout << "Genre: " << movie.get_genre() << endl;
        cout << "Rating: " << movie.get_rating() << endl;
        cout << "Duration: " << movie.get_duration() << " hours" << endl;
        cout << "-----------------" << endl;
    }
}
void AdminUI::createShowtime()
{
    cout << "Create New Showtime" << endl;
    cout << "-----------------" << endl;
    cout << "\033[3;0H" << "Enter Movie Name: ";
    string title;
    getline(cin, title);
    Movie *movie = System::searchMoviebytitle(title);
    if (movie == nullptr)
    {
        cout << "Movie not found!" << endl;
        return;
    }

    cout << "\033[4;0H" << "Enter Number of Showtimes: ";
    int numShowtimes;
    cin >> numShowtimes;
    system("cls");
    for (int i = 0; i < numShowtimes; i++)
    {
        cout << "Showtime " << i + 1 << endl;
        cout << "-----------------" << endl;
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        cout << "\033[" << 3 + (5 * i) << ";0H" << "Enter Date: ";
        string date;
        getline(cin, date);
        cout << "\033[" << 4 + (5 * i) << ";0H" << "Enter Time: ";
        float time;
        cin >> time;
        cout << "\033[" << 5 + (5 * i) << ";0H" << "Enter Number of seats: ";
        int seats;
        cin >> seats;
        Showtime showtime = Showtime(date, time, seats);
        movie->getShowTimes().push_back(showtime);
    }
    cin.ignore(numeric_limits<streamsize>::max(), '\n');
}
void AdminUI::editShowtime()
{
    cout << "Edit Showtime" << endl;
    cout << "-----------------" << endl;
    cout << "\033[3;0H" << "Enter Movie Name: ";
    string title;
    getline(cin, title);
    Movie *movie = System::searchMoviebytitle(title);
    if (movie == nullptr)
    {
        cout << "Movie not found!" << endl;
        return;
    }

    system("cls");
    for (int i = 0; i < movie->getShowTimes().size(); i++)
    {
        cout << "Showtime " << i + 1 << endl;
        cout << "-----------------" << endl;
        cout << "\033[" << 3 + (5 * i) << ";0H" << "Enter Date: " << "\033[33m" << movie->getShowTimes()[i].getDate() << "\033[0m";
        cout << "\033[" << 3 + (5 * i) << ";40H";
        string Date;
        getline(cin, Date);
        if (Date != "")
        {
            movie->getShowTimes()[i].setDate(Date);
        }
        cout << "\033[" << 4 + (5 * i) << ";0H" << "Enter Time: " << "\033[33m" << movie->getShowTimes()[i].getTime() << "\033[0m";
        cout << "\033[" << 4 + (5 * i) << ";40H";
        string timeStr;
        getline(cin, timeStr);
        if (timeStr != "")
        {
            movie->getShowTimes()[i].setTime(stof(timeStr));
        }
        cout << "\033[" << 5 + (5 * i) << ";0H" << "Enter Number of seats: " << "\033[33m" << movie->getShowTimes()[i].getSeats() << "\033[0m";
        cout << "\033[" << 5 + (5 * i) << ";40H";
        string seats;
        getline(cin, seats);
        if (seats != "")
        {
            movie->getShowTimes()[i].setSeats(stoi(seats));
        }
    }
}
void AdminUI::deleteShowtime()
{
    cout << "Edit Showtime" << endl;
    cout << "-----------------" << endl;
    cout << "\033[3;0H" << "Enter Movie Name: ";
    string title;
    getline(cin, title);
    Movie *movie = System::searchMoviebytitle(title);
    if (movie == nullptr)
    {
        cout << "Movie not found!" << endl;
        return;
    }

    cout << "\033[4;0H" << "Enter Date: ";
    string date;
    getline(cin, date);
    cout << "\033[5;0H" << "Enter Time: ";
    float time;
    cin >> time;
    bool found = false;
    system("cls");
    for (int i = 0; i < movie->getShowTimes().size(); i++)
    {
        if (movie->getShowTimes()[i].getDate() == date && movie->getShowTimes()[i].getTime() == time)
        {
            movie->getShowTimes().erase(movie->getShowTimes().begin() + i);
            found = true;
            break;
        }
    }
    if (found)
    {
        cout << "Showtime deleted successfully!" << endl;
    }
    else
    {
        cout << "Showtime not found!" << endl;
    }
    cin.ignore(numeric_limits<streamsize>::max(), '\n');
}