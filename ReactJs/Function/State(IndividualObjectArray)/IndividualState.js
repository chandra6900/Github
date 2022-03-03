import React,{useState} from 'react';
import ReactDOM from 'react-dom';

function IndividualState()
{ 

    const [fName,setFName]=useState('');
    const [lName,setLName]=useState('');
    const updateFName=function(e){
        let val = e.target.value;
    setFName(
        function (prev) {
            return val;
          }
        );
    }
    const updateFNameUsingPrevState=function(e,PrevState){

    }
    const updateLName=function(e){
        let val = e.target.value;
        setLName(
            function (prev) {
                return val;
              }
            );
        }
    const updateLNameUsingPrevState=function(e,PrevState){
        
    }
  return(
      <div>     
        <h1>Individual State</h1>
        <label htmlFor='fName'>First Name:</label>
        <input type='text' value={fName} name='fName' onChange={updateFName}/>  
        <label htmlFor='fname'>Last Name:</label>
        <input type='text' value={lName} name='lName' onChange={updateLName}/>
        <h3>{fName} {lName}</h3>
      </div>
  )

}
export default IndividualState;