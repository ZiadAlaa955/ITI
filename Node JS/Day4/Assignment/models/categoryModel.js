import mongoose from "mongoose";

const { Schema } = mongoose;
const categorySchema = new Schema({
  name: {
    type: String,
    required: true,
    unique: true,
  },
  description: {
    type: String,
  },
});
const catergoryModel = mongoose.model("category", categorySchema);

export default catergoryModel;
