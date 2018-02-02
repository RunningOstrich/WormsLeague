import React, { Component } from 'react'

class Turn extends Component {
  
  render() {
    const turnNumber = this.props.turnDetails.number;
    const teamName = this.props.turnDetails.team;
    const filePath = require('./images/' + this.props.turnDetails.fileName);

    return <div className='turn-container'>
      <p>{turnNumber} - {teamName}</p>
      <img src={filePath} height='200px' width='250px' />
    </div>
  }
}

export default Turn