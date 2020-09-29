import { IProduct, IManufacturer, IManufacturersEnvelope } from './../models/manufacturer';
import axios, { AxiosResponse } from 'axios';
import { history } from '../..';
import { toast } from 'react-toastify';

axios.defaults.baseURL = 'http://localhost:5000/api';

axios.interceptors.request.use(
    (config) => {
        const token = window.localStorage.getItem('jwt');
        if (token) config.headers.authorization = `Bearer ${token}`;
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

axios.interceptors.response.use(undefined, error => { 
    //first param is when successful req, second when promise rejected
    debugger;
    if (error.message === 'Network Error' && !error.response) {
        toast.error('Network Error - make sure the API is running!');
    }
    const {status, data, config} = error.response;
    if (status === 404) {
        history.push('/notfound');
    }
    if (status === 400 && config.method === 'get' && data.errors.hasOwnProperty('id')) {
        history.push('/notfound');
    }
    if (status === 500) {
        toast.error('Server error - check the terminal for more info!');
    }
    throw error.response;
});

const responseBody = (response: AxiosResponse) => response.data

const requests = {
    get:  (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put:  (url: string, body: {}) => axios.put(url, body).then(responseBody),
    del:  (url: string) => axios.delete(url).then(responseBody),
    postForm: (url: string, file: Blob) => {
        let formData = new FormData();
        formData.append('File', file); // key 'File' must match with api method param
        return axios.post(url, formData, {
            headers: {'Content-type': 'multipart/form-data'}
        }).then(responseBody)
    }
};

const products = {
    list: (): Promise<IProduct[]> => requests.get('/activities'),
    details: (id: string) => requests.get(`/activities/${id}`),
    create: (activity: IProduct) => requests.post('/activities', activity),
    update: (activity: IProduct) => requests.put(`/activities/${activity.id}`, activity),
    delete: (id: string) => requests.del(`/activities/${id}`),
    attend: (id: string) => requests.post(`/activities/${id}/attend`, {}),
    unattend: (id: string) => requests.del(`/activities/${id}/attend`)
};

const manufacturers = {
    list: (params: URLSearchParams): Promise<IManufacturersEnvelope> => axios.get('/manufacturers', {params: params}).then(responseBody),
    details: (id: string) => requests.get(`/manufacturers/${id}`),
    create: (activity: IManufacturer) => requests.post('/activities', activity),
    update: (activity: IManufacturer) => requests.put(`/activities/${activity.id}`, activity),
    delete: (id: string) => requests.del(`/activities/${id}`),
    attend: (id: string) => requests.post(`/activities/${id}/attend`, {}),
    unattend: (id: string) => requests.del(`/activities/${id}/attend`)
};

export default {
    products,
    manufacturers
};
  