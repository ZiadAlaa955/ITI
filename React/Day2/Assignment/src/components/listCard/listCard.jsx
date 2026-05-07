import { Component } from "react";
import NewsCard from "../newsCard/newsCard";
// import { v4 as uuidv4 } from "uuid";
import "./listCard.css";
// import img1 from "../../assets/Artificial-intelligence.jfif";
// import img2 from "../../assets/AI.jfif";
// import img3 from "../../assets/Blue-technology.jfif";
import axios from "axios";

class ListCard extends Component {
  state = {
    news: [],
    // news: [
    //   {
    //     id: uuidv4(),
    //     image: img1,
    //     category: "Artificial Intelligence",
    //     title: "New AI Model Released",
    //     description:
    //       "A groundbreaking new language model has been released, promising to revolutionize natural language processing.",
    //   },
    //   {
    //     id: uuidv4(),
    //     image: img2,
    //     category: "Hardware",
    //     title: "Next-Gen GPU Unveiled",
    //     description:
    //       "The latest graphics processing unit has been unveiled, promising unprecedented performance.",
    //   },
    //   {
    //     id: uuidv4(),
    //     image: img3,
    //     category: "Software",
    //     title: "New OS Version Announced",
    //     description:
    //       "The latest version of the popular operating system has been announced, featuring enhanced security and performance.",
    //   },
    // ],
  };

  componentDidMount() {
    axios
      .get("http://localhost:3000/posts")
      .then((res) => this.setState({ news: res.data }, console.log(res.data)));
  }

  render() {
    return (
      <div className="list-card">
        <h3 className="list-headline">Latest News</h3>
        <div className="cards-grid">
          {this.state.news.map((items) => (
            <NewsCard {...items} key={items.id}></NewsCard>
          ))}
        </div>
      </div>
    );
  }
}
export default ListCard;
