#include <iostream>
#include <vector>

class Ticket
{

private:
    std::string movieTitle;
    std::string date;
    float time;
    float price;
    std::vector<int> seats;

public:
    Ticket() = default;
    Ticket(std::string movieTitle, std::string date, float time, float price, std::vector<int> seats);

    float getPrice()
    {
        return price;
    }

    std::string getMovieTitle()
    {
        return movieTitle;
    }

    std::string getDate()
    {
        return date;
    }

    float getTime()
    {
        return time;
    }

    std::vector<int> getSeats()
    {
        return seats;
    }
};