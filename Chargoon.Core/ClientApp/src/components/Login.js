import React, { Component } from 'react'
import { Col, Row, FormGroup, ControlLabel, FormControl, Button, Panel} from 'react-bootstrap';

export default class Login extends Component {
    state = {
        value: ''
    }
    render() {
        return (
            <div >
                <Row className="login">
                    <Col sm={4}>
                        <Panel>
                            <form>
                                <FormGroup>
                                    <ControlLabel>please enter phoneNumber ....</ControlLabel>
                                    <FormControl
                                        type="text"
                                        value={this.state.value}
                                        placeholder="Enter phoneNumber"
                                        onChange={this.handleChange}
                                    />
                                </FormGroup>
                                <Button type="submit">send code</Button>
                            </form>
                        </Panel>
                    </Col>
                </Row>
            </div>
        )
    }
}
