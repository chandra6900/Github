import React,{Fragment} from 'react';
import ReactDOM from 'react-dom';

function App()
{
    let DisplayText='Hello';
    const updateDisplayText=() => {
        DisplayText='Hello World';
        console.log(`updateDisplayText is called,DisplayText:${DisplayText}`);
}
    return(
        <Fragment>
            <h1>App Component DisplayText:{DisplayText}</h1>
            <button onClick={updateDisplayText}>Update DisplayText</button>
        </Fragment>
    );
}
export default App;