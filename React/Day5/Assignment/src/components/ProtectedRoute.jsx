import { Navigate } from "react-router";

const ProtectedRoute = ({ children }) => {
  const isAuthenticated = localStorage.getItem("currentUser");

  if (!isAuthenticated) {
    return <Navigate to="/login" replace />;
  }

  return children;
};

export default ProtectedRoute;
