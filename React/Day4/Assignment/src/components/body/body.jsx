import axios from "axios";
import { useEffect, useState } from "react";
import InputSidebar from "../inputSidebar/inputSidebar";
import ListCard from "../listCard/listCard";

const Body = (props) => {
  const [news, setNews] = useState([]);

  const fetchData = () => {
    axios.get("http://localhost:3000/posts").then((res) => setNews(res.data));
  };

  useEffect(() => {
    fetchData();
  }, []);

  const addPost = (postData) => {
    const newPost = {
      headline: postData.headline,
      category: postData.category,
      description: postData.description,
      image: postData.image,
    };
    axios.post("http://localhost:3000/posts", newPost).then((res) => {
      console.log(res.data);
      fetchData();
    });
  };

  const filterNews = news.filter((newsItem) =>
    newsItem.category.toLowerCase().includes(props.searchText.toLowerCase()),
  );

  return (
    <>
      <InputSidebar addPost={addPost}></InputSidebar>
      <ListCard filterNews={filterNews}></ListCard>
    </>
  );
};

export default Body;
