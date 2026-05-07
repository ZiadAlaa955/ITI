import Slider from "../../components/slider/slider";
import { useEffect, useState } from "react";
import "./home.css";
import { useTranslation } from "react-i18next";

const Home = () => {
  const { t } = useTranslation();
  const [userName, setUserName] = useState("");

  useEffect(() => {
    const storedUser = localStorage.getItem("currentUser");

    if (storedUser) {
      const user = JSON.parse(storedUser);
      setUserName(user.fullName.split(" ")[0]);
    }
  }, []);

  return (
    <div className="home-container">
      <div className="welcome-section">
        <h1>
          {t("home.welcome")},{" "}
          <span className="username">{userName || "Explorer"}!</span>
        </h1>
        <p>{t("home.subtitle")}</p>
      </div>

      <div className="slider-section">
        <Slider />
      </div>
    </div>
  );
};

export default Home;
