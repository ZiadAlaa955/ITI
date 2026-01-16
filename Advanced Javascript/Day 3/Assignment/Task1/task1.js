function shape() {
  if (this.constructor == shape) {
    throw "You cannot access abstract class";
  }
}

/////////////////////////////////////
function rectangle(width, height) {
  if (this.constructor == rectangle) {
    if (rectangle.isCreated == true) {
      throw "Rectangle is already created";
    } else {
      rectangle.isCreated = true;
    }
  }

  shape.call(this);

  Object.defineProperty(this, "width", {
    value: width,
  });

  Object.defineProperty(this, "height", {
    value: height,
  });
}

rectangle.prototype = Object.create(shape.prototype);
rectangle.prototype.constructor = rectangle;

rectangle.isCreated = false;

rectangle.prototype.Area = function () {
  return this.width * this.height;
};

rectangle.prototype.Perimeter = function () {
  return 2 * (this.width + this.height);
};

rectangle.prototype.toString = function () {
  return (
    "width = " +
    this.width +
    ", height = " +
    this.height +
    ", area = " +
    this.Area() +
    ", perimeter = " +
    this.Perimeter()
  );
};

rectangle.prototype.valueOf = function () {
  return this.Area();
};
///////////////////////////////////
function square(width) {
  if (square.isCreated == true) {
    throw "square is alreday created";
  } else {
    rectangle.call(this, width, width);

    square.count++;

    square.isCreated = true;
  }
}

square.prototype = Object.create(rectangle.prototype);
square.prototype.constructor = square;

square.count = 0;

square.isCreated = false;

square.prototype.Area = function () {
  return this.width * this.width;
};

square.prototype.Perimeter = function () {
  return 4 * this.width;
};

square.prototype.toString = function () {
  return (
    "width = " +
    this.width +
    ", area = " +
    this.Area() +
    ", perimeter = " +
    this.Perimeter()
  );
};

square.prototype.valueOf = function () {
  return this.Area();
};

///////////TESTING/////////////
console.log("Rectangle:");
let rec = new rectangle(10, 20);
console.log(rec.toString());
// let rec2 = new rectangle(5, 30);
// console.log(rec2.toString());
// console.log(rec + rec2);
// console.log(rec - rec2);

console.log("");
console.log("Square:");
let sqr = new square(10);
console.log(sqr.toString());
console.log(square.count);
// let sqr2 = new square(10);

console.log("");
console.log("Shape:");
let shp = new shape();
