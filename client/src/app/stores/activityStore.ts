import { action, makeAutoObservable, makeObservable, observable } from "mobx";
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
        this.loadInitial = true;
        try {
            const activitiesVM = await agent.Activities.list();
            activitiesVM.activities.forEach(activity => {
                activity.date = activity.date.split('T')[0];
                // mutating state here
                this.activities.push(activity);
            })
            this.loadInitial = false;
        } catch (error) {
            console.log(error);
            this.loadInitial = false;
        }
    }
}