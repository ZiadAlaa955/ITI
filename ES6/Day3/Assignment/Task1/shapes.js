class Polygon {
  constructor() {
    if (this.constructor == Polygon) {
      throw "You cannot access abstract class";
    }
  }

  calcArea() {}

  toString() {}
}
//--------------------------------------------
class Rectangle extends Polygon {
  constructor(width, height) {
    super();
    this.width = width;
    this.height = height;
  }
  calcArea() {
    return this.width * this.height;
  }
  toString() {
    return `width = ${this.width}, height = ${this.height}, area = ${this.calcArea()}`;
  }
}

let rect = new Rectangle(10, 20);
console.log(rect.toString());
//--------------------------------------------
class Square extends Polygon {
  constructor(side) {
    super();
    this.side = side;
  }
  calcArea() {
    return this.side * this.side;
  }
  toString() {
    return `side = ${this.side}, area = ${this.calcArea()}`;
  }
}

let sqr = new Square(10);
console.log(sqr.toString());
//--------------------------------------------
class Circle extends Polygon {
  constructor(radius) {
    super();
    this.radius = radius;
  }
  calcArea() {
    return (Math.PI * this.radius ** 2).toFixed(2);
  }
  toString() {
    return `radius = ${this.radius}, area = ${this.calcArea()}`;
  }
}

let crcl = new Circle(15);
console.log(crcl.toString());
//--------------------------------------------
class Triangle extends Polygon {
  constructor(height, base) {
    super();
    this.height = height;
    this.base = base;
  }
  calcArea() {
    return (this.height * this.base) / 2;
  }
  toString() {
    return `height = ${this.height}, base = ${this.base}, area = ${this.calcArea()}`;
  }
}

let tringl = new Triangle(10, 20);
console.log(tringl.toString());
