import React, { useState } from 'react'
import { Menu, Segment } from 'semantic-ui-react'
import { observer } from 'mobx-react-lite'
import { NavLink, Link } from 'react-router-dom'
import ManufacturerPageBodyProducts from './manufacturerBody/ManufacturerPageBodyProducts'
import ManufacturerPageBodyComments from './manufacturerBody/ManufacturerPageBodyComments'
import ManufacturerPageBodyAbout from './manufacturerBody/ManufacturerPageBodyAbout'
import { IManufacturer } from '../../app/models/manufacturer'

interface IProps {
    manufacturer: IManufacturer
}

const ManufacturerPageBody: React.FC<IProps> = ({ manufacturer }) => {
    const [tabState, setTabState] = useState("products");

    const handleSetTabState = (value: string) => {
        setTabState(value);
        return (
            <div>
                something
            </div>
        );
    }
    return (
        <>
            <Menu pointing secondary>
                <Menu.Item
                    name='products'
                    // as={Link}
                    onClick={() => handleSetTabState('products')}
                    // component={() => <ManufacturerPageBodyProducts manufacturer={manufacturer} />}
                    active={tabState === 'products'}
                />
                <Menu.Item
                    name='comments'
                    // as={Link}
                    onClick={() => handleSetTabState('comments')}
                    // component={ManufacturerPageBodyComments}
                    active={tabState === 'comments'}
                />
                {/* <Menu.Item
                name='Reviews'
                as={Link}
                component={ManufacturerPageBodyProducts}
            /> */}
                <Menu.Item
                    name='about'
                    // as={Link}
                    onClick={() => handleSetTabState('about')}
                    // component={ManufacturerPageBodyAbout}
                    active={tabState === 'about'}
                />
            </Menu>

            <div>
                {tabState === 'products' ? <ManufacturerPageBodyProducts manufacturer={manufacturer} />
                    : tabState === 'comments' ? <ManufacturerPageBodyComments />
                    : <ManufacturerPageBodyAbout />}
            </div>

        </>
    )
}

export default observer(ManufacturerPageBody);
