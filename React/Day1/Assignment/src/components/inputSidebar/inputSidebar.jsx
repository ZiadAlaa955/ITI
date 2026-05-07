import "./inputSlidebar.css";
function InputSidebar() {
  return (
    <aside className="sidebar">
      <h2>Add New Article</h2>
      <form>
        <div className="form-group">
          <label>Category</label>
          <input type="text" placeholder="e.g., AI, Hardware..." />
        </div>
        <div className="form-group">
          <label>News Title</label>
          <input type="text" placeholder="Enter article title" />
        </div>
        <div className="form-group">
          <label>Description</label>
          <textarea rows="4" placeholder="Brief description..."></textarea>
        </div>
        <button type="button">Submit News</button>
      </form>
    </aside>
  );
}
export default InputSidebar;
