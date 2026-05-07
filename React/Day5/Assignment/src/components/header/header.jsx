import { Link } from "react-router";
import "./header.css";

const NewsTechHeader = () => {
  return (
    <header className="header">
      <h1>Tech News</h1>
      <nav>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/news/latest">latest</Link>
          </li>
          <li>
            <Link to="/news/add">Add</Link>
          </li>
          <li>
            <Link to="/login">Login</Link>
          </li>
          <li>
            <Link to="/signup">Signup</Link>
          </li>
        </ul>
      </nav>
    </header>
  );
};

export default NewsTechHeader;
