import React, { Component } from 'react';
import { Lokka } from "lokka";
import { Transport } from "lokka-transport-http";
import 'bootstrap/dist/css/bootstrap.css';

import PeopleList from "./PeopleList";
import logo from './logo.svg';
import './App.css';

class App extends Component {

  constructor(){
    super();

    this.state = {people: []}
    this.getPeople.bind(this.getPeople);
  }

  componentDidMount(){
    this.getPeople();
  }

  getPeople(){
    const headers = {
      'Access-Control-Allow-Origin': '*'
    };
    const client = new Lokka({
      transport: new Transport('http://localhost:5000/graphql',{ headers }),
    });
    const query = `{people{name, age}}`;

    client.query(query).then(result => {
        this.setState({people: result.people});
    });
  }

  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">GrapqQL client</h1>
        </header>
        <p className="App-intro"></p>
        <div className="container">
        <h1>People</h1>
          <PeopleList people={this.state.people} />
        </div>
      </div>
    );
  }
}

export default App;
