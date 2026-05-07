import { useTranslation } from "react-i18next";
import ListCard from "../../components/listCard/listCard";
import Searchbar from "../../components/searchBar/searchbar";
import "../latestNews/latestNews.css";
import { useDispatch, useSelector } from "react-redux";
import { setSearchText } from "../../redux/slices/postsSlice";

const LatestNews = () => {
  const postsState = useSelector((state) => state.postsR);
  const news = postsState?.news || [];
  const searchText = postsState?.searchText || "";

  const dispatch = useDispatch();

  const { t } = useTranslation();

  const filterNews = news.filter((newsItem) =>
    newsItem?.category?.toLowerCase().includes(searchText.toLowerCase()),
  );

  return (
    <div className="latest-news-container">
      <div className="page-header">
        <h1 className="list-headline">{t("nav.latest")}</h1>
        <div className="search-wrapper">
          <Searchbar
            setSearchText={(text) => dispatch(setSearchText(text))}
          ></Searchbar>
        </div>
      </div>
      <ListCard filterNews={filterNews}></ListCard>
    </div>
  );
};

export default LatestNews;
