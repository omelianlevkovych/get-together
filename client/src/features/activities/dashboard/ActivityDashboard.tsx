import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Grid } from 'semantic-ui-react';
import LoadingComponent from '../../../app/layout/loadingComponent';
import { useStore } from '../../../app/stores/store';
import ActivityList from './ActivityList';

export default observer(function ActivityDashboard() {
    const {activityStore} = useStore();
    const {loadActivities, activityDictionary} =activityStore;

    useEffect(() => {
        // without pagination temporary fix to not load all activities again
        if (activityDictionary.size <= 1) loadActivities();
    }, [activityDictionary.size, loadActivities])
  
    if (activityStore.loadingInitial) return <LoadingComponent content='Loading app'/>

    return (
        <Grid>
            <Grid.Column width='10'>
                <ActivityList/>
            </Grid.Column>
            <Grid.Column width='6'>
                <h2>Activity filters</h2>
            </Grid.Column>
        </Grid>
    )
})