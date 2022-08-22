import TaskList from "./TaskList";
import useFetch from "../hooks/useFetch";
import { Task } from "../types/Task";

const Home = () => {
  const { data, error } = useFetch<Task[]>('https://localhost:8000/tasks')

  return (
    <div className="home">
      {error && <div>{error.message}</div>}
      {!data && <div>Loading...</div>}
      {data && <TaskList tasks={data} />}
    </div>
  );
}

export default Home;