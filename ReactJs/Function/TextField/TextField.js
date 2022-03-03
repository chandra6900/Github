import React,{useState} from 'react';
function TextField(props)
{
    
    const initiallyValid= props.isValid ?? true;
    const intiallyDisabled= props.isDisabled ?? false;
    const initialValue=props.initialValue ?? ''; 
    const validations=props.validations ?? [];
    const requiredMessage=`${props.display} is required`;

    const [isValid,setIsValid]=useState(initiallyValid);
    const [isDisabled,setIsDisabled]= useState(intiallyDisabled);
    const [value,setValue]=useState(initialValue);
    const [ValidationMessage,setValidationMessage]=useState(requiredMessage);

    console.log(isValid);
    const handleOnChange=(e)=>{
        const textValue=e.target.value;
        setValue(textValue);
        
        if(validations.length>0)
        {
            const message=performRequiredValidations(textValue,validations,'One');
            if(message != null && message.length>0)
            {
            setValidationMessage(message);
            setIsValid(false);
            }
            else{
                setValidationMessage('');
                setIsValid(true);
            }
        }
    }

    const performRequiredValidations=(textValue,validations,type)=>
    {
        let validation;
        let message="";
        let validationSummaray=[];
        for(validation of validations)
        {
            switch (validation.name) {
                case "required": {
                    if(textValue== null || textValue === '')
                    {                   
                    message= (validation.message === '' || validation.message == null)  ? requiredMessage : validation.message;
                    if(type==='All' && message.length>0)
                    validationSummaray.push(message);                   
                    }
                    break;
                }                                                  
                case "length": {              
                    let maxMessage='';     
                    let minMessage=''; 

                    if(textValue.length>0 && validation.max != null && validation.max !== '' && textValue.length>validation.max)
                    maxMessage= `must be max of ${validation.max}`;
                    if(textValue.length>0 && validation.min != null && validation.min !== '' && textValue.length<validation.min) 
                    minMessage=`must be min of ${validation.min}`;

                    message= (maxMessage.length>0 && minMessage.length>0) ? `${props.display} ${maxMessage} and ${minMessage} charecters`                     
                    : maxMessage.length>0 ? `${props.display} ${maxMessage} charecters`
                    : minMessage.length>0 ? `${props.display} ${minMessage} charecters`:"";

                    if(type==='All' && message.length>0)
                    validationSummaray.push(message);     
                    break;
                }                                          
                default:
                    message = "";
              }

              if (message.length>0 && type==='One')
              break;
        }

        if(type==='One')
        return message;
        else
        return validationSummaray;
    }

return(   
<div>
<label>
{props.display}:
<input type="text" value={value} onChange={handleOnChange} onBlur={handleOnChange} disabled={isDisabled}/>
</label>
{isValid===false &&
<label>{ValidationMessage}</label>
}
</div>)
}
export default TextField;