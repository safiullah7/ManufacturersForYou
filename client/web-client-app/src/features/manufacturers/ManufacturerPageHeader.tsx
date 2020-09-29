import React from 'react'
import { Header, Icon, Image, Segment } from 'semantic-ui-react'
import { IManufacturer } from '../../app/models/manufacturer'
import { observer } from 'mobx-react-lite'

interface IProps {
    manufacturer: IManufacturer
}

const ManufacturerPageHeader: React.FC<IProps> = ({manufacturer}) => {
    return (
        <Segment>
            <Header as='h2' icon textAlign='center'>
                <Icon name='building' circular />
                <Header.Content>{manufacturer.name}</Header.Content>
            </Header>
            <Image
                centered
                size='large'
                src={manufacturer.imageUrl}
            />
        </Segment>
    )
}

export default observer(ManufacturerPageHeader);
