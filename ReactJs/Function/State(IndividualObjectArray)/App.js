import React from 'react';
import ReactDOM from 'react-dom';
import IndividualState from './IndividualState.js';
import ObjectState from './ObjectState.js';
import ArrayState from './ArrayState.js';

function App()
{

    return(
        <div>
        <IndividualState />
        <ObjectState />
        <ArrayState />
        </div>
    );
}
export default App;
