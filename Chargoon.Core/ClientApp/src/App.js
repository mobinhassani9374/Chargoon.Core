﻿import React from 'react';
import { Route } from 'react-router';
// import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Login from './components/Login';
import Register from './components/Register';

export default () => (
  <div>
    <Route exact path='/' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/login' component={Login} />
    <Route path='/Register' component={Register} />
    <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
  </div>
);
