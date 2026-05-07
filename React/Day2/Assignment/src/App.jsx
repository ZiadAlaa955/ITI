import "./App.css";
import NewsTechFooter from "./components/footer/footer";
import NewsTechHeader from "./components/header/header";
import InputSidebar from "./components/inputSidebar/inputSidebar";
import ListCard from "./components/listCard/listCard";
import Slider from "./components/slider/slider";

function App() {
  return (
    <div className="app-container">
      <NewsTechHeader></NewsTechHeader>

      <Slider></Slider>
      <div className="main-layout">
        <InputSidebar></InputSidebar>
        <main className="content">
          <ListCard></ListCard>
        </main>
      </div>

      <NewsTechFooter></NewsTechFooter>
    </div>
  );
}

export default App;
