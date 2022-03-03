import React,{Fragment,useState} from 'react';
import ReactDOM from 'react-dom';
import Chaild from './Chaild.js';

function App()
{
    const initialCount=0;
    const[appCount,setAppCount]=useState(initialCount);
    const appCountIncrementHandle=function(){
        setAppCount(prevCount => prevCount+1)
        console.log('appCountIncrementHandle Called');
    }
    const appCountDecrementHandle=()=>{
        setAppCount(prevCount => prevCount-1)
        console.log('appCountDecrementHandle called');
    }
    return(
        <Fragment>
        <h1>App Count:{appCount}</h1>
        <Chaild OperationHandle={appCountIncrementHandle} Operation='Increment' />
        <Chaild OperationHandle={appCountDecrementHandle} Operation='Decrement'/>
        </Fragment>
    )

}
export default App;
