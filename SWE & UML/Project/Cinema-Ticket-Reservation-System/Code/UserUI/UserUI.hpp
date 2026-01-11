#include "../Movie/Movie.hpp"
#include "../UI/UI.hpp"
#include "../User/User.hpp"

class UserUI : public UI
{

private:
    User *user;

public:
    UserUI();
    void printMenu() override;
    void reserveTicket();
    void selectShowtime(Movie &selectedMovie, string date);
    void selectSeats(Movie &selectedMovie, Showtime &selectedShowtime);
    void viewReservedTickets();
};