import product from "../models/productModel.js";

export const getAllProducts = async (req, res, next) => {
  try {
    const productList = await product
      .find()
      .populate("category", "name description -_id");
    if (productList.length === 0) {
      return res
        .status(404)
        .json({ success: false, message: "There are no products" });
    }
    res
      .status(200)
      .json({ success: true, products: productList, user: req.user });
  } catch (err) {
    next(err);
  }
};

export const createProduct = async (req, res, next) => {
  try {
    const { name, price, category } = req.body;
    const newProduct = product({ name, price, category });
    await newProduct.save();
    res.status(201).json({ success: true, product: newProduct });
  } catch (err) {
    next(err);
  }
};
