import React, { Fragment, useEffect } from 'react';
import { Container} from 'semantic-ui-react';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import LoadingComponent from './loadingComponent';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';
import { Route } from 'react-router-dom';
import HomePage from '../../features/home/HomePage';
import ActivityForm from '../../features/activities/form/ActivityForm';

function App() {
  const {activityStore} = useStore();

  useEffect(() => {
    activityStore.loadActivities();
  }, [activityStore])

  if (activityStore.loadInitial) return <LoadingComponent content='Loading app'/>

  return (
    <Fragment>
      <NavBar />
      <Container style={{marginTop: '7em'}}>
        <Route path='/' component={HomePage}/>
        <Route path='/activities' component={ActivityDashboard}/>
        <Route path='/createActivity' component={ActivityForm}/>
      </Container>
    </Fragment>
  );
}

export default observer(App);
