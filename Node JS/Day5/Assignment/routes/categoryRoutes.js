import express from "express";
import { authN, authZ } from "../middlewares/authMiddleware.js";
import {
  getAllCategories,
  createCategory,
} from "../controllers/categoryController.js";

const router = express.Router();

router.get("/category", getAllCategories);
router.post("/category", createCategory);

export default router;
