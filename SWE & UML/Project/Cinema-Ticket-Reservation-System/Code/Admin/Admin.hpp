#ifndef ADMIN_FILE
#define ADMIN_FILE

#include <iostream>
#include "../Person/Person.hpp"

using namespace std;

class Admin : public Person
{
public:
    void AddMovie(Movie &movie);
    void modifyMovie(Movie *movie, string newDesc, string newGenre, float newRating, float newDuration);
    void deleteMovie(Movie *movie);
    void createShowTime(Movie *movie, string date, float time, int seats);
    void modifyShowTime(Movie *movie, int index, string Date, string time, string seats);
    bool deleteShowTime(Movie *movie, string date, float time);
};

#endif