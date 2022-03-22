import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';
import { Activity } from '../models/activity';
import { Activities } from '../models/activities';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activities>('http://localhost:5245/api/activities').then(response => {
      setActivities(response.data.activities);
    })
  }, [])

  return (
    <div>
      <Header as='h2' icon='users' content='get together'/>
        <List>
          {activities.map((activity) => (
            <List.Item key={activity.id}>
              {activity.title}
            </List.Item>
          ))}
        </List>
    </div>
  );
}

export default App;
