#ifndef MOVIE_HPP
#define MOVIE_HPP
#include <iostream>
#include <vector>
#include "../ShowTime/ShowTime.hpp"

class Movie
{

private:
    string title;
    string desc;
    string genre;
    float rating;
    float duration;
    vector<Showtime> showtimes;

public:
    Movie() = default;
    Movie(string title, string desc, string genre, float rating, float duration);
    string get_title();
    string get_desc();
    string get_genre();
    float get_rating();
    float get_duration();
    vector<Showtime> &getShowTimes();
    void set_desc(string desc);
    void set_genre(string genre);
    void set_rating(float rating);
    void set_duration(float duration);
    bool isAvailableOn(string date);
};
#endif