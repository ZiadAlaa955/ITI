import "./App.css";
import NewsTechFooter from "../components/footer/footer";
import NewsTechHeader from "../components/header/header";
import Slider from "../components/slider/slider";
import Body from "../components/body/body";
import { useState } from "react";

function App() {
  const [searchText, setSearchText] = useState("");

  return (
    <div className="app-container">
      <NewsTechHeader setSearchText={setSearchText}></NewsTechHeader>

      <Slider></Slider>
      <div className="main-layout">
        <Body searchText={searchText}></Body>
      </div>

      <NewsTechFooter></NewsTechFooter>
    </div>
  );
}

export default App;
