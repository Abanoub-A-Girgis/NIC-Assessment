import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Login } from './components/Login';
import { Home } from './components/Home';
import { Users } from './components/Users';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/Login' component={Login} />
        <Route path='/Home' component={Home} />
        <Route path='/Users' component={Users} />
      </Layout>
    );
  }
}
