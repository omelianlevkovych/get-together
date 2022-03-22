import React, { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import { Container, Header, List } from 'semantic-ui-react';
import { Activity } from '../models/activity';
import { Activities } from '../models/activities';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activities>('http://localhost:5245/api/activities').then(response => {
      setActivities(response.data.activities);
    })
  }, [])

  return (
    <Fragment>
      <NavBar/>

      <Container style={{marginTop: '7em'}}>
      <ActivityDashboard activities={activities}/>
      </Container>
    </Fragment>
  );
}

export default App;
