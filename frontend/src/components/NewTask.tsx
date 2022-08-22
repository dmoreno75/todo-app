
import { useHistory } from 'react-router-dom';
import React, { useState } from 'react';



const NewTask = () => {
  const [description, setDescription] = useState('');
  const history = useHistory();

  const handleSubmit = (e: React.SyntheticEvent) => {
    e.preventDefault();

    const task = { description };

    fetch("https://localhost:8000/tasks/new-task", {
      method: 'POST',
      body: JSON.stringify(task),
      headers: { "Content-Type": "application/json" }
    }).then(() => {
      console.log("added new task");
      history.push('/home');
    })
  }

  return (
    <div className="new-task mt-6">
      <h3>Create New Task</h3>
      <div className="p-4">
        <form onSubmit={handleSubmit} className="flex flex-col">
          <label className="mb-4">Enter description:</label>
          <textarea className="mb-4 h-1/2"
            required value={description}
            onChange={(e) => setDescription(e.target.value)} />
          <button className="max-w-sm">Add task</button>
        </form>
      </div>
    </div>

  );
}

export default NewTask;