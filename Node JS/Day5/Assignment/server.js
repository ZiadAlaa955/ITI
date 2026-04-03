import express from "express";
import { connectDBs } from "./config/dbconfig.js";
import authRoutes from "./routes/authRoutes.js";
import productRoutes from "./routes/productRoutes.js";
import cateoryRoutes from "./routes/categoryRoutes.js";
import dotenv from "dotenv";
import { handleError } from "./middlewares/errorHandler.js";

dotenv.config();

const app = express();
app.use(express.json());

connectDBs();

app.use("/user", authRoutes);
app.use("/", productRoutes);
app.use("/", cateoryRoutes);
app.use(handleError);

app.listen(3000, () => {
  console.log("server is running at port 3000");
});
