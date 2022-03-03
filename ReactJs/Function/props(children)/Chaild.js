import React from 'react';
import ReactDOM from 'react-dom';

function Chaild(props)
{

return(
    <div>
    <h2>{props.title}</h2>
    {props.children}
    </div>
    );

}
export default Chaild;