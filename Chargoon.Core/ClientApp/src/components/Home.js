
import React, { Component } from 'react'
import { connect } from 'react-redux';
import { actionCreators } from '../store/authorize';
import { bindActionCreators } from 'redux';
import { Link } from 'react-router-dom';

class Home extends Component {

  componentDidMount() {
    let token = localStorage.getItem('token')
    if (token === null) {
      let { history } = this.props
      history.push('/login')
    }
  }

  logOut=()=>{
    localStorage.removeItem('token')
    let { history } = this.props
    history.push('/login')
  }
  render() {
    return (
      <div>
        hello world ......

        <a onClick={this.logOut}>خروج</a>
      </div>
    )
  }
}

const mapPropsToState = (state) => {
  return state;
}

const mapDispatchToProps = (dispatch) => {
  return bindActionCreators(actionCreators, dispatch);
}

export default connect(mapPropsToState, mapDispatchToProps)(Home);

