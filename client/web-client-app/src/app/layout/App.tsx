import React, { Fragment } from 'react';
import './App.css';
import { RouteComponentProps, withRouter, Route, Switch } from 'react-router-dom';
import HomePage from '../../features/home/HomePage';
import Navbar from '../../features/nav/Navbar';
import { Container } from 'semantic-ui-react';
import ManufacturersPage from '../../features/manufacturers/ManufacturersPage';
import ProductsPage from '../../features/products/ProductsPage';
import ProfilePage from '../../features/profile/ProfilePage';
import NotFound from './NotFound';
import RedirectToHome from '../../features/home/RedirectToHome';

const App: React.FC<RouteComponentProps> = ({ location }) => {
  return (
    <Fragment>
      <Route exact path='/' component={RedirectToHome} />
      <Route path={'/(.+)'} render={() => (
        <Fragment>
          <Navbar />
          <Container style={{ marginTop: '7em' }}>
            <Switch>
              {/* <Switch> tells us that each route is exclusive and dont load any other route in
                  some route */}
              <Route exact path='/home' component={HomePage} />
              <Route exact path='/manufacturers' component={ManufacturersPage} />
              <Route path='/products' component={ProductsPage} />
              <Route path='/profile/:username' component={ProfilePage} />
              <Route component={NotFound} />
              {/* this will load <NotFound/> comp in every route.
                  need to make use of switch */}
            </Switch>
          </Container>
        </Fragment>
      )} />
    </Fragment>
  );
}

export default withRouter(App);
