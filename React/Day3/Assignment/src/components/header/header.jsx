import Searchbar from "../searchBar/searchbar";
import "./header.css";

const NewsTechHeader = (props) => {
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
      <Searchbar setSearchText={props.setSearchText}></Searchbar>
    </header>
  );
};

export default NewsTechHeader;
