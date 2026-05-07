import Slider from "../../components/slider/slider";
import { useEffect, useState } from "react";
import "./home.css";

const Home = () => {
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
          Welcome, <span className="username">{userName || "Explorer"}!</span>
        </h1>
        <p>Catch up on the latest breakthroughs in technology.</p>
      </div>

      <div className="slider-section">
        <Slider />
      </div>
    </div>
  );
};

export default Home;
