import React from 'react';
import ReactDOM from 'react-dom';
import Chaild from './Chaild.js';

function App()
{
    const dispTitle='I am chaild component 2 and i have children too';
 return(
    <div>
        <h1>I am Parent Component </h1>
        <Chaild title='I am chaild component 1'/>
        <Chaild title={dispTitle}>
            <p>I am Chaild 2 chaild</p>
            <button>I am also</button>
        </Chaild>
    </div>
 );
}
export default App;