import { ManufacturerStore } from './manufacturerStore';
import { createContext } from 'react';
import { configure } from 'mobx';

configure({enforceActions: 'always'});

export class RootStore {
    manufacturerStore: ManufacturerStore;

    constructor() {
        this.manufacturerStore = new ManufacturerStore(this);
    }
}

export const RootStoreContext = createContext(new RootStore());