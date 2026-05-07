import { createSlice } from "@reduxjs/toolkit";

const savedTheme = localStorage.getItem("theme") || "dark";

document.documentElement.setAttribute("data-theme", savedTheme);

const themeSlice = createSlice({
  name: "theme",
  initialState: { theme: savedTheme },
  reducers: {
    toggleThemeAction: (state) => {
      state.theme = state.theme === "dark" ? "light" : "dark";

      localStorage.setItem("theme", state.theme);
      document.documentElement.setAttribute("data-theme", state.theme);
    },
  },
});

export const { toggleThemeAction } = themeSlice.actions;

export default themeSlice.reducer;
