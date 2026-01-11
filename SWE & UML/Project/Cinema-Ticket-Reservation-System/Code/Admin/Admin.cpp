#include "Admin.hpp"

void Admin::AddMovie(Movie &movie)
{
    System::movies.push_back(movie);
    cout << "Movie Added Successfully!" << endl;
}
void Admin::modifyMovie(Movie *movie, string newDesc, string newGenre, float newRating, float newDuration)
{
    movie->set_desc(newDesc);
    movie->set_genre(newGenre);
    movie->set_rating(newRating);
    movie->set_duration(newDuration);
}

void Admin::deleteMovie(Movie *movie)
{
    for (auto it = System::movies.begin(); it != System::movies.end(); ++it)
    {
        if (it->get_title() == movie->get_title())
        {
            System::movies.erase(it);
            break;
        }
    }
}

void Admin::createShowTime(Movie* movie, string date, float time,int seats)
{
            Showtime newShowtime(date, time, seats);
            movie->getShowTimes().push_back(newShowtime);
}
void Admin::modifyShowTime(Movie* movie,int index, string Date, string time,string seats){
    if(Date != "") {
    movie->getShowTimes()[index].setDate(Date);
    }
    if(time != "") {
        movie->getShowTimes()[index].setTime(stof(time));
    }
    if(seats != "") {
        movie->getShowTimes()[index].setSeats(stoi(seats));
    }
}
bool Admin::deleteShowTime(Movie* movie, string date, float time)
{
    for(int i=0;i<movie->getShowTimes().size();i++){
       if(movie->getShowTimes()[i].getDate() == date && movie->getShowTimes()[i].getTime() == time){
           movie->getShowTimes().erase(movie->getShowTimes().begin()+i);
          return true;
       }
   }
   return false;
}