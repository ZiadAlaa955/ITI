import { useContext } from "react";
import Input from "../../components/inputSidebar/inputSidebar";
import "../addPost/addPost.css";
import { NewsContextConfig } from "../../context/News-Context";

const AddPost = () => {
  const { addPost } = useContext(NewsContextConfig);
  return (
    <div className="add-post-container">
      <Input addPost={addPost}></Input>
    </div>
  );
};

export default AddPost;
