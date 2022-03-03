import React,{useState} from 'react';
import ReactDOM from 'react-dom';
import Chaild from './Chaild.js';

function App(props)
{
    const appInitialCount=0;

    const [appCount,setAppCount]= useState(appInitialCount);

    console.log('I am from App component');

 return(
    <div>
    <h1>App Count: {appCount}</h1>
    <button onClick={()=>setAppCount(appCount+1)}>App Button</button>
    <Chaild compName='Chaild 1' initialCount={0}/>
    <Chaild compName='Chaild 2' initialCount={0} stepValue={5}/>
    <Chaild compName='Chaild 3' initialCount={0} stepValue={10}/>
    </div>
 );

}
export default App;