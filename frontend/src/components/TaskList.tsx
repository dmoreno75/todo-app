
import { useHistory } from 'react-router-dom';
import { TaskCategories, TaskItem } from '../types/Task';
interface TaskListProps {
  tasks: TaskCategories;
  update: () => void
}

const TaskList = ({ tasks, update }: TaskListProps) => {
  const history = useHistory();

  const handleClick = (e: React.SyntheticEvent, task: TaskItem) => {
    e.preventDefault();

    const taskIdRequest = { taskId: task.id };

    fetch("https://localhost:8000/tasks/toggle-task-status", {
      method: 'PUT',
      body: JSON.stringify(taskIdRequest),
      headers: { "Content-Type": "application/json" }
    }).then(() => {
      console.log("toggle");
      update();
    })
  }

  return (
    <div className="task-list mt-8">

      <h3>Pending tasks</h3>
      <div className="p-4 mb-6">
        {tasks.pending.length == 0 && <p>No pending tasks at the moment</p>}
        {tasks.pending.length > 0 && tasks.pending.map(task => (
          <div className="task-entry flex flex-row center py-1" key={task.id} >
            <a href="#" onClick={(e) => handleClick(e, task)}>Done</a>
            <p>{task.description}</p>
          </div>
        ))}
      </div>

      <h3>Completed tasks</h3>
      <div className="p-4">
        {tasks.completed.length == 0 && <p>No completed tasks yet</p>}
        {tasks.completed.length > 0 && tasks.completed.map(task => (
          <div className="task-entry flex flex-row center py-1" key={task.id} >
            <a href="#" onClick={(e) => handleClick(e, task)}>Undone</a>
            <p>{task.description}</p>
          </div>
        ))}
      </div>
    </div>
  );
}

export default TaskList;