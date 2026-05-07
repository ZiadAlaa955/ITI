import { useState } from "react";
import "./inputSidebar.css";

const InputSidebar = (props) => {
  const [newsData, setNewsData] = useState({
    headline: "",
    category: "",
    image: "",
    description: "",
  });

  const handleChange = (e) => {
    setNewsData({ ...newsData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    props.addPost(newsData);
    setNewsData({
      headline: "",
      category: "",
      description: "",
      image: "",
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
            value={newsData.headline}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label>Category</label>
          <input
            type="text"
            placeholder="e.g., AI, Hardware..."
            name="category"
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
            value={newsData.image}
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label>Description</label>
          <textarea
            placeholder="Brief description..."
            rows="5"
            cols="15"
            name="description"
            value={newsData.description}
            onChange={handleChange}
          ></textarea>
        </div>
        <button type="submit">publish News</button>
      </form>
    </aside>
  );
};

export default InputSidebar;
