import React, { useContext, useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import { RouteComponentProps } from 'react-router-dom'
import { RootStoreContext } from '../../app/stores/rootStore';
import LoadingComponent from '../../app/layout/LoadingComponent';
import { Grid } from 'semantic-ui-react';
import ManufacturerPageHeader from './ManufacturerPageHeader';
import ManufacturerPageBody from './ManufacturerPageBody';

interface DetailParams {
    id: string
}

const ManufacturerPage: React.FC<RouteComponentProps<DetailParams>> = ({ match, history }) => {
    const rootStore = useContext(RootStoreContext);
    const {
        loadManufacturer,
        loadingInitial,
        manufacturer
    } = rootStore.manufacturerStore;

    useEffect(() => {
        loadManufacturer(match.params.id);
    }, [loadManufacturer, match.params.id, history]);

    if (loadingInitial) return <LoadingComponent content='Loading manufacturer...' />;

    if (!manufacturer) return <h2>Manufacturer not found</h2>;

    return (
        <Grid>
            <Grid.Column width={4}>
                sidebar comes here
            </Grid.Column>
            <Grid.Column width={12}>
                <ManufacturerPageHeader manufacturer={manufacturer} />
                <ManufacturerPageBody manufacturer={manufacturer} />
            </Grid.Column>
        </Grid>
    )
}

export default observer(ManufacturerPage)
