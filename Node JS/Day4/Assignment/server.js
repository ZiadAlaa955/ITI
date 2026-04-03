import express from "express";
import mongoose from "mongoose";
import productRoute from "./routes/productRoute.js";
import categoryRoute from "./routes/categoryRoute.js";

//Express setup
const app = express();
app.use(express.json());
app.use("/products", productRoute);
app.use("/categories", categoryRoute);

//Mongoose connection
mongoose
  .connect("mongodb://localhost:27017/productsDB")
  .then(() => {
    console.log("Connected to Database");
  })
  .catch((err) => {
    console.log("Error: ", err);
  });

app.use((err, req, res, next) => {
  console.log(err);
  res.status(err.status || 500).json({
    success: false,
    message: err.message,
  });
});

app.listen(3000, () => {
  console.log("Server is running");
});
