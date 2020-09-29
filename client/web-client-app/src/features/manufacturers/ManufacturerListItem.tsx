import React, { Fragment } from 'react'
import { Card, Image, Button, Item, Icon, Label } from 'semantic-ui-react'
import { IManufacturer } from '../../app/models/manufacturer'
import { observer } from 'mobx-react-lite'
import { Link } from 'react-router-dom'

interface IProps {
    manufacturer: IManufacturer
}

const ManufacturerListItem: React.FC<IProps> = ({ manufacturer }) => {
    return (
        <Fragment>
            <Item key={manufacturer.id}>
                <Item.Image src={manufacturer.imageUrl || 'https://react.semantic-ui.com/images/wireframe/image.png'} />
                <Item.Content>
                    <Item.Header as='a'>{manufacturer.name}</Item.Header>
                    <Item.Meta>
                        <span className='location'>{manufacturer.city}</span>
                    </Item.Meta>
                    <Item.Description>{manufacturer.description}</Item.Description>
                    <Item.Extra>
                        <Button primary floated='right' as={Link} to={`/manufacturers/${manufacturer.id}`}>
                            Check Products
                            <Icon name='chevron right' />
                        </Button>
                        <Label>{manufacturer.category || 'No Category yet'}</Label>
                    </Item.Extra>
                </Item.Content>
            </Item>
        </Fragment>
    )
}

export default observer(ManufacturerListItem);