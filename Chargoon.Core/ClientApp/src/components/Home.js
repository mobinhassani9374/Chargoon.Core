
import React, { Component } from 'react'
import { connect } from 'react-redux';
import { actionCreators } from '../store/authorize';
import { bindActionCreators } from 'redux';
import { Redirect } from 'react-router'

class Home extends Component {

  componentDidMount() {
    let {auth} = this.props.authorize
    if(auth===false) {
      let {history} = this.props
      history.push('/login')
    }
  }
  render() {
    return (
      <div>
        hello world ......
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

