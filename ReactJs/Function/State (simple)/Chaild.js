import React,{useState} from 'react';
import ReactDOM from 'react-dom';

function Chaild(props)
{
    const initialMessage='Click subscribe for our News Letter';
    const [message,setState]=useState(initialMessage);
    
   return(
       <div>
       <h3>{message}</h3>
       <button onClick={()=>setState('Thank you for Subscribing')}>Subscribe</button>
       </div>
   );
}
export default Chaild;