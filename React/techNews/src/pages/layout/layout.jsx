import Header from "../../components/header/header";
import Footer from "../../components/footer/footer";
import { Outlet } from "react-router";
import "../layout/layout.css";

const Layout = () => {

  return (
    <div className="layout-wrapper">
      <Header></Header>
      <Outlet></Outlet>
      <Footer></Footer>
    </div>
  );
};

export default Layout;
