#include <iostream>
#include <vector>
using namespace std;

class Author {
    string name;
    string nationality;

public:
    /*Constructors*/
    Author() {
        name = "Unknown";
        nationality = "Unknown";
    }
    Author(string name, string nationality) : name(name), nationality(nationality) {}

    /*Getters*/
    string getName() { return name; }
    string getNationality() { return nationality; }
};

class Book {
    string title{"unknown"};
    int publish_year{0};
    Author author;

public:
    /*Constructors*/
    Book() = default;
    Book(string title, int year, string auth_name, string auth_nationality) : title(title), publish_year(year), author(auth_name, auth_nationality) {}

    /*Getters*/
    string getTitle() { return title; }
    int getPublishYear() { return publish_year; }
    string getAuthorName() { return author.getName(); }
    string getAuthorNationality() { return author.getNationality(); }

};

class Library {
    vector<Book*> books;
public:
    void addBook(Book* book) {
        books.push_back(book);
    }

    void listBooks() {
        cout << "-----------------------Library Books-------------------" << endl;
        for (auto i : books) {
            cout << i->getTitle() << ", authored by: " << i->getAuthorName() << " (" << i->getAuthorNationality() << "), in " << i->getPublishYear() << endl;
        }
    }
};


int main() {
    Book b1("Wonder", 2012, "Gorge Orwell", "British");
    Book b2("Animal Farm", 1945, "Gorge Orwell", "British");
    Book b3;
    Library L;
    L.addBook(&b1);
    L.addBook(&b2);
    L.listBooks();

    cout << "----------------" << endl;
    b3 = b1;
    cout << "Title of b3:" << b3.getTitle() << endl;;

    return 0;
}