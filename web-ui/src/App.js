import React, { Component } from 'react';
import logo from './logo.svg';
import data from './data.js'

import './App.css';
import Turn from './Turn';

class App extends Component {

  constructor(props) {
    super(props)
    this.state = { turns: data.turns }
  }


  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <p className="App-intro">
          {this.state.turns.map(
            t => <Turn turnDetails={t} />
          )}
        </p>
      </div>
    );
  }
}

export default App;
