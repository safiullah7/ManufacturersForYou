import React, { useContext, Fragment } from 'react'
import { RootStoreContext } from '../../app/stores/rootStore';
import { Card, Segment } from 'semantic-ui-react';
import { IManufacturer } from '../../app/models/manufacturer';
import ManufacturerListItem from './ManufacturerListItem';
import { observer } from 'mobx-react-lite';
import ProductListItem from '../products/ProductListItem';

const ManufactureList = () => {
    const rootStore = useContext(RootStoreContext);
    const {
        manufacturersByName
    } = rootStore.manufacturerStore;
    return (
        <Fragment>
            <Card.Group doubling itemsPerRow={3} >
                {manufacturersByName.map((manufacturer: IManufacturer) => (
                  <Segment key={manufacturer.id} >
                    <ManufacturerListItem manufacturer={manufacturer} />
                    
                    <Card.Group doubling itemsPerRow={5} stackable>
                      {manufacturer.products && manufacturer.products.map((product) => (
                        <ProductListItem key={product.id} product={product} />
                      ))}
                    </Card.Group>
                  </Segment>
                ))}
            </Card.Group>
        </Fragment>
    )
}

export default observer(ManufactureList);