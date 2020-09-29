import React, { Fragment } from 'react'
import { Card, Image, Button } from 'semantic-ui-react'
import { IManufacturer } from '../../app/models/manufacturer'
import { observer } from 'mobx-react-lite'
import { Link } from 'react-router-dom'

interface IProps {
    manufacturer: IManufacturer
}

const ManufacturerListItem: React.FC<IProps> = ({manufacturer}) => {
    return (
        <Fragment>
            <Card>
                <Image src={"manufacturer.imageurl"} />
                <Card.Content>
                    <Fragment>
                        <Card.Header>{manufacturer.name}</Card.Header>
                        <Card.Meta>{manufacturer.city}</Card.Meta>
                        <Card.Description>{manufacturer.products.length}</Card.Description>
                    </Fragment>
                </Card.Content>
                <Card.Content extra>
                    <Button as={Link} to={`/manufacturers/${manufacturer.id}`} primary>Check Products</Button>
                </Card.Content>
            </Card>
        </Fragment>
    )
}

export default observer(ManufacturerListItem);