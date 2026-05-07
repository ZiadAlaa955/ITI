import "./header.css";

function NewsTechHeader() {
  return (
    <header className="header">
      <h1>Tech News</h1>
      <nav>
        <ul>
          <li>
            <a href="#home">Home</a>
          </li>
          <li>
            <a href="#latest">Latest</a>
          </li>
          <li>
            <a href="#trending">Trending</a>
          </li>
        </ul>
      </nav>
    </header>
  );
}
export default NewsTechHeader;
