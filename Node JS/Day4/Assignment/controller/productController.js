import productModel from "../models/productModel.js";

//CRUD

export const createProduct = async (req, res) => {
  const { name, price, category } = req.body;
  const newProduct = new productModel({ name, price, category });
  await newProduct.save();
  res.status(201).json({ data: newProduct });
};

export const getAllProducts = async (req, res) => {
  const products = await productModel
    .find()
    .populate("category", "name description -_id");
  res.status(200).json({ success: true, data: products });
};

export const getProductbyId = async (req, res) => {
  const { id } = req.params;

  const product = await product
    .findById(id)
    .populate("category", "name description -_id");
  if (!product) {
    return res
      .status(404)
      .json({ success: false, message: "product not found" });
  }
  res.status(200).json({ success: true, data: product });
};

export const updateProduct = async (req, res) => {
  const { id } = req.params;
  const updatedProduct = await productModel
    .findByIdAndUpdate(id, req.body, {
      new: true,
    })
    .populate("category", "name description -_id");
  res.status(200).json({ data: updatedProduct });
};

export const deleteProduct = async (req, res) => {
  const { id } = req.params;
  const deletedProduct = await productModel.findByIdAndDelete(id);
  res.status(200).json({ data: deletedProduct });
};
