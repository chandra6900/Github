import React from 'react';
import TextField from './TextField.js';

function FormField(props)
{

    const handleSubmit=(e)=>e.preventDefault();
    return (
        <form onSubmit={handleSubmit}>

        <TextField name='FirstName' display='First Name' enabled='true' type='text' accepts='alphabetic' 
        allowed={[]} notAllowed={[]} initialValue='' validations={[{'name':'required','message':''},
        {'name':'length','max':10,'min':5}]}/>
        
        <div>
            <input type="submit" value="Submit" />
            <input type="button" value="Clear" />
        </div>
        </form>   
        )
}
export default FormField;