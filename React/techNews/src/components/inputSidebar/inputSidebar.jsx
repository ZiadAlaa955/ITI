import { useState } from "react";
import "./inputSidebar.css";
import { useTranslation } from "react-i18next";
import { useDispatch } from "react-redux";
import { addNewPost } from "../../redux/slices/postsSlice";
import { useNavigate } from "react-router";
import { toast } from "react-toastify";

const InputSidebar = () => {
  const { t, i18n } = useTranslation();
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const [newsData, setNewsData] = useState({
    headline: "",
    category: "",
    image: "",
    description: "",
    article: "",
    author: "",
  });

  const handleChange = (e) => {
    setNewsData({ ...newsData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const currentDate = new Date().toLocaleDateString("en-US", {
      year: "numeric",
      month: "short",
      day: "numeric",
    });

    const newPostData = {
      ...newsData,
      date: currentDate,
    };

    try {
      await dispatch(addNewPost(newPostData)).unwrap();

      setNewsData({
        headline: "",
        category: "",
        image: "",
        description: "",
        article: "",
        author: "",
      });

      toast.success(
        i18n.language === "ar"
          ? "تم النشر بنجاح!"
          : "Post published successfully!",
      );

      navigate("/news/latest");
    } catch (error) {
      console.error("Failed to add post", error);
      toast.error(
        i18n.language === "ar" ? "فشل النشر" : "Failed to publish post.",
      );
    }
  };

  return (
    <aside className="sidebar">
      <h2>{t("addPost.title")}</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>{t("addPost.headlineLabel")}</label>
          <input
            type="text"
            placeholder={t("addPost.headlinePlaceholder")}
            name="headline"
            required
            value={newsData.headline}
            onChange={handleChange}
          />
        </div>

        <div className="form-group">
          <label>{t("addPost.publisherLabel")}</label>
          <input
            type="text"
            placeholder={t("addPost.publisherPlaceholder")}
            name="author"
            required
            value={newsData.author}
            onChange={handleChange}
          />
        </div>

        <div className="form-group">
          <label>{t("addPost.categoryLabel")}</label>
          <input
            type="text"
            placeholder={t("addPost.categoryPlaceholder")}
            name="category"
            required
            value={newsData.category}
            onChange={handleChange}
          />
        </div>

        <div className="form-group">
          <label>{t("addPost.imageLabel")}</label>
          <input
            type="text"
            placeholder={t("addPost.imagePlaceholder")}
            name="image"
            required
            value={newsData.image}
            onChange={handleChange}
          />
        </div>

        <div className="form-group">
          <label>{t("addPost.descLabel")}</label>
          <textarea
            placeholder={t("addPost.descPlaceholder")}
            rows="3"
            name="description"
            required
            value={newsData.description}
            onChange={handleChange}
          ></textarea>
        </div>

        <div className="form-group">
          <label>{t("addPost.contentLabel")}</label>
          <textarea
            placeholder={t("addPost.contentPlaceholder")}
            rows="8"
            name="article"
            required
            value={newsData.article}
            onChange={handleChange}
          ></textarea>
        </div>

        <button type="submit" className="submit-btn">
          {t("addPost.submitBtn")}
        </button>
      </form>
    </aside>
  );
};

export default InputSidebar;
