#include "ShowTime.hpp"

Showtime::Showtime(string date, float time, int seatsCount)
{
    this->date = date;
    this->time = time;
    for (int i = 1; i <= seatsCount; i++)
    {
        this->seats[i] = true;
    }
}
string Showtime::getDate()
{
    return this->date;
}
float Showtime::getTime()
{
    return this->time;
}
int Showtime::getSeats()
{
    return this->seats.size();
}
void Showtime::setTime(float time)
{
    this->time = time;
}
void Showtime::setDate(string date)
{
    this->date = date;
}
int Showtime::setSeats(int seats)
{
    this->seats.clear();
    for (int i = 1; i <= seats; i++)
    {
        this->seats[i] = true;
    }
    return this->seats.size();
}
void Showtime::reserveSeat(int seat)
{
    this->seats[seat] = false;
}

void Showtime::releaseSeat(int seat)
{
    this->seats[seat] = true;
}
bool Showtime::checkSeatAvailability(int seat)
{
    if (seats.find(seat) != seats.end())
    {
        return seats[seat];
    }
    return false;
}
bool Showtime::hasAvailableSeats()
{
    for (auto &seat : seats)
    {
        if (seat.second == true)
        {
            return true;
        }
    }
    return false;
}
void Showtime::displaySeats(int row, int col)
{
    map<int, bool>::iterator it;
    int column = col;
    for (it = this->seats.begin(); it != this->seats.end(); it++)
    {
        if (column == 50 + col)
        {
            row += 2;
            column = col;
        }
        cout << "\033[" << row << ";" << column << "H";
        column += 5;
        if (it->second == false)
            cout << "\033[31m" << it->first << "\033[0m";
        else
            cout << "\033[32m" << it->first << "\033[0m";
    }
}