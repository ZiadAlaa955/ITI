import category from "../models/categoryModel.js";
import product from "../models/productModel.js";

export const createCategory = async (req, res) => {
  const { name, description } = req.body;
  const newCategory = new category({ name, description });
  await newCategory.save();
  res.status(201).json({ success: true, data: newCategory });
};

export const getAllCategories = async (req, res) => {
  const categoriesArray = await category.find();
  res.status(200).json({ success: true, data: categoriesArray });
};

export const getAllProductsOfCategory = async (req, res) => {
  const { categoryID } = req.params;
  if (!categoryID) {
    return res.status(400).json({ message: "Category is required" });
  }

  const CategoryProducts = await product.find({ category: categoryID });
  res.status(200).json({ success: true, products: CategoryProducts });
};
