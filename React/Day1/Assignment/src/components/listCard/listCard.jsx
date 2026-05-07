import { useState } from "react";
import NewsCard from "../newsCard/newsCard";
import { v4 as uuidv4 } from "uuid";

function ListCard() {
  const [news, setNews] = useState([
    {
      id: uuidv4(),
      category: "Artificial Intelligence",
      title: "New AI Model Released",
      description:
        "A groundbreaking new language model has been released, promising to revolutionize natural language processing.",
    },
    {
      id: uuidv4(),
      category: "Hardware",
      title: "Next-Gen GPU Unveiled",
      description:
        "The latest graphics processing unit has been unveiled, promising unprecedented performance.",
    },
    {
      id: uuidv4(),
      category: "Software",
      title: "New OS Version Announced",
      description:
        "The latest version of the popular operating system has been announced, featuring enhanced security and performance.",
    },
  ]);

  return (
    <div className="list-card">
      <h3>Latest News</h3>
      {news.map((items) => (
        <NewsCard {...items} key={items.id}></NewsCard>
      ))}
    </div>
  );
}
export default ListCard;
