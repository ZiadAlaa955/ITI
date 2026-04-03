import express from "express";
import fs from "fs/promises";
import { v4 } from "uuid";

//Helpers
const read = async () => {
  try {
    const data = await fs.readFile("./products.json", { encoding: "utf-8" });
    return JSON.parse(data);
  } catch {
    return [];
  }
};
const write = async (products) => {
  await fs.writeFile("./products.json", JSON.stringify(products));
};
const createProduct = (name, price) => {
  return { id: v4(), name, price };
};

const app = express();

//Middleware => parsing JSON data
app.use(express.json());

//HTTP Requests
app.get("/product", async (req, res) => {
  try {
    const products = await read();
    res.status(200).json({ success: true, data: products });
  } catch (error) {
    res.status(500).json({ success: false, message: error.message });
  }
});

app.get("/product/:id", async (req, res) => {
  try {
    const { id } = req.params;
    if (!id) {
      return res
        .status(404)
        .json({ success: false, message: "product not found" });
    }

    const products = await read();
    const product = products.find((prd) => prd.id == id);
    if (product) {
      return res.status(200).json({ success: true, data: product });
    } else {
      return res
        .status(404)
        .json({ success: false, message: "product not found" });
    }
  } catch (error) {
    return res.status(500).json({ success: false, message: error.message });
  }
});

app.post("/product", async (req, res) => {
  try {
    const { name, price } = req.body;
    if (!name || !price) {
      return res
        .status(400)
        .json({ success: false, message: "name and price are required!" });
    } else {
      const product = createProduct(name, price);
      const products = await read();
      products.push(product);
      await write(products);
      return res.status(201).json({ data: product });
    }
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

app.patch("/product/:id", async (req, res) => {
  try {
    const updatedProduct = req.body;
    const { id } = req.params;
    if (!id || !updatedProduct) {
      return res
        .status(400)
        .json({ Message: "id and updated product data are required" });
    }
    const products = await read();
    const productIndex = products.findIndex((prd) => prd.id == id);
    if (productIndex != -1) {
      products[productIndex] = { ...products[productIndex], ...updatedProduct };
      await write(products);
      return res.status(200).json({ data: products[productIndex] });
    } else {
      return res.status(404).json({ message: "product not found" });
    }
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

app.put("/product/:id", async (req, res) => {
  try {
    const updatedProduct = req.body;
    const { id } = req.params;
    if (!id || !updatedProduct.name || !updatedProduct.price) {
      return res
        .status(400)
        .json({ message: "id, name and price data are required" });
    }
    const products = await read();
    const productIndex = products.findIndex((prd) => prd.id == id);
    if (productIndex != -1) {
      products[productIndex] = {
        id: id,
        name: updatedProduct.name,
        price: updatedProduct.price,
      };
      await write(products);
      return res.status(200).json({ data: products[productIndex] });
    } else {
      return res.status(404).json({ message: "product not found" });
    }
  } catch (error) {
    res.status(500).json({ Error: error.message });
  }
});

app.delete("/product/:id", async (req, res) => {
  try {
    const { id } = req.params;
    const products = await read();
    const productIndex = products.findIndex((prd) => prd.id == id);
    if (productIndex != -1) {
      products.splice(productIndex, 1);
      await write(products);
      res.status(200).json({ success: true, data: products });
    } else {
      return res
        .status(404)
        .json({ success: false, message: "product not found" });
    }
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

app.listen(5000, () => {
  console.log("Server is running....");
});
