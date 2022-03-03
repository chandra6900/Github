import React,{useState,useEffect} from 'react';
import ReactDOM from 'react-dom';

function Chaild()
{
    console.log('Chaild Component function called');
    const [ChaildCount,setChaildCount]=useState(0);
    const updateChaildCount=() => {setChaildCount(
        prevState => prevState+1
    )
    //we won't get actual incremented count here becuse setChaildCount is Async method
    console.log('Chaild useState Async updateChaildCount called,Count:'+ChaildCount);
    }
    useEffect(
        ()=> {
            //Here we can see Actual updated Count
            console.log(`Chaild useEffect called, Here we can see Chaild Actual Count:${ChaildCount}`);            
    }

    )
    
    return(
        <div>
        <h1>Chaild Component : {ChaildCount}</h1>
        <button onClick={updateChaildCount}>Chaild Click</button>
        </div>
    );

}
export default Chaild;