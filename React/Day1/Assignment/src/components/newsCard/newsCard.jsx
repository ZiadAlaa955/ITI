import img from "../../assets/AI Weekly News_ Mind-Reading, Cheaper Robots & More! (March 15, 2025).jfif";
import "./newsCard.css";

function NewsCard(props) {
  return (
    <div className="card">
      <span className="category-badge">{props.category}</span>
      <br />
      <div className="card-content">
        <img src={img} alt="" width={150} />
        <div className="title-desc">
          <h3>{props.title}</h3>
          <p>{props.description}</p>
        </div>
      </div>
    </div>
  );
}
export default NewsCard;
