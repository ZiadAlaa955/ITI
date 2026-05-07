import { Component } from "react";
import "./slider.css";
import img1 from "../../../public/AI.jfif";
import img2 from "../../../public/Artificial-intelligence.jfif";
import img3 from "../../../public/Blue-technology.jfif";
import rightArrow from "../../assets/icons/right-arrow.png";
import leftArrow from "../../assets/icons/left-arrow.png";

class Slider extends Component {
  constructor(props) {
    super(props);

    this.images = [img1, img2, img3];

    this.state = {
      currentIndex: 0,
    };
  }

  nextSlide = () => {
    this.setState((prevState) => ({ 
      currentIndex:
        prevState.currentIndex === this.images.length - 1
          ? 0
          : prevState.currentIndex + 1,
    }));
  };

  prevSlide = () => {
    this.setState((prevState) => ({
      currentIndex:
        prevState.currentIndex === 0
          ? this.images.length - 1
          : prevState.currentIndex - 1,
    }));
  };

  goToSlide = (index) => {
    this.setState({ currentIndex: index });
  };

  render() {
    return (
      <div className="slider">
        <div id="left-arrow" onClick={this.prevSlide}>
          <img src={leftArrow} alt="Previous" />
        </div>

        <img
          id="img-slider"
          src={this.images[this.state.currentIndex]}
          alt="Tech News Slider"
        />

        <div id="right-arrow" onClick={this.nextSlide}>
          <img src={rightArrow} alt="Next" />
        </div>

        <div id="imgs">
          {this.images.map((_, index) => (
            <span
              key={index}
              className={`dot ${this.state.currentIndex === index ? "active" : ""}`}
              onClick={() => this.goToSlide(index)}
            ></span>
          ))}
        </div>
      </div>
    );
  }
}

export default Slider;
