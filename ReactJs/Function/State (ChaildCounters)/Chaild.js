import React,{useState} from 'react';
import ReactDOM from 'react-dom';

function Chaild(props)
{
    const compName= props.compName ?? '';
    const chaildInitialCount= props.initialCount ?? 0;
    const stepValue= props.stepValue ?? 1;
    
    
    let arrayValues=useState(chaildInitialCount);
    const [chaildCount,setChaildCount]=arrayValues;
    const increaseCount= () => {
            if(stepValue<=5)
                setChaildCount(chaildCount+stepValue);
            else
            {
                for(let i=0;i<stepValue;i++)
                {
                    //Thinking that every iteration 'chaildCount increments by 1' 
                    //This won't produce expected result
                    setChaildCount(chaildCount+1);
                }
            }
        };

    console.log('I am from ' + compName + ' component');
    return(
        <div>
        <h2>{compName} Count:{chaildCount}</h2>
        <button onClick={increaseCount}>{compName} button</button>
        </div>
    );
}
export default Chaild;