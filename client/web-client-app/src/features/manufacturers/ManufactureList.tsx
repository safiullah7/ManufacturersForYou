import React, { useContext, Fragment } from 'react'
import { RootStoreContext } from '../../app/stores/rootStore';
import { Card, Image, Button } from 'semantic-ui-react';
import { IManufacturer } from '../../app/models/manufacturer';

const ManufactureList = () => {
    const rootStore = useContext(RootStoreContext);
    const {
        manufacturersByName
    } = rootStore.manufacturerStore;
    return (
        <Fragment>
            <Card.Group doubling itemsPerRow={3} stackable>
                {manufacturersByName.map((manufacturer: IManufacturer) => (
                    <Card key={manufacturer.id}>-
                      <Image src={"manufacturer.imageurl"} />-
                    <Card.Content>
                        <Fragment>
                          <Card.Header>{manufacturer.name}</Card.Header>
                          <Card.Meta>{manufacturer.city}</Card.Meta>
                          <Card.Description>{manufacturer.products.length}</Card.Description>
                        </Fragment>
                    </Card.Content>
      
                    <Card.Content extra>
                      <Button primary>
                        Check Products
                      </Button>
                    </Card.Content>
                  </Card>
                ))}
            </Card.Group>
        </Fragment>
    )
}

export default ManufactureList
