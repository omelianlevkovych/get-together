import React, { Fragment } from 'react';
import { Button, Container, Menu } from 'semantic-ui-react';
import { useStore } from '../stores/store';

export default function NavBar() {
    const {activityStore} = useStore();

    return (
        <Fragment>
            <Menu inverted fixed='top'>
                <Container>
                    <Menu.Item header>
                        <img src="/assets/logo.jpg" alt="logo" style={{marginRight: '10px'}}/>
                        Get together
                    </Menu.Item>
                    <Menu.Item name='Activities'/>
                    <Menu.Item>
                        <Button onClick={() => activityStore.openForm()} positive content='Create Activity'/>
                    </Menu.Item>
                </Container>
            </Menu>
        </Fragment>
    )
}