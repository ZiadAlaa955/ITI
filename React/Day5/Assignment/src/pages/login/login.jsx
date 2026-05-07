import { useState } from "react";
import { Link, useNavigate } from "react-router"; // Ensure you use react-router for navigation
import axios from "axios";
import "./login.css";
import { toast } from "react-toastify";

const Login = () => {
  const navigate = useNavigate();
  const [showPassword, setShowPassword] = useState(false);

  // 1. State for form data and errors
  const [formData, setFormData] = useState({
    email: "",
    password: "",
  });
  const [error, setError] = useState("");

  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword);
  };

  // 2. Handle input changes dynamically
  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
    setError(""); // Clear errors when the user starts typing
  };

  // 3. Handle Form Submission & Login Logic
  const handleSubmit = (e) => {
    e.preventDefault();

    // Fetch all users from the JSON database
    axios
      .get("http://localhost:3000/users")
      .then((res) => {
        const users = res.data;

        // Find a user that matches both the email and password
        const validUser = users.find(
          (user) =>
            user.email === formData.email &&
            user.password === formData.password,
        );

        if (validUser) {
          // Success! Save user to localStorage
          localStorage.setItem("currentUser", JSON.stringify(validUser));
          toast.success(`Welcome back, ${validUser.fullName}!`);
          // Redirect to homepage
          navigate("/");
        } else {
          // Failure: No match found
          toast.error("Invalid email or password. Please try again.");
        }
      })
      .catch((err) => {
        console.error("Login error:", err);
        setError("Could not connect to the server.");
      });
  };

  return (
    <div className="tech-login-wrapper">
      <div className="tech-login-card">
        <h1 className="tech-login-title">Tech News</h1>
        <p className="tech-login-subtitle">
          Sign in to access premium intelligence.
        </p>

        {/* Display Error Message if Login Fails */}
        {error && <div className="tech-login-error-alert">{error}</div>}

        <form className="tech-login-form" onSubmit={handleSubmit}>
          <div className="tech-login-input-group">
            <input
              type="email"
              name="email"
              className="tech-login-input-field"
              placeholder="Email Address"
              required
              value={formData.email}
              onChange={handleChange}
            />
          </div>

          <div className="tech-login-input-group tech-login-password-group">
            <input
              type={showPassword ? "text" : "password"}
              name="password"
              className="tech-login-input-field"
              placeholder="Password"
              required
              value={formData.password}
              onChange={handleChange}
            />
            <span
              className="tech-login-password-toggle-icon"
              onClick={togglePasswordVisibility}
            >
              {showPassword ? (
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="20"
                  height="20"
                  viewBox="0 0 24 24"
                  fill="none"
                  stroke="currentColor"
                  strokeWidth="2"
                  strokeLinecap="round"
                  strokeLinejoin="round"
                >
                  <path d="M17.94 17.94A10.07 10.07 0 0 1 12 20c-7 0-11-8-11-8a18.45 18.45 0 0 1 5.06-5.94M9.9 4.24A9.12 9.12 0 0 1 12 4c7 0 11 8 11 8a18.5 18.5 0 0 1-2.16 3.19m-6.72-1.07a3 3 0 1 1-4.24-4.24"></path>
                  <line x1="1" y1="1" x2="23" y2="23"></line>
                </svg>
              ) : (
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="20"
                  height="20"
                  viewBox="0 0 24 24"
                  fill="none"
                  stroke="currentColor"
                  strokeWidth="2"
                  strokeLinecap="round"
                  strokeLinejoin="round"
                >
                  <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path>
                  <circle cx="12" cy="12" r="3"></circle>
                </svg>
              )}
            </span>
          </div>

          <button type="submit" className="tech-login-submit-btn">
            Sign In
          </button>
        </form>

        <p className="tech-login-signup-text">
          Don't have an account?{" "}
          <Link to="/signup" className="tech-login-signup-link">
            Sign up
          </Link>
        </p>
      </div>
    </div>
  );
};

export default Login;
