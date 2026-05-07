import { createBrowserRouter, Navigate, RouterProvider } from "react-router";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import Layout from "../pages/layout/layout";
import Home from "../pages/home/home";
import LatestNews from "../pages/latestNews/latestNews";
import AddPost from "../pages/addPost/addPost";
import Login from "../pages/login/login";
import Signup from "../pages/signup/signup";
import NotFound from "../pages/notFound/notFound";
import PostDetails from "../pages/postDetails/postDetails";
import ProtectedRoute from "../components/ProtectedRoute";
import "./App.css";
import { useDispatch } from "react-redux";
import { useEffect } from "react";
import { fetchPosts } from "../redux/slices/postsSlice";

function App() {
  const routerConfig = createBrowserRouter([
    {
      element: <Layout />,
      children: [
        { index: true, element: <Navigate to="home" replace /> },
        {
          path: "home",
          element: (
            <ProtectedRoute>
              <Home />
            </ProtectedRoute>
          ),
        },
        {
          path: "news/latest",
          element: (
            <ProtectedRoute>
              <LatestNews />
            </ProtectedRoute>
          ),
        },
        {
          path: "news/:id",
          element: (
            <ProtectedRoute>
              <PostDetails />
            </ProtectedRoute>
          ),
        },
        {
          path: "news/add",
          element: (
            <ProtectedRoute>
              <AddPost />
            </ProtectedRoute>
          ),
        },
        { path: "login", element: <Login /> },
        { path: "signup", element: <Signup /> },
      ],
    },
    { path: "*", element: <NotFound /> },
  ]);

  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(fetchPosts());
  }, [dispatch]);

  return (
    <>
      <RouterProvider router={routerConfig} />

      <ToastContainer
        position="bottom-right"
        autoClose={3000}
        theme="colored"
      />
    </>
  );
}

export default App;
