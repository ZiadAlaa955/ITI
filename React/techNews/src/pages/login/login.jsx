import { useState } from "react";
import { Link, useNavigate } from "react-router";
import axios from "axios";
import "./login.css";
import { toast } from "react-toastify";
import { useTranslation } from "react-i18next";

const Login = () => {
  const navigate = useNavigate();
  const { t } = useTranslation();
  const [showPassword, setShowPassword] = useState(false);

  const [formData, setFormData] = useState({ email: "", password: "" });
  const [error, setError] = useState("");

  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword);
  };

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
    setError("");
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    axios
      .get("http://localhost:3000/users")
      .then((res) => {
        const users = res.data;
        const validUser = users.find(
          (user) =>
            user.email === formData.email &&
            user.password === formData.password,
        );

        if (validUser) {
          localStorage.setItem("currentUser", JSON.stringify(validUser));
          toast.success(`${t("loginAuth.success")}, ${validUser.fullName}!`);
          navigate("/");
        } else {
          toast.error(t("loginAuth.invalid"));
        }
      })
      .catch((err) => {
        console.error("Login error:", err);
        setError(t("loginAuth.error"));
      });
  };

  return (
    <div className="tech-login-wrapper">
      <div className="tech-login-card">
        <h1 className="tech-login-title">{t("loginAuth.title")}</h1>
        <p className="tech-login-subtitle">{t("loginAuth.subtitle")}</p>

        {error && <div className="tech-login-error-alert">{error}</div>}

        <form className="tech-login-form" onSubmit={handleSubmit}>
          <div className="tech-login-input-group">
            <input
              type="email"
              name="email"
              className="tech-login-input-field"
              placeholder={t("loginAuth.emailPlaceholder")}
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
              placeholder={t("loginAuth.passwordPlaceholder")}
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
            {t("loginAuth.btn")}
          </button>
        </form>

        <p className="tech-login-signup-text">
          {t("loginAuth.prompt")}{" "}
          <Link to="/signup" className="tech-login-signup-link">
            {t("loginAuth.link")}
          </Link>
        </p>
      </div>
    </div>
  );
};

export default Login;
