import React, { useContext, Fragment } from 'react'
import { RootStoreContext } from '../../app/stores/rootStore';
import { Card, Segment, Item, Label, Button, Icon } from 'semantic-ui-react';
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
      <Item.Group divided>
        {manufacturersByName.map((manufacturer: IManufacturer) => (
          <ManufacturerListItem manufacturer={manufacturer} />
        ))}
      </Item.Group>
    </Fragment>
  )
}

export default observer(ManufactureList);