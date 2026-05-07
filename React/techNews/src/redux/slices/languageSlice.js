import { createSlice } from "@reduxjs/toolkit";

let languageSlice = createSlice({
  name: "language",
  initialState: { language: "en" },
  reducers: {
    changeLanguageFun: function (state, action) {
      state.language = action.payload;
    },
  },
});

export let { changeLanguageFun } = languageSlice.actions;

export default languageSlice.reducer;
