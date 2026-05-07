import { Component } from "react";
// import img from "../../assets/AI Weekly News_ Mind-Reading, Cheaper Robots & More! (March 15, 2025).jfif";
import "./newsCard.css";

class NewsCard extends Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <div className="card">
        <div className="card-content">
          <img src={this.props.image} alt="" />
          <span className="category-badge">{this.props.category}</span>
          <div className="content">
            <h3>{this.props.title}</h3>
            <p>{this.props.description}</p>
            <hr />
          </div>
        </div>
      </div>
    );
  }
}
export default NewsCard;
