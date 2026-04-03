import express from "express";

import {
  createCategory,
  getAllCategories,
  getAllProductsOfCategory,
} from "../controller/categoryController.js";

const router = express.Router();

router.post("/", createCategory);
router.get("/", getAllCategories);
router.get("/:categoryID/products", getAllProductsOfCategory);

export default router;
