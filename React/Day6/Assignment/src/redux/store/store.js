import { configureStore } from "@reduxjs/toolkit";
import LanguageReducer from "../slices/languageSlice";
import PostsReducer from "../slices/postsSlice";
import ThemeReducer from "../slices/themeSlice";

export let storeConfig = configureStore({
  reducer: {
    languageR: LanguageReducer,
    postsR: PostsReducer,
    themeR: ThemeReducer,
  },
});
