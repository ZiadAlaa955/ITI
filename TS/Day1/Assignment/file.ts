//1- Create an interface User with properties name (string) and age (number). and it is required not optional
// required create an object with only the name property.
interface Iuser {
  name: string;
  age: number;
}
let u1: Pick<Iuser, "name"> = {
  name: "Ziad",
};
console.log(u1);

// 2- Create an interface Profile with optional properties username (string) and email (string).
// required create an object with both properties.
interface Iprofile {
  username?: string;
  email?: string;
}
let p1: Required<Iprofile> = {
  username: "Ziad",
  email: "Ziad123@gmail.com",
};
console.log(p1);

// 3- Use Record to create an object where keys are "red", "green", and "blue", and values are their corresponding hex color codes (strings).
// Test by accessing the red key.
type colorName = "red" | "blue" | "green";

let c1: Record<colorName, string> = {
  red: "#FF2C2C",
  green: "#008000",
  blue: "#0000FF",
};
console.log(c1.red);

// 4- Create an interface Person with properties name (string), age (number), and email (string).
// create a new type with only the name and email properties.
// Test by creating an object with these properties.
interface Iperson {
  name: string;
  age: number;
  email: string;
}

type Tperson = Pick<Iperson, "name" | "email">;

let person: Tperson = {
  name: "Ziad",
  email: "Ziad123@gmail.com",
};
console.log(person);

// 5- Use the same Person interface from the previous question.
// create a new type without the age property.
// Test by creating an object with only name and email.
type Tperson2 = Omit<Iperson, "age">;
let person2: Tperson2 = {
  name: "Ziad",
  email: "Ziad123@gmail.com",
};
console.log(person2);

// 6- Create a union type Colors = "red" | "green" | "blue" | "yellow".
// create a new type without "yellow".
// Test by assigning a value of the new type.
type colors = "red" | "green" | "blue" | "yellow";
let myColor: colors = "blue";
myColor = "yellow";

type colorsWithoutYellow = Exclude<colors, "yellow">;
let myColor2: colorsWithoutYellow = "blue";
// myColor2 = "yellow"; //ERROR

// 7- Use the same Colors union type from the previous question.
//    create a new type with only "red" and "blue".
//    Test by assigning a value of the new type.
type colorsRedBlue = Extract<colors, "red" | "blue">;
let myColor3: colorsRedBlue = "blue";
// myColor3 = "green";//ERROR

// 8- Create a union type MaybeString = string | null | undefined.
//    create a new type without null or undefined.
//    Test by assigning a value of the new type.
type mayBeString = string | null | undefined;
let ss: mayBeString = "Ziad";
let ss2: mayBeString = null;
let ss3: mayBeString = undefined;

type MustBeString = Extract<mayBeString, string>;
let s: MustBeString = "Ziad";
// let s2: MustBeString = null; //ERROR
// let s3: MustBeString = undefined; //ERROR
