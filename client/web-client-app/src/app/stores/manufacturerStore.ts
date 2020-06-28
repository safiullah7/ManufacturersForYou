import { RootStore } from './rootStore';
import {observable, action, computed, runInAction} from 'mobx'
import agent from '../api/agent';

const LIMIT = 2;

export class ManufacturerStore {
    rootStore: RootStore;
    constructor(rootStore: RootStore) {
        this.rootStore = rootStore;
    }

    @observable manufacturersRegistry = new Map();
    @observable loadingManufacturers = false;
    @observable page = 0;
    @observable manufacturersCount = 0;

    @computed get axiosParams() {
        const params = new URLSearchParams();
        params.append('limit', String(LIMIT));
        params.append('offset', `${this.page ? this.page * LIMIT : 0}`);
        return params;
    }
    @computed get totalPages() {
        return Math.ceil(this.manufacturersCount / LIMIT);
    }
    @computed get manufacturersByName() {
        return Array.from(this.manufacturersRegistry.values()).sort(function(a, b){
            if(a.name < b.name) { return -1; }
            if(a.name > b.name) { return 1; }
            return 0;
        });
    }

    @action loadManufacturers = async () => {
        this.loadingManufacturers = true;
        try {
            const manufacturersEnvelope = await agent.manufacturers.list(this.axiosParams);
            const {manufacturers, manufacturersCount} = manufacturersEnvelope;
            runInAction('loading manufacturers', () => {
                manufacturers.forEach(manufacturer => {
                    this.manufacturersRegistry.set(manufacturer.id, manufacturer);
                });
                this.manufacturersCount = manufacturersCount;
                this.loadingManufacturers = false;
            })
        } catch (error) {
            runInAction('loading manufacturers error', () => {
                this.loadingManufacturers = false;
            })
        }
    }

    @action setPage = (page: number) => {
        this.page = page;
    }
}