
import { Link } from 'react-router-dom';
import { Task } from '../types/Task';

interface TaskListProps {
  tasks: Task[];
}

const TaskList = ({ tasks }: TaskListProps) => {
  return (
    <div className="task-list">
      {tasks.map(task => (
        <div className="Task-preview" key={task.id} >
          <Link to={`/Tasks/${task.id}`}>
            <p>{task.description}</p>
          </Link>
        </div>
      ))}
    </div>
  );
}

export default TaskList;