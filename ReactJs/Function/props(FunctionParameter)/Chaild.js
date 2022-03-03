import React from 'react';
import ReactDOM from 'react-dom';

function Chaild(props)
{
    console.log(props);
    return(
        <div>
        <h3>I am Chaild Component</h3>
        <button onClick={props.OperationHandle}>{props.Operation} AppCount(Chaild button)</button>
        </div>
    );
}
export default Chaild;