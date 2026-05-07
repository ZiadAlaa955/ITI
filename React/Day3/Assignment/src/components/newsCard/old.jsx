import { Component } from "react";
import "./newsCard.css";
import { FaThumbsUp, FaThumbsDown } from "react-icons/fa";

class NewsCard extends Component {
  constructor() {
    super();
  }
  state = {
    like: 0,
    dislike: 0,
  };

  clickLike = () => {
    this.setState({
      dislike: 0,
      like: this.state.like == 0 ? 1 : 0,
    });
  };

  clickDislike = () => {
    this.setState({
      like: 0,
      dislike: this.state.dislike === 0 ? 1 : 0,
    });
  };

  render() {
    return (
      <div className="card">
        <div className="card-content">
          <img src={this.props.image} alt="" className="cardImage" />
          <span className="category-badge">{this.props.category}</span>
          <div className="content">
            <h3>{this.props.headline}</h3>
            <p>{this.props.description}</p>
            <hr />
            <div className="icon-container">
              <div
                className={`like ${this.state.like === 1 ? "active-like" : ""}`}
                onClick={this.clickLike}
              >
                <FaThumbsUp className="likeIcon" />
                <span>{this.state.like}</span>
              </div>
              <div
                className={`dislike ${this.state.dislike === 1 ? "active-dislike" : ""}`}
                onClick={this.clickDislike}
              >
                <FaThumbsDown className="dislikeIcon" />
                <span>{this.state.dislike}</span>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
export default NewsCard;
