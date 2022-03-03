import React,{useState} from 'react';
import ReactDOM from 'react-dom';

function ObjectState()
{
    
    const[Person,setPerson]=useState({fName:'',lName:''});
    const updatePerson=function(property,value){
        setPerson({...Person,[property]:value});
    }
    return(
        <div>
        <h1>Object State</h1>
        <label htmlFor='fName'>First Name:</label>
        <input type='text' name='fName' value={Person.fName} onChange={e=>updatePerson('fName',e.target.value)}/>
        <label htmlFor='lName'>Last Name:</label>
        <input type='text' name='lName' value={Person.lName} onChange={e=>updatePerson('lName',e.target.value)}/>
        <h3>{JSON.stringify(Person)}</h3>
        </div>
    )
}
export default ObjectState;

