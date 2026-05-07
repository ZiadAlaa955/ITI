import { useContext, useState } from "react";
import "./inputSidebar.css";
import { NewsContextConfig } from "../../context/News-Context";

const InputSidebar = () => {
  const [newsData, setNewsData] = useState({
    headline: "",
    category: "",
    image: "",
    description: "",
    article: "",
    author: "",
  });

  const { addPost } = useContext(NewsContextConfig);

  const handleChange = (e) => {
    setNewsData({ ...newsData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const currentDate = new Date().toLocaleDateString("en-US", {
      year: "numeric",
      month: "short",
      day: "numeric",
    });

    addPost({
      ...newsData,
      date: currentDate,
    });

    setNewsData({
      headline: "",
      category: "",
      image: "",
      description: "",
      article: "",
      author: "",
    });
  };

  return (
    <aside className="sidebar">
      <h2>Submit News</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>Headline</label>
          <input
            type="text"
            placeholder="Enter article headline"
            name="headline"
            required
            value={newsData.headline}
            onChange={handleChange}
          />
        </div>

        <div className="form-group">
          <label>Publisher Name</label>
          <input
            type="text"
            placeholder="e.g., Julian Vossen"
            name="author"
            required
            value={newsData.author}
            onChange={handleChange}
          />
        </div>

        <div className="form-group">
          <label>Category</label>
          <input
            type="text"
            placeholder="e.g., AI, Hardware..."
            name="category"
            required
            value={newsData.category}
            onChange={handleChange}
          />
        </div>

        <div className="form-group">
          <label>Image URL</label>
          <input
            type="text"
            placeholder="Enter Your Image Url"
            name="image"
            required
            value={newsData.image}
            onChange={handleChange}
          />
        </div>

        <div className="form-group">
          <label>Short Description (Card Intro)</label>
          <textarea
            placeholder="Brief description for the news card..."
            rows="3"
            name="description"
            required
            value={newsData.description}
            onChange={handleChange}
          ></textarea>
        </div>

        <div className="form-group">
          <label>Full Article Content</label>
          <textarea
            placeholder="Write the full article details here..."
            rows="8"
            name="article"
            required
            value={newsData.article}
            onChange={handleChange}
          ></textarea>
        </div>

        <button type="submit" className="submit-btn">
          Publish News
        </button>
      </form>
    </aside>
  );
};

export default InputSidebar;
