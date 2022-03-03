import React,{useEffect,useRef} from 'react';
import ReactDOM from 'react-dom';

const UseRef =()=>{
    const focusingElement=useRef("abc");
    useEffect(()=>{
        console.log(focusingElement.current);
        focusingElement.current.focus();
        console.log('check element focused or not');
    }
    )
    
    return (
        <input ref={focusingElement} type='text' />
    )
}
export default UseRef;