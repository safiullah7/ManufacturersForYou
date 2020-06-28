import React, { useContext, useState, useEffect } from 'react'
import { Grid } from 'semantic-ui-react'
import { RootStore, RootStoreContext } from '../../app/stores/rootStore'
import { observer } from 'mobx-react-lite';

const HomePage = () => {
    const rootStore = useContext(RootStoreContext);
    const {
        loadManufacturers,
        loadingManufacturers,
        setPage,
        page,
        totalPages,
        manufacturersByName
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
                {/* <Grid.Column width={4}>
                    {loadingInitial && page === 0 ? (
                        <ActivityListItemPlaceholder />
                    ) : (
                            <InfiniteScroll
                                pageStart={0}
                                loadMore={handleGetNext}
                                hasMore={!loadingNext && page + 1 < totalPages}
                                initialLoad={false}
                            >
                                <ActivityList />
                            </InfiniteScroll>
                        )}
                </Grid.Column> */}
                <Grid.Column width={16}>
                    {loadManufacturers && manufacturersByName.map((manufacturer) => (
                        <div>
                            name is : {manufacturer.name}
                        </div>
                    ))}
                </Grid.Column>

                <Grid.Column width={10}>
                    {/* <Loader active={loadingNext} /> */}
                </Grid.Column>
            </Grid>
        </div>
    )
}

export default observer(HomePage)
