import { makeAutoObservable } from "mobx";
import agent from "../api/agent";
import { Activity } from "../models/activity";

export default class ActivityStore {
    activities: Activity[] = [];
    selectedActivity: Activity | null = null;
    editMode = false;
    loading = false;
    loadInitial = false;

    constructor() {
        makeAutoObservable(this)
    }

    loadActivities = async () => {
        this.setLoadingInitial(true);
        try {
            const activitiesVM = await agent.Activities.list();
            activitiesVM.activities.forEach(activity => {
                activity.date = activity.date.split('T')[0];
                // mutating state here
                this.activities.push(activity);
            })
            this.setLoadingInitial(false);
            
        } catch (error) {
            console.log(error);
            this.setLoadingInitial(false);
        }
    }
    // in order not to use runInAction https://mobx.js.org/actions.html
    setLoadingInitial = (state: boolean) => {
        this.loadInitial = state;
    }
}