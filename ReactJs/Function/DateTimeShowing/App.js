import React from 'react';
import ReactDOM from 'react-dom';

function App()
{
    const dateTime=new Date();
    return <h1>{dateTime.toLocaleString()}</h1>
}
export default App;