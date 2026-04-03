const fs = require("fs");
const [, , command, ...args] = process.argv;

//read From File
const readProducts = () => {
  try {
    const products = fs.readFileSync("./products.json", { encoding: "utf-8" });
    return JSON.parse(products);
  } catch (e) {
    return [];
  }
};

//Write to File
const writeProducts = (products) => {
  fs.writeFileSync("./products.json", JSON.stringify(products, null, 2));
};

const addNewProduct = (Name, Price) => {
  const product = {
    id: Date.now(),
    Name: Name,
    Price: Price,
  };

  const products = readProducts();
  products.push(product);

  writeProducts(products);
};

const listAllProducts = () => {
  const productsArr = readProducts();
  console.log(productsArr);
};

const updateProductName = (args) => {
  const productsArr = readProducts();
  const productIndex = productsArr.findIndex((prd) => prd.id == args[0]);

  if (productIndex != -1) {
    const nameIndex = args.indexOf("--name");
    const priceIndex = args.indexOf("--price");

    if (nameIndex != -1) productsArr[productIndex].Name = args[nameIndex + 1];
    if (priceIndex != -1)
      productsArr[productIndex].Price = args[priceIndex + 1];

    writeProducts(productsArr);
  } else {
    console.log("Product Not Found");
  }
};

const deleteProduct = (id) => {
  const productsArr = readProducts();
  const productIndex = productsArr.findIndex((prd) => prd.id == id);
  if (productIndex != -1) {
    productsArr.splice(productIndex, 1);
    writeProducts(productsArr);
  } else {
    console.log("Product Not Found");
  }
};

switch (command) {
  case "add":
    addNewProduct(args[0], args[1]);
    break;
  case "list":
    listAllProducts();
    break;
  case "update":
    updateProductName(args);
    break;
  case "delete":
    deleteProduct(args[0]);
    break;
}
