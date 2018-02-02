import React, { Component } from 'react';
import data from './data.js'

import 'bootstrap/dist/css/bootstrap.min.css';
import Turn from './Turn';

class App extends Component {

  constructor(props) {
    super(props)
    this.state = { turns: data.turns }
  }


  render() {
    return (
      <div className="container-fluid">
        <header className="App-header">
          <h1 className="App-title">Worms Gif leaderboard</h1>
        </header>
        <div className="card-columns">
          {this.state.turns.map(
            t => <Turn turnDetails={t} />
          )}
        </div>
      </div>
    );
  }
}

export default App;
