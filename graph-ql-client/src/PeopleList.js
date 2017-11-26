import React, { Component } from 'react';

export default class PeopleList extends Component{
    render(){
        return(<div>{this.props.people.map((person,index) => <div key={index}>{person.name}, {person.age}</div>)}</div>);
    }
}