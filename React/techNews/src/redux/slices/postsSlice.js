import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const fetchPosts = createAsyncThunk("posts/fetchPosts", async () => {
  const res = await axios.get("http://localhost:3000/posts");
  return res.data;
});

export const addNewPost = createAsyncThunk(
  "posts/addNewPost",
  async (postData, { dispatch }) => {
    const res = await axios.post("http://localhost:3000/posts", postData);

    dispatch(fetchPosts());

    return res.data;
  },
);

const postsSlice = createSlice({
  name: "posts",
  initialState: {
    news: [],
    searchText: "",
    loading: false,
    error: null,
  },
  reducers: {
    setSearchText: (state, action) => {
      state.searchText = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchPosts.pending, (state) => {
      state.loading = true;
    });
    builder.addCase(fetchPosts.fulfilled, (state, action) => {
      state.news = action.payload;
      state.loading = false;
    });
    builder.addCase(fetchPosts.rejected, (state, action) => {
      state.error = action.error.message;
      state.loading = false;
    });
  },
});

export const { setSearchText } = postsSlice.actions;

export default postsSlice.reducer;
