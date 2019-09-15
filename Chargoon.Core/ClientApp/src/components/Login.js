import React, { Component } from 'react'
import { Col, Row, FormGroup, ControlLabel, FormControl, Button, Panel} from 'react-bootstrap';

export default class Login extends Component {
    state = {
        value: ''
    }

    handleChange=(event)=> {
        this.setState({value:event.target.value})
    }

    handleSubmit=(event)=>{
        event.preventDefault()
        let {value} = this.state;
        if(value=='') {
            alert('phoneNumber is empty ... ')
        }
    }
    render() {
        return (
            <div >
                <Row className="login">
                    <Col sm={4}>
                        <Panel>
                            <form onSubmit={this.handleSubmit}>
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
