import userModel from "../models/userModel.js";
import jwt from "jsonwebtoken";

const genToken = (user) => {
  return jwt.sign(
    {
      userId: user._id,
      username: user.username,
      email: user.email,
      role: user.role,
    },
    process.env.JWT_SECRET,
    {
      expiresIn: process.env.JWT_EXPIRES_IN,
    },
  );
};

const createError = (status, message) => {
  const error = new Error(message);
  error.status = status;
  return error;
};

export const register = async (req, res, next) => {
  try {
    const { username, email, password, role } = req.body;
    const exists = await userModel.findOne({ email: email });
    if (exists) {
      throw createError(409, "Email is already in use");
    }
    const newUser = new userModel({ username, email, password, role });
    await newUser.save();

    newUser.password = undefined; //Hide password
    const token = genToken(newUser);
    res.status(201).json({ success: true, user: newUser, token: token });
  } catch (error) {
    next(error);
  }
};

export const login = async (req, res, next) => {
  try {
    const { email, password } = req.body;
    const existUser = await userModel.findOne({ email: email });
    if (!existUser) {
      throw createError(401, "Invalid email or password");
    }

    const isPasswordMatch = await existUser.comparePassword(password);
    if (!isPasswordMatch) {
      throw createError(401, "Invalid email or password");
    }
    existUser.password = undefined;

    const token = genToken(existUser);
    res.status(200).json({
      success: true,
      message: "login scucessful",
      user: existUser,
      token: token,
    });
  } catch (error) {
    next(error);
  }
};

export const profile = async (req, res) => {
  if (req.user.role == "admin") {
    return res.json({ message: "Welcome to admin profile", user: req.user });
  }
  res.json({ message: "Welcome to profile", user: req.user });
};
