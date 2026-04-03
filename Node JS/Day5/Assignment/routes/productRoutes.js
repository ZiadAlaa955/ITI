import express from "express";
import { authN, authZ } from "../middlewares/authMiddleware.js";
import {
  getAllProducts,
  createProduct,
} from "../controllers/productController.js";

const router = express.Router();
router.get("/products", authN, getAllProducts);
router.post("/product", authN, authZ("admin"), createProduct);

export default router;
