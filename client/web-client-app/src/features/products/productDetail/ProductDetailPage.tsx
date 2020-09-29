import React, { useContext, useEffect } from 'react'
import { Segment, Image, Item, Button, Header } from 'semantic-ui-react'
import { Link, RouteComponentProps } from 'react-router-dom'
import { IProduct } from '../../../app/models/manufacturer';
import { RootStoreContext } from '../../../app/stores/rootStore';
import LoadingComponent from '../../../app/layout/LoadingComponent';

const activityImageStyle = {
    filter: 'brightness(30%)'
  };
  
  const activityImageTextStyle = {
    position: 'absolute',
    bottom: '5%',
    left: '5%',
    width: '100%',
    height: 'auto',
    color: 'white'
  };

interface DetailParams {
    id: string
}

const ProductDetailPage: React.FC<RouteComponentProps<DetailParams>> = ({ match, history }) => {
    // const rootStore = useContext(RootStoreContext);
    // const {
    //     loadManufacturer,
    //     loadingInitial,
    //     manufacturer
    // } = rootStore.manufacturerStore;

    // useEffect(() => {
    //     loadManufacturer(match.params.id);
    // }, [loadManufacturer, match.params.id, history]);
    // const product = manufacturer?.products.filter(product => product.id === match.params.id)[0];

    // if (loadingInitial) return <LoadingComponent content='Loading manufacturer...' />;

    // if (!manufacturer) return <h2>Manufacturer not found</h2>;

    return (
        <Segment.Group>
            <Segment basic attached='top' style={{ padding: '0' }}>
                <Image
                    src={product!.imageUrl}
                    fluid
                    style={activityImageStyle}
                />
                <Segment style={activityImageTextStyle} basic>
                    <Item.Group>
                        <Item>
                            <Item.Content>
                                <Header
                                    size='huge'
                                    content={'activity.title'}
                                    style={{ color: 'white' }}
                                />
                                <p>{`format(activity.date, 'eeee do MMMM')`}</p>
                                <p>
                                    Hosted by{' '}
                                    <Link to={'/profile/${host.username}'}>
                                        <strong>{'host.displayName'}</strong>
                                    </Link>
                                </p>
                            </Item.Content>
                        </Item>
                    </Item.Group>
                </Segment>
            </Segment>
            <Segment clearing attached='bottom'>
                {/* {activity.isHost ? (
                    <Button
                        as={Link}
                        to={`/manage/${activity.id}`}
                        color='orange'
                        floated='right'
                    >
                        Manage Event
                    </Button>
                ) : activity.isGoing ? (
                    <Button loading={loading} onClick={cancelAttendance}>
                        Cancel attendance
                    </Button>
                ) : (
                            <Button loading={loading} onClick={attendActivity} color='teal'>
                                Join Activity
                            </Button>
                        )} */}
            </Segment>
        </Segment.Group>
    )
}

export default ProductDetailPage
