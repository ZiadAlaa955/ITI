import { Component } from "react";
import InputSidebar from "../inputSidebar/inputSidebar";
import ListCard from "../listCard/listCard";
import axios from "axios";

class Body extends Component {
  state = {
    news: [],
  };

  fetchData = () => {
    axios
      .get("http://localhost:3000/posts")
      .then((res) => this.setState({ news: res.data }, console.log(res.data)));
  };

  componentDidMount() {
    this.fetchData();
  }

  addPost = (postData) => {
    const newPost = {
      headline: postData.headline,
      category: postData.category,
      description: postData.description,
      image: postData.image,
    };
    axios.post("http://localhost:3000/posts", newPost).then((res) => {
      console.log(res.data);
      this.fetchData();
    });
  };

  render() {
    return (
      <>
        <InputSidebar addPost={this.addPost}></InputSidebar>
        <ListCard newsData={this.state.news}></ListCard>
      </>
    );
  }
}

export default Body;
