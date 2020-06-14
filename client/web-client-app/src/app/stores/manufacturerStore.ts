import {observable} from 'mobx'
import { createContext } from 'react';

class ManufacturerStore {
    @observable title = 'this';
}

export default createContext(new ManufacturerStore());