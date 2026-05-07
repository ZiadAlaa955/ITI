import "./listCard.css";
import NewsCard from "../newsCard/newsCard";

const ListCard = (props) => {
  return (
    <div className="list-card">
      <div className="cards-grid">
        {props.filterNews.map((item) => (
          <NewsCard {...item} key={item.id}></NewsCard>
        ))}
      </div>
    </div>
  );
};

export default ListCard;
