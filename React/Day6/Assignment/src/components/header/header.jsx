import { Link } from "react-router";
import "./header.css";
import { useTranslation } from "react-i18next";
import { useDispatch, useSelector } from "react-redux";
import { changeLanguageFun } from "../../redux/slices/languageSlice";
import { toggleThemeAction } from "../../redux/slices/themeSlice";

const NewsTechHeader = () => {
  const { t, i18n } = useTranslation();
  const dispatch = useDispatch();

  const theme = useSelector((state) => state.themeR.theme);
  const currentLanguage = useSelector((state) => state.languageR.language);

  const toggleLanguage = () => {
    const newLang = currentLanguage === "en" ? "ar" : "en";
    dispatch(changeLanguageFun(newLang));

    i18n.changeLanguage(newLang);
    localStorage.setItem("app-lang", newLang);
    document.documentElement.dir = newLang === "ar" ? "rtl" : "ltr";
    document.documentElement.lang = newLang;
  };

  return (
    <header className="header">
      <h1>{t("nav.logo")}</h1>
      <nav>
        <ul>
          <li>
            <Link to="/">{t("nav.home")}</Link>
          </li>
          <li>
            <Link to="/news/latest">{t("nav.latest")}</Link>
          </li>
          <li>
            <Link to="/news/add">{t("nav.add")}</Link>
          </li>
          <li>
            <Link to="/login">{t("nav.login")}</Link>
          </li>
          <li>
            <Link to="/signup">{t("nav.signup")}</Link>
          </li>
          <li>
            <button onClick={toggleLanguage} className="lang-toggle-btn">
              {currentLanguage === "en" ? "عربي 🌐" : "English 🌐"}
            </button>
          </li>
          <li>
            <button
              onClick={() => {
                dispatch(toggleThemeAction());
              }}
              className="theme-toggle-btn"
            >
              {theme === "dark" ? (
                <>
                  ☀️ <span>Light</span>
                </>
              ) : (
                <>
                  🌙 <span>Dark</span>
                </>
              )}
            </button>
          </li>
        </ul>
      </nav>
    </header>
  );
};

export default NewsTechHeader;
