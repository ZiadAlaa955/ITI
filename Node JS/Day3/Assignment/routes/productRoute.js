import express from "express";
import {
  createProduct,
  getAllProducts,
  updateProduct,
  deleteProduct,
} from "../controller/productController.js";

const router = express.Router();

router.post("/", createProduct);
router.get("/", getAllProducts);
router.patch("/:id", updateProduct);
router.delete("/:id", deleteProduct);

export default router;
