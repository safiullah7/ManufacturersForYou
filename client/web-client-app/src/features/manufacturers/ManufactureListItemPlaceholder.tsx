import React, { Fragment } from 'react'
import { Button, Card, Divider, Image, Placeholder, Grid } from 'semantic-ui-react'

const iterations = [0,1,2,3,4,5,6,7,8,9,10];

const ManufactureListItemPlaceholder = () => {
    return (
        <>
            <Grid.Column width={16}>
                <Card.Group doubling itemsPerRow={3} stackable>
                    {iterations.map((i) => (
                        <Card key={i}>
                            <Placeholder>
                                <Placeholder.Image square />
                            </Placeholder>
                            <Card.Content>
                                <Placeholder>
                                    <Placeholder.Header>
                                        <Placeholder.Line length='very short' />
                                        <Placeholder.Line length='medium' />
                                    </Placeholder.Header>
                                    <Placeholder.Paragraph>
                                        <Placeholder.Line length='short' />
                                    </Placeholder.Paragraph>
                                </Placeholder>
                            </Card.Content>

                            {/* <Card.Content extra>
                                <Button disabled={loading} primary>Add</Button>
                                <Button disabled={loading}>Delete</Button>
                            </Card.Content> */}
                        </Card>
                    ))}
                </Card.Group>
            </Grid.Column>
        </>
    )
}

export default ManufactureListItemPlaceholder
