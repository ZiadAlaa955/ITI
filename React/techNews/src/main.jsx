import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App/App";
import "./i18n";
import { Provider } from "react-redux";
import { storeConfig } from "./redux/store/store";

createRoot(document.getElementById("root")).render(
  <StrictMode>
    <Provider store={storeConfig}>
      <App />
    </Provider>
  </StrictMode>,
);
