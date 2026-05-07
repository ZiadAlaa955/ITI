import { useState } from "react";
import { Link, useNavigate } from "react-router";
import axios from "axios";
import "./signup.css";
import { toast } from "react-toastify";

const Signup = () => {
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    fullName: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  const [error, setError] = useState("");

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
    setError("");
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (formData.password !== formData.confirmPassword) {
      toast.warn("Passwords do not match!");
      return;
    }

    const newUser = {
      fullName: formData.fullName,
      email: formData.email,
      password: formData.password,
    };

    axios
      .post("http://localhost:3000/users", newUser)
      .then((res) => {
        localStorage.setItem("currentUser", JSON.stringify(res.data));
        toast.success("Account created successfully!");
        navigate("/");
      })
      .catch((err) => {
        console.error("Error creating account:", err);
        setError("Failed to create account. Please try again.");
      });
  };

  return (
    <div className="tech-signup-wrapper">
      <div className="tech-signup-card">
        <div className="tech-signup-top-accent"></div>

        <div className="tech-signup-inner-content">
          <h1 className="tech-signup-title">Signup</h1>
          <p className="tech-signup-subtitle">
            Create your account to access premium
            <br />
            intelligence.
          </p>

          {error && <div className="tech-signup-error-alert">{error}</div>}

          <form className="tech-signup-form" onSubmit={handleSubmit}>
            <div className="tech-signup-input-group">
              <input
                type="text"
                name="fullName"
                className="tech-signup-input-field"
                placeholder="Full Name"
                required
                value={formData.fullName}
                onChange={handleChange}
              />
            </div>

            <div className="tech-signup-input-group">
              <input
                type="email"
                name="email"
                className="tech-signup-input-field"
                placeholder="Email Address"
                required
                value={formData.email}
                onChange={handleChange}
              />
            </div>

            <div className="tech-signup-input-group">
              <input
                type="password"
                name="password"
                className="tech-signup-input-field"
                placeholder="Password"
                required
                value={formData.password}
                onChange={handleChange}
              />
            </div>

            <div className="tech-signup-input-group">
              <input
                type="password"
                name="confirmPassword"
                className={`tech-signup-input-field ${error ? "tech-signup-input-error" : ""}`}
                placeholder="Confirm Password"
                required
                value={formData.confirmPassword}
                onChange={handleChange}
              />
            </div>

            <button
              type="submit"
              className="tech-signup-submit-btn tech-signup-gradient-btn"
            >
              Create Account
            </button>
          </form>

          <p className="tech-signup-login-prompt">
            Already have an account?{" "}
            <Link to="/login" className="tech-signup-login-link">
              Log in
            </Link>
          </p>
        </div>
      </div>
    </div>
  );
};

export default Signup;
