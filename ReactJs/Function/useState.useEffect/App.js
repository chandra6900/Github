import React,{useState,useEffect} from 'react';
import ReactDOM from 'react-dom';
import Chaild from './Chaild.js';

function App()
{
    console.log('App Component function Called');
    const [AppCount,setAppCount]= useState(0);
    const updateAppCount=()=>{setAppCount(
        prevState => prevState+1
    )
    //we won't get actual incremented count here becuse setAppCount is Async method
    console.log('App useState Async updateAppCount called,Count:'+AppCount);
    }
    useEffect(
        ()=> {
             //Here we can see Actual updated Count 
            console.log('App useEffect called, Here we can see App Actual Count:'+AppCount);
        }
    )
    
    return(
        <div>
        <h1>App Component : {AppCount}</h1>
        <button onClick={updateAppCount}>App Click</button>
        <Chaild />
        </div>
    );
}
export default App;