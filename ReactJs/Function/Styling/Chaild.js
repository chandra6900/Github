import React from 'react';
import ReactDOM from 'react-dom';
import './Chaild.css';

function Chaild(props)
{
   return(
       <div>
       
       <h2 style={{display: 'inline'}}>Hello </h2>
       <h1 className='blueText' style={{display: 'inline'}}>{props.name}! </h1> 
       <h2 style={{display: 'inline'}}>welcome to <span class='text-danger'>Plurlsight</span></h2>
       <h4>Click subscribe for our <span class='text-success'>News Letter</span></h4>
       <button class='btn btn-primary' >Subscribe</button>
       
       </div>
   );
}
export default Chaild;