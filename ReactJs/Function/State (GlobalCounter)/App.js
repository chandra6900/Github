import React,{useState} from 'react';
import ReactDOM from 'react-dom';

function App()
{
    const initialCount=0;
    const [count,setCount]=useState(0);
    const IncrementTen=()=>{
         for(let i=0;i<10;i++)
         {
                //Thinking that every iteration 'chaildCount increments by 1'
                //This won't work
                //setCount(prevcount+1);
            //This will work
            setCount(prevCount=>prevCount+1);
        }
    }

    const IncrementTwenty= () => {
        for(let i=0;i<20;i++)
        {
        setCount(IncrementUsingPrevCount);
        }
    }

    const IncrementUsingPrevCount= function(prevCount){
         return prevCount+1; 
        }

    return(<div>
     <h1>Count:{count}</h1>
     <button onClick={()=>setCount(count+1)}>Increment</button>
     <button onClick={()=>setCount(count-1)}>Decrement</button>
     <button onClick={()=>setCount(initialCount)}>Reset</button>
     <button onClick={IncrementTen}>Increment By 10</button>
     <button onClick={IncrementTwenty}>Increment By 20</button>
     </div>
    );

}

export default App;