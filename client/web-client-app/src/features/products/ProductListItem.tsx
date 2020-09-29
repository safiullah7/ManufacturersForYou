import React, { Fragment } from 'react'
import { Card, Image, Button } from 'semantic-ui-react'
import { IProduct } from '../../app/models/manufacturer'
import { observer } from 'mobx-react-lite'
import { Link } from 'react-router-dom'

interface IProps {
    product: IProduct
}

const ProductListItem: React.FC<IProps> = ({product}) => {
    return (
        <Fragment>
            <Card>
                <Image src={product.imageUrl} />
                <Card.Content>
                    <Fragment>
                        <Card.Header>{product.name}</Card.Header>
                        <Card.Meta>{product.price}</Card.Meta>
                        <Card.Description>{product.description}</Card.Description>
                    </Fragment>
                </Card.Content>
                <Card.Content extra>
                    <Button as={Link} to={`/products/${product.id}`} primary>Details</Button>
                </Card.Content>
            </Card>
        </Fragment>
    )
}

export default observer(ProductListItem);
