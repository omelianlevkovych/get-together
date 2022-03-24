import axios, { AxiosResponse } from 'axios';
import { ActivityViewModel } from "../models/activities";

axios.defaults.baseURL = 'http://localhost:5245/api';

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody),
}

const Activities = {
    list: () => requests.get<ActivityViewModel>('/activities')
}

const agent = {
    Activities 
}

export default agent;

