import { Component } from "react";
import "./inputSidebar.css";

class InputSidebar extends Component {
  state = {
    headline: "",
    category: "",
    image: "",
    description: "",
  };

  handleChange = (e) => {
    this.setState({ ...this.state, [e.target.name]: e.target.value });
  };

  handleSubmit = (e) => {
    e.preventDefault();
    this.props.addPost(this.state);
    this.setState({
      headline: "",
      category: "",
      description: "",
      image: "",
    });
  };

  render() {
    return (
      <aside className="sidebar">
        <h2>Submit News</h2>
        <form onSubmit={this.handleSubmit}>
          <div className="form-group">
            <label>Headline</label>
            <input
              type="text"
              placeholder="Enter article headline"
              name="headline"
              value={this.state.headline}
              onChange={this.handleChange}
            />
          </div>
          <div className="form-group">
            <label>Category</label>
            <input
              type="text"
              placeholder="e.g., AI, Hardware..."
              name="category"
              value={this.state.category}
              onChange={this.handleChange}
            />
          </div>
          <div className="form-group">
            <label>Image URL</label>
            <input
              type="text"
              placeholder="Enter Your Image Url"
              name="image"
              value={this.state.image}
              onChange={this.handleChange}
            />
          </div>
          <div className="form-group">
            <label>Description</label>
            <textarea
              placeholder="Brief description..."
              rows="5"
              cols="15"
              name="description"
              value={this.state.description}
              onChange={this.handleChange}
            ></textarea>
          </div>
          <button type="submit">publish News</button>
        </form>
      </aside>
    );
  }
}
export default InputSidebar;
