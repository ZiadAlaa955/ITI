#include "Movie/Movie.hpp"
#include "UI/UI.hpp"
#include "AdminUI/AdminUI.hpp"
#include "UserUI/UserUI.hpp"
#include "ShowTime/ShowTime.hpp"
#include "System/System.hpp"

// Forward declaration
void initializeMovies();

int main()
{
    initializeMovies();

    UI ui;
    UI *client;
    client = ui.login();
    if (client)
        client->printMenu();

    /* To run on vs code

    g++ .\UI\UI.cpp
    .\UserUI\UserUI.cpp
    .\AdminUI\AdminUI.cpp
    .\User\User.cpp .\Admin\Admin.cpp
    .\Movie\Movie.cpp
    .\Payment\MasterCard.cpp
    .\Person\Person.cpp
    .\ShowTime\ShowTime.cpp
    .\System\System.cpp
    .\Ticket\Ticket.cpp
    .\main.cpp -o exe
    */
}