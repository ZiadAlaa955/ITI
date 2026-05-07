import { useState } from "react";
import "./newsCard.css";
import { FaThumbsUp, FaThumbsDown } from "react-icons/fa";

const NewsCard = (props) => {
  const [like, setLike] = useState(0);
  const [dislike, setDislike] = useState(0);

  const clickLike = () => {
    setLike(like == 0 ? 1 : 0);
    setDislike(0);
  };

  const clickDislike = () => {
    setDislike(dislike === 0 ? 1 : 0);
    setLike(0);
  };

  return (
    <div className="card">
      <div className="card-content">
        <img src={props.image} alt="" className="cardImage" />
        <span className="category-badge">{props.category}</span>
        <div className="content">
          <h3>{props.headline}</h3>
          <p>{props.description}</p>
          <hr />
          <div className="icon-container">
            <div
              className={`like ${like === 1 ? "active-like" : ""}`}
              onClick={clickLike}
            >
              <FaThumbsUp className="likeIcon" />
              <span>{like}</span>
            </div>
            <div
              className={`dislike ${dislike === 1 ? "active-dislike" : ""}`}
              onClick={clickDislike}
            >
              <FaThumbsDown className="dislikeIcon" />
              <span>{dislike}</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default NewsCard;
