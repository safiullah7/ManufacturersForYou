import React from 'react'
import { Menu, Container, Button, Image, Dropdown } from 'semantic-ui-react';
import { NavLink, Link } from 'react-router-dom';

const Navbar = () => {
    return (
        <Menu fixed='top' inverted>
            <Container>
                <Menu.Item header as={NavLink} exact to='/somethingelse' >
                    {/* logo here */}
                    <img src="/assets/logo.png" alt="logo" style={{ marginRight: 10 }} />
                    Janjua Traders
                </Menu.Item>

                <Menu.Item name='Home' as={NavLink} to='/' />
                
                <Menu.Item name='Manufacturers' as={NavLink} to='/manufacturers' />

                <Menu.Item name='Products' as={NavLink} to='/products' />

            
            {/* {user && ( */}
                <Menu.Item position='right'>
                    <Image avatar spaced='right' src={'/assets/user.png'} />
                    <Image avatar spaced='right' src={'/assets/user.png'} />
                    <Dropdown pointing='top left' text={'user.displayName'}>
                        <Dropdown.Menu>
                            <Dropdown.Item as={Link} to={`/profile/user.username`} text='My profile' icon='user' />
                            <Dropdown.Item text='Logout' icon='power' />
                                {/* onClick={logout}  /> */}
                        </Dropdown.Menu>
                    </Dropdown>
                </Menu.Item>
                {/* )} */}
            </Container>
        </Menu>
    )
}

export default Navbar
