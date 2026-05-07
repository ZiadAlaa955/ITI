import { Component } from "react";
import "./inputSidebar.css";

class InputSidebar extends Component {
  render() {
    return (
      <aside className="sidebar">
        <h2>Submit News</h2>
        <form>
          <div className="form-group">
            <label>Headline</label>
            <input type="text" placeholder="Enter article headline" />
          </div>
          <div className="form-group">
            <label>Category</label>
            <input type="text" placeholder="e.g., AI, Hardware..." />
          </div>
          <div className="form-group">
            <label>Description</label>
            <textarea
              rows="4"
              placeholder="Brief description..."
              rows="5"
              cols="15"
            ></textarea>
          </div>
          <button type="button">publish News</button>
        </form>
      </aside>
    );
  }
}
export default InputSidebar;
