import category from "../models/categoryModel.js";

export const getAllCategories = async (req, res) => {
  const categoriesArray = await category.find();
  res.status(200).json({ success: true, data: categoriesArray });
};

export const createCategory = async (req, res) => {
  const { name, description } = req.body;
  const newCategory = new category({ name, description });
  await newCategory.save();
  res.status(201).json({ success: true, data: newCategory });
};
