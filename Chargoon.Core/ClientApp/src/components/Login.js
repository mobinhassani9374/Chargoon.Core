import React, { Component } from 'react'
import { Col, Row, FormGroup, ControlLabel, FormControl, Button, Panel } from 'react-bootstrap';
import axios from 'axios';

export default class Login extends Component {
    state = {
        phoneNumber: '',
        code:'',
        verify: false,
    }

    handleChange = (event) => {
        let {verify} = this.state;
        if(verify) {
            this.setState({ code: event.target.value })
        }
        else {
            this.setState({ phoneNumber: event.target.value })
        }
    }

    handleSubmit = (event) => {
        event.preventDefault()
        let { phoneNumber, verify , code } = this.state;
        if (!verify) {
            if (phoneNumber === '') {
                return alert('phoneNumber is empty ... ')
            }
            axios.post('/api/account/login', {
                phoneNumber: phoneNumber
            }).then(res => {
                if (!res.data.isSuccessed) {
                    alert(res.data.message)
                }
                else {
                    this.setState({ verify: true })
                }
            }).catch(error => {
                alert('error server 500 ')
            })
        }

        else {
            console.log('hello verfify')
            console.log(phoneNumber,code)

            if(code==='') {
               return alert('code is empty ...')
            }

            axios.post('/api/account/verify',{
                phoneNumber , activationCode : code
            }).then(res=>{
                debugger
            }).catch(error=>{
                alert(error)
            })
        }
    }

    render() {
        let { verify } = this.state;
        return (
            <div >
                <Row className="login">
                    <Col sm={4}>
                        <Panel>
                            {
                                !verify ? <form onSubmit={this.handleSubmit}>
                                    <FormGroup>
                                        <ControlLabel>please enter phoneNumber ....</ControlLabel>
                                        <FormControl
                                            type="text"
                                            value={this.state.phoneNumber}
                                            placeholder="Enter phoneNumber"
                                            onChange={this.handleChange}
                                        />
                                    </FormGroup>
                                    <Button type="submit">send code</Button>
                                </form> :
                                    <form onSubmit={this.handleSubmit}>
                                        <FormGroup>
                                            <ControlLabel>please enter code ....</ControlLabel>
                                            <FormControl
                                                type="text"
                                                value={this.state.code}
                                                placeholder="Enter code "
                                                onChange={this.handleChange}
                                            />
                                        </FormGroup>
                                        <Button type="submit">verify</Button>
                                    </form>
                            }
                        </Panel>
                    </Col>
                </Row>
            </div>
        )
    }
}
