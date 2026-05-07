import "./App.css";
import { createBrowserRouter, Navigate, RouterProvider } from "react-router";
import Home from "../pages/home/home";
import LatestNews from "../pages/latestNews/latestNews";
import AddPost from "../pages/addPost/addPost";
import Login from "../pages/login/login";
import Signup from "../pages/signup/signup";
import NotFound from "../pages/notFound/notFound";
import Layout from "../pages/layout/layout";
import NewsProvider from "../context/News-Context";
import PostDetails from "../pages/postDetails/postDetails";
import ProtectedRoute from "../components/ProtectedRoute";
import { ToastContainer } from "react-toastify";

function App() {
  const routerConfig = createBrowserRouter([
    {
      element: <Layout></Layout>,
      children: [
        {
          index: true,
          element: <Navigate to="home" replace></Navigate>,
        },
        {
          path: "home",
          element: (
            <ProtectedRoute>
              <Home></Home>
            </ProtectedRoute>
          ),
        },
        {
          path: "news/latest",
          element: (
            <ProtectedRoute>
              <LatestNews></LatestNews>
            </ProtectedRoute>
          ),
        },
        {
          path: "news/:id",
          element: (
            <ProtectedRoute>
              <PostDetails></PostDetails>
            </ProtectedRoute>
          ),
        },
        {
          path: "news/add",
          element: (
            <ProtectedRoute>
              <AddPost></AddPost>
            </ProtectedRoute>
          ),
        },
        {
          path: "login",
          element: <Login></Login>,
        },
        {
          path: "signup",
          element: <Signup></Signup>,
        },
      ],
    },
    {
      path: "*",
      element: <NotFound></NotFound>,
    },
  ]);

  return (
    <>
      <NewsProvider>
        <RouterProvider router={routerConfig}></RouterProvider>
      </NewsProvider>

      <ToastContainer
        position="bottom-right"
        autoClose={3000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="dark"
      ></ToastContainer>
    </>
  );
}

export default App;
