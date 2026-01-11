#include <iostream>
#include "../UI/UI.hpp"
#include "../Admin/Admin.hpp"

using namespace std;

class AdminUI : public UI
{
private:
    Admin* admin;

public:
    AdminUI();
    void printMenu() override;
    void addMovie();
    void editMovie();
    void deleteMovie();
    void displayAllMovies();
    void createShowtime();
    void editShowtime();
    void deleteShowtime();
};