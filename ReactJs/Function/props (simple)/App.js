import React from 'react';
import ReactDOM from 'react-dom';

function App(props)
{
    console.log(props);
    console.log(this);
 if(props.name===undefined)
 return 'Hello';
 else
 return 'Hello '+props.name;
}
export default App;