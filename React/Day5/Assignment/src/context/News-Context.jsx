import axios from "axios";
import { createContext, useEffect, useState } from "react";
import { toast } from "react-toastify";

export const NewsContextConfig = createContext();

const NewsProvider = ({ children }) => {
  const [news, setNews] = useState([]);
  const [searchText, setSearchText] = useState("");

  const fetchData = () => {
    axios.get("http://localhost:3000/posts").then((res) => setNews(res.data));
  };

  useEffect(() => {
    fetchData();
  }, []);

  const addPost = (postData) => {
    axios
      .post("http://localhost:3000/posts", postData)
      .then(() => {
        toast.success("Article published successfully!");
        fetchData();
      })
      .catch(() => {
        toast.error("Failed to publish article.");
      });
  };

  return (
    <>
      <NewsContextConfig.Provider
        value={{ news, addPost, searchText, setSearchText }}
      >
        {children}
      </NewsContextConfig.Provider>
    </>
  );
};

export default NewsProvider;
