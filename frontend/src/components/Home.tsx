import TaskList from "./TaskList";
import { TaskCategories } from "../types/Task";
import { useEffect, useState } from "react";

const Home = () => {
  const [tasks, setTasks] = useState<TaskCategories>();

  const fetchTasks = async () => {
    console.log("getting tasks");
    const response = await fetch('https://localhost:8000/tasks');
    if (!response.ok) throw new Error(response.statusText); 
    console.log("tasks data ok");
    const data = (await response.json()) as TaskCategories;
    setTasks(data);
    console.log("tasks retrieved");
  }

  useEffect(() => {
    fetchTasks();
  }, []);

  return (
    <div className="home">
      {!tasks && <div>Loading...</div>}
      {tasks && <TaskList tasks={tasks} update={() => fetchTasks()} />}
    </div>
  );
}

export default Home;