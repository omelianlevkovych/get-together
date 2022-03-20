import React, { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import { Header } from 'semantic-ui-react';

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5245/api/activities').then(response => {
      setActivities(response.data);
    })
  }, [])

  return (
    <div className="App">
      <Header as='h2' icon='users' content='get together'/>
      <header className="App-header">
        <ul>
          {activities.map((activity: any) => (
            <li key={activity.id}>
              {activity.title}
            </li>
          ))}
        </ul>
      </header>
    </div>
  );
}

export default App;
