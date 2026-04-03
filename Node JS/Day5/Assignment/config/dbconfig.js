import mongoose from "mongoose";

export const connectDBs = async () => {
  try {
    await mongoose.connect(process.env.MONGO_URI);
    console.log("Connected to Database");
  } catch (error) {
    console.log("error connecting to Database: ", error);
  }
};
