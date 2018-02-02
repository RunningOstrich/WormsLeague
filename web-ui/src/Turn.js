import React, { Component } from 'react';
import Emoji from 'react-emoji-render';

class Turn extends Component {
  
  render() {
    const turnNumber = this.props.turnDetails.number;
    const teamName = this.props.turnDetails.team;
    const filePath = require('./images/' + this.props.turnDetails.fileName);

    return <div className='card'>
        <img src={filePath} className="card-img-top" style={{"width" : "200px"}} />
        <div className="card-body">
            <h5>{turnNumber}</h5>
            <p className="card-text">{teamName}</p>
            <a href="#" className="btn btn-primary"><Emoji text=":+1:" /></a>
            <a href="#" className="btn btn-primary"><Emoji text=":-1:" /></a>
        </div>
    </div>
  }
}

export default Turn