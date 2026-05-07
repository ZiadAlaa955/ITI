import { useRef } from "react";
import "./searchbar.css";
import { useTranslation } from "react-i18next";

const Searchbar = (props) => {
  const inputRef = useRef(null);
  const { t } = useTranslation();

  const handleFocus = () => {
    inputRef.current.focus();
  };

  const handleChange = (e) => {
    props.setSearchText(e.target.value);
  };

  return (
    <div className="searchBar">
      <label htmlFor="newsSearch" className="searchIcon" onClick={handleFocus}>
        <svg
          viewBox="0 0 24 24"
          width="18"
          height="18"
          stroke="currentColor"
          strokeWidth="2"
          fill="none"
          strokeLinecap="round"
          strokeLinejoin="round"
        >
          <circle cx="11" cy="11" r="8"></circle>
          <line x1="21" y1="21" x2="16.65" y2="16.65"></line>
        </svg>
      </label>

      <input
        id="newsSearch"
        type="text"
        placeholder={t("search.placeholder")}
        className="searchInput"
        onChange={handleChange}
      />
    </div>
  );
};

export default Searchbar;
