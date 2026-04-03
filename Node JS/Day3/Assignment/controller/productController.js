import product from "../models/productModel.js";

//CRUD

//create
export const createProduct = async (req, res) => {
  const { name, price } = req.body;
  const newProduct = new product({ name, price });
  await newProduct.save();
  res.status(201).json({ data: newProduct });
};

export const getAllProducts = async (req, res) => {
  const products = await product.find();
  res.status(200).json({ data: products });
};

export const updateProduct = async (req, res) => {
  const { id } = req.params;
  const updatedProduct = await product.findByIdAndUpdate(id, req.body, {
    new: true,
  });
  res.status(200).json({ data: updatedProduct });
};

export const deleteProduct = async (req, res) => {
  const { id } = req.params;
  const deletedProduct = await product.findByIdAndDelete(id);
  res.status(200).json({ data: deletedProduct });
};
