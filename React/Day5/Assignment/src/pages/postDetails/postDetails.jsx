import { useContext } from "react";
import { useParams } from "react-router";
import { NewsContextConfig } from "../../context/News-Context";
import "./postDetails.css";

const PostDetails = () => {
  const { id } = useParams();
  const { news } = useContext(NewsContextConfig);
  const post = news.find((item) => item.id == id);

  if (!post) {
    return <div className="loading-screen">Loading article...</div>;
  }

  return (
    <div className="premium-article-page">
      <section className="article-hero">
        <div className="glass-pill">{post.category}</div>
        <h1 className="hero-headline">{post.headline}</h1>

        <div className="author-info">
          <img
            src="https://lh3.googleusercontent.com/aida-public/AB6AXuC2e91SJazS3H-e-R8IxyDn2okW70uJoNf3FqtrnCvYUuZ5LeMYzpyHVoFJDJnPK370-44zjfsipKIMevBDwsqlIVM3P0dn1df-KsKl-JgE4iyhi3Pf_exnyjIgF6L6K_q7XBz8rsGE63nKnfl7ROMNnfBXy9hyIWCjWESaFjaesbHLeigsu0sNWPVjUWzGN2W1fgunA60sfcbzvVXlkTFVV9V1nuQq3rKIpiJkTg-lIhrguuBiIsVgnVwvkDqSe_3KzSVts6iz13-c"
            alt="Author"
            className="author-avatar"
          />
          <div className="author-details">
            <div className="author-name">By {post.author}</div>{" "}
            <div className="author-date">{post.date}</div>{" "}
          </div>
        </div>
      </section>

      <section className="featured-media">
        <div className="media-wrapper">
          <img src={post.image} alt={post.headline} className="hero-image" />
          <div className="gradient-overlay"></div>
        </div>
      </section>

      {/* --- READING AREA --- */}
      <article className="article-body">
        <p className="article-intro">{post.description}</p>

        <p style={{ whiteSpace: "pre-wrap" }}>{post.article}</p>
      </article>
    </div>
  );
};

export default PostDetails;
