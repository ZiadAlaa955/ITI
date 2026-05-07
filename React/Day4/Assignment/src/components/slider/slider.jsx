import { useEffect, useState } from "react";
import "./slider.css";
import img1 from "../../assets/slider-imgs/img1.jpg";
import img2 from "../../assets/slider-imgs/img2.jpg";
import img3 from "../../assets/slider-imgs/img4.jpg";
import rightArrow from "../../assets/icons/right-arrow.png";
import leftArrow from "../../assets/icons/left-arrow.png";

const Slider = () => {
  const images = [img1, img2, img3];

  const [currentIndex, setCurrentIndex] = useState(0);

  const nextSlide = () => {
    setCurrentIndex((prevIndex) =>
      prevIndex === images.length - 1 ? 0 : prevIndex + 1,
    );
  };

  const prevSlide = () => {
    setCurrentIndex((prevIndex) =>
      prevIndex === 0 ? images.length - 1 : prevIndex - 1,
    );
  };

  const goToSlide = (index) => {
    setCurrentIndex(index);
  };

  useEffect(() => {
    const interval = setInterval(() => {
      nextSlide();
    }, 3000);

    return () => clearInterval(interval);
  }, []);

  return (
    <div className="slider">
      <div id="left-arrow" onClick={prevSlide}>
        <img src={leftArrow} alt="Previous" />
      </div>

      <img id="img-slider" src={images[currentIndex]} alt="Tech News Slider" />

      <div id="right-arrow" onClick={nextSlide}>
        <img src={rightArrow} alt="Next" />
      </div>

      <div id="imgs">
        {images.map((_, index) => (
          <span
            key={index}
            className={`dot ${currentIndex === index ? "active" : ""}`}
            onClick={() => goToSlide(index)}
          ></span>
        ))}
      </div>
    </div>
  );
};

export default Slider;
