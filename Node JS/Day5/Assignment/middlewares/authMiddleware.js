import jwt from "jsonwebtoken";

export const authN = async (req, res, next) => {
  try {
    const token = req.headers.authorization;
    if (!token) {
      return res.status(401).json({ message: "No token sent" });
    }

    const payload = jwt.verify(token, process.env.JWT_SECRET);
    req.user = payload;
    next();
  } catch (error) {
    error.status = 403;
    error.message = "invalid or expired token";
    next(error);
  }
};

export const authZ = (role) => {
  return (req, res, next) => {
    if (!req.user || role != req.user.role) {
      return res.status(403).json({ message: "forbidden" });
    }
    next();
  };
};
