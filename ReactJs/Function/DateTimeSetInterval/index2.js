import React from 'react';
import ReactDOM from 'react-dom';

function Clock()
{
    return <h1>{new Date().toLocaleString()}</h1>
}


function tick()
{
ReactDOM.render(<Clock />,document.getElementById('root'));
}

setInterval(tick,1000);
