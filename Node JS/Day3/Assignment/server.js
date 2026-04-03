import express from "express";
import mongoose from "mongoose";
import productRoute from "./routes/productRoute.js";

//Express setup
const app = express();
app.use(express.json());
app.use("/product", productRoute);

//Mongoose connection
mongoose
  .connect("mongodb://localhost:27017/productsDB")
  .then(() => {
    console.log("Connected to Database");
  })
  .catch((err) => {
    console.log("Error: ", err);
  });

app.listen(3000, () => {
  console.log("Server is running");
});
