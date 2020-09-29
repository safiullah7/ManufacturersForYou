import React, { Fragment } from 'react'
import { Segment, Header, Comment } from 'semantic-ui-react'
import { Link } from 'react-router-dom'

const ManufacturerPageBodyComments = () => {
    return (
        <Fragment>
            <Segment
                textAlign='center'
                attached='top'
                inverted
                color='teal'
                style={{ border: 'none' }}
            >
                <Header>Chat about this event</Header>
            </Segment>
            <Segment attached>
                <Comment.Group>
                    {/* {activity && activity.comments && activity.comments.map((comment) => ( */}
                        <Comment key={'comment.id'}>
                            <Comment.Avatar src={'comment.image' || '/assets/user.png'} />
                            <Comment.Content>
                                <Comment.Author as={Link} to={`/profile/${'comment.username'}`}>{'comment.displayName'}</Comment.Author>
                                <Comment.Metadata>
                                    {/* <div>{formatDistance(comment.createdAt, new Date())}</div> */}
                                </Comment.Metadata>
                                <Comment.Text>{'comment.body'}</Comment.Text>
                            </Comment.Content>
                        </Comment>
                    {/* ))} */}

                    {/* <FinalForm
                        onSubmit={addComment}
                        render={({ handleSubmit, submitting, form }) => (
                            <Form onSubmit={() => handleSubmit()!.then(() => form.reset())}>
                                <Field
                                    name='body'
                                    component={TextAreaInput}
                                    rows={2}
                                    placeholder='Add your comment'
                                />
                                <Button
                                    loading={submitting}
                                    content='Add Reply'
                                    labelPosition='left'
                                    icon='edit'
                                    primary
                                />
                            </Form>
                        )}
                    /> */}

                </Comment.Group>
            </Segment>
        </Fragment>
    )
}

export default ManufacturerPageBodyComments
