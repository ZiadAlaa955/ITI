function Book(
  title,
  numOfChapters,
  author,
  numOfPages,
  publisher,
  numOfCopies
) {
  this.title = title;
  this.numOfChapters = numOfChapters;
  this.author = author;
  this.numOfPages = numOfPages;
  this.publisher = publisher;
  this.numOfCopies = numOfCopies;
}

function Box(height, width, length, material) {
  /*Properties */
  this.height = height;
  this.width = width;
  this.length = length;
  this.volume = width * height * length;
  this.material = material;
  this.content = [];
  this.numOfBooks = 0;

  /*Methods */
  this.addBook = function (
    title,
    numOfChapters,
    author,
    numOfPages,
    publisher,
    numOfCopies
  ) {
    let book = new Book(
      title,
      numOfChapters,
      author,
      numOfPages,
      publisher,
      numOfCopies
    );
    let len = this.content.length;
    let found = false;
    for (let i = 0; i < len; i++) {
      if (this.content[i].title == book.title) {
        this.numOfBooks += numOfCopies;
        this.content[i].numOfCopies += numOfCopies;
        found = true;
        break;
      }
    }
    if (found == false) {
      this.content.push(book);
      this.numOfBooks += numOfCopies;
    }
  };
  this.removeBook = function (title) {
    let len = this.content.length;
    let found = false;
    for (let i = 0; i < len; i++) {
      if (this.content[i].title == title) {
        if (this.content[i].numOfCopies > 1) {
          this.content[i].numOfCopies--;
          this.numOfBooks--;
        } else {
          this.content.splice(i, 1);
          this.numOfBooks--;
        }
        found = true;
        break;
      }
    }
    if (found == false) {
      throw "Book not found";
    }
  };
  this.displayBooks = function () {
    for (let i = 0; i < this.content.length; i++) {
      let book = this.content[i];
      console.log(
        "Book " +
          (i + 1) +
          ": " +
          book.title +
          "(" +
          book.author +
          ", " +
          book.publisher +
          ")" +
          "| copies: " +
          book.numOfCopies
      );
    }
  };
  this.Count = function () {
    return this.numOfBooks;
  };
}

let box = new Box(10, 20, 30, "sdrf");
box.addBook("book1", 3, "abc", 100, "xyz", 2);
box.addBook("book2", 5, "abc", 200, "xyz", 1);
box.removeBook("book1");
box.displayBooks();
console.log(box.Count());
