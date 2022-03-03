import React,{useState,useEffect} from 'react';
import ReactDOM from 'react-dom';

function App()
{
    const initialCount=0;
    const [count1,setCount1]=useState(initialCount);
    const count1InitialType='even';
    const [count1Type,setCount1Type]=useState(count1InitialType);
    const [count2,setCount2]=useState(initialCount);
    const count2InitialType='even';
    const [count2Type,setCount2Type]=useState(count2InitialType);

    const IncrementCount1=()=>{
        setCount1(prevstate => {
            console.log(prevstate+1);
            return prevstate+1
        });        
    }

    const IncrementCount2=()=>{
        setCount2(prevstate => {
            console.log(prevstate+1);
            return prevstate+1
        });        
    }

    useEffect(()=>{
        
        document.title=`Count1:${count1}-Count2:${count2}`        
        console.log(`Count1 and Count2 UseEffectCalled,Count1:${count1}-Count2:${count2}`);
    },
    [count1,count2])

    useEffect(()=>{       
        setCount1Type((count1%2)===0 ? 'even':'odd');
        console.log(`Count1 UseEffectCalled after "setCount1 completed"`);
    }
    ,[count1])
    useEffect(()=>{
        console.log(`Count1Type UseEffectCalled after "setCount1Type completed",Count1:${count1}-Count1Type:${count1Type}`);
    },
    [count1Type])

    useEffect(()=>{
        setCount2Type((count2%2)===0 ? 'even':'odd');
        console.log(`Count2 UseEffectCalled after "setCount2 completed"`);
    }
    ,[count2])

    useEffect(()=>{
        console.log(`Count2Type UseEffectCalled after "setCount2Type completed",Count2:${count2}-Count2Type:${count2Type}`);
    },
    [count2Type])
    
    return (
        <div>
         <h1 onClick={IncrementCount1}>Count1:{count1}-{count1Type}</h1>
         <h2 onClick={IncrementCount2}>Count2:{count2}-{count2Type}</h2>
        </div>
        )
}
export default App;