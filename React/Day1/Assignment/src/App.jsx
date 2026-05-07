import "./App.css";
import NewsTechHeader from "./components/header/header";
import NewsTechFooter from "./components/footer/footer";
import InputSidebar from "./components/inputSidebar/inputSidebar";
import ListCard from "./components/listCard/listCard";

function App() {
  return (
    <div className="app-container">
      <NewsTechHeader></NewsTechHeader>

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
