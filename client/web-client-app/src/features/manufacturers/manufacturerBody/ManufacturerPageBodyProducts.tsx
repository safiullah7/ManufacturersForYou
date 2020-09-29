import React from 'react'
import { IManufacturer } from '../../../app/models/manufacturer'
import { Segment, Card } from 'semantic-ui-react'
import ProductListItem from '../../products/ProductListItem'

interface IProps {
    manufacturer: IManufacturer
}

const ManufacturerPageBodyProducts: React.FC<IProps> = ({manufacturer}) => {
    return (
        <Segment>
            <Card.Group doubling itemsPerRow={3} stackable>
                {manufacturer.products.map((product) => (
                    <ProductListItem key={product.id} product={product} />
                ))}
            </Card.Group>
        </Segment>
    )
}

export default ManufacturerPageBodyProducts
