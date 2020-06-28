import React, { useContext, useState, useEffect } from 'react'
import { Grid } from 'semantic-ui-react'
import { RootStore, RootStoreContext } from '../../app/stores/rootStore'
import { observer } from 'mobx-react-lite';
import InfiniteScroll from 'react-infinite-scroller';
import ManufactureList from '../manufacturers/ManufactureList';
import ManufactureListItemPlaceholder from '../manufacturers/ManufactureListItemPlaceholder';

const HomePage = () => {
    const rootStore = useContext(RootStoreContext);
    const {
        loadManufacturers,
        loadingManufacturers,
        setPage,
        page,
        totalPages
    } = rootStore.manufacturerStore;

    const [loadingNext, setLoadingNext] = useState(false);

    const handleGetNext = () => {
        setLoadingNext(true);
        setPage(page + 1);
        loadManufacturers().then(() => setLoadingNext(false));
    };

    useEffect(() => {
        loadManufacturers();
    }, [loadManufacturers]);
        
    return (
        <div>
            <Grid>
                <Grid.Column width={16}>
                    {loadingManufacturers && page === 0 ? (
                        <ManufactureListItemPlaceholder />
                    ) : (
                            <InfiniteScroll
                                pageStart={0}
                                loadMore={handleGetNext}
                                hasMore={!loadingNext && page + 1 < totalPages}
                                initialLoad={false}
                            >
                                <ManufactureList />
                            </InfiniteScroll>
                        )}
                </Grid.Column>

                <Grid.Column width={10}>
                    {/* <Loader active={loadingNext} /> */}
                </Grid.Column>
            </Grid>
        </div>
    )
}

export default observer(HomePage)
