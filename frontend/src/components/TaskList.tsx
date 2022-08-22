
import { Link } from 'react-router-dom';
import { TaskCategories } from '../types/Task';

interface TaskListProps {
  tasks: TaskCategories;
}

const TaskList = ({ tasks }: TaskListProps) => {
  return (
    <div className="task-list mt-8">

      <h3>Pending tasks</h3>
      <div className="p-4 mb-6">
        {tasks.pending.map(task => (
          <div className="Task-preview" key={task.id} >
            <p>{task.description}</p>
          </div>
        ))}
      </div>

      <h3>Completed tasks</h3>
      <div className="p-4">
        {tasks.completed.map(task => (
          <div className="Task-preview" key={task.id} >
            <p>{task.description}</p>
          </div>
        ))}
      </div>
    </div>
  );
}

export default TaskList;