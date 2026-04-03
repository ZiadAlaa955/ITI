import mongoose from "mongoose";

const { Schema } = mongoose;
const productSchema = new Schema({
  name: {
    type: String,
    required: true,
    minlength: [3, "name must be at least 3 characters"],
    maxlength: [30, "name must be at most 30 characters"],
    trim: true,
  },
  price: {
    type: Number,
    required: true,
    min: 10,
    max: 1000000,
  },
});
const productModel = mongoose.model("product", productSchema);

export default productModel;
