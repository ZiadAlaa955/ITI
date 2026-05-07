import { useContext } from "react";
import ListCard from "../../components/listCard/listCard";
import Searchbar from "../../components/searchBar/searchbar";
import { NewsContextConfig } from "../../context/News-Context";
import "../latestNews/latestNews.css";

const LatestNews = () => {
  const { news, searchText } = useContext(NewsContextConfig);
  const { setSearchText } = useContext(NewsContextConfig);

  const filterNews = news.filter((newsItem) =>
    newsItem.category.toLowerCase().includes(searchText.toLowerCase()),
  );
  return (
    <div className="latest-news-container">
      <div className="page-header">
        <h1 className="list-headline">Latest News</h1>
        <div className="search-wrapper">
          <Searchbar setSearchText={setSearchText}></Searchbar>
        </div>
      </div>
      <ListCard filterNews={filterNews}></ListCard>;
    </div>
  );
};

export default LatestNews;
