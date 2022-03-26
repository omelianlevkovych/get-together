import { action, makeAutoObservable, makeObservable, observable } from "mobx";

export default class ActivityStore {


    constructor() {
        makeAutoObservable(this)
    }
}

