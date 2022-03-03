import React,{useState} from 'react';
import ReactDOM from 'react-dom';

function ArrayState()
{

    const[Person,setPerson]=useState(['','']);
    const updatePerson=(index,val) => {
        setPerson([...Person.slice(0,index),val,...Person.slice(index+1)]);
    }

    return(
        <div>
        <h1>Array State</h1>
        <label htmlFor='fName'>First Name:</label>
        <input type='text' value={Person[0]} name='fName' onChange={e=>updatePerson(0,e.target.value)}/>
        <label htmlFor='lName'>Last Name:</label>
        <input type='text' value={Person[1]} name='lName' onChange={e=>updatePerson(1,e.target.value)}/>
        <h3>{JSON.stringify(Person)}</h3>
        </div>
    );

}
export default ArrayState;