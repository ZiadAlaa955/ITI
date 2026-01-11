#ifndef SHOWTIME_HPP
#define SHOWTIME_HPP
#include <iostream>
#include <map>
using namespace std;

class Showtime
{
private:
    string date;
    float time;
    map<int, bool> seats;

public:
    Showtime(string date, float time, int seatsCount);
    string getDate();
    float getTime();
    int getSeats();
    int setSeats(int seats);
    void setTime(float time);
    void setDate(string date);
    void displaySeats(int row, int column);
    void reserveSeat(int seat);
    void releaseSeat(int seat);
    bool checkSeatAvailability(int seat);
    bool hasAvailableSeats();
};
#endif