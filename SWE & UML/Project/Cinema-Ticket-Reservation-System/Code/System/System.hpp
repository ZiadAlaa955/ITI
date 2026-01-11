#ifndef SYSTEM_HPP
#define SYSTEM_HPP

#include "../Movie/Movie.hpp"
#include <vector>
using namespace std;

class System
{
public:
    static vector<Movie> movies;

    static Movie *searchMoviebytitle(string title);
    static string getTodayDate();
    static vector<Movie> searchMoviebydate(string date);
};

#endif