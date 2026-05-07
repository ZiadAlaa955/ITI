import "./listCard.css";
import NewsCard from "../newsCard/newsCard";

const ListCard = (props) => {
  return (
    <div className="list-card">
      <h3 className="list-headline">Latest News</h3>
      <div className="cards-grid">
        {props.filterNews.map((items) => (
          <NewsCard {...items} key={items.id}></NewsCard>
        ))}
      </div>
    </div>
  );
};

export default ListCard;
