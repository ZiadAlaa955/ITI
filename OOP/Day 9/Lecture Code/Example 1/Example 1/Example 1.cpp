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
    string title;
    int publish_year;
    Author* author; // Author author (object)

public:
    /*Constructors*/
    Book(string title, int year, string auth_name, string auth_nationality) : title(title), publish_year(year) {
        author = new Author(auth_name, auth_nationality);
    }

    /*Getters*/
    string getTitle() { return title; }
    int getPublishYear() { return publish_year; }
    string getAuthorName() { return author->getName(); }
    string getAuthorNationality() { return author->getNationality(); }

    /*Destructor*/
    ~Book() {
        delete author;
    }
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

class Member {
    string name;
    int id;
public:
    Member(string name, int id) :name(name), id(id) {}

    void borrowBook(Book& book) {
        cout << "Member: " << name << " borrowed \"" << book.getTitle() << "\"" << endl;
    }
};


int main() {
    Book b1("1984", 1949, "Gorge Orwell", "British");
    Book b2("Animal Farm", 1945, "Gorge Orwell", "British");

    Library L;
    L.addBook(&b1);
    L.addBook(&b2);
    L.listBooks();

    Member m("Ziad", 1);
    m.borrowBook(b2);
    return 0;
}