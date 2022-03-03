import React from 'react';
import TextField from './TextField.js';
import DropDownField from './DropDownField.js';
import RadioButtonGroupField from './RadioButtonGroupField.js';

function FormField(props)
{

    const handleSubmit=(e)=>e.preventDefault();
    return (
        <form onSubmit={handleSubmit}>

        <TextField name='FirstName' display='First Name' enabled='true' type='text' accepts='alphabetic' 
        allowed={[]} notAllowed={[]} initialValue='' validations={[{'name':'required','message':''},
        {'name':'length','max':10,'min':5}]}/>

        <TextField name='DOB' display='Last Name' enabled='true' type='text' accepts='date' 
        allowed={['dd/mm/yyyy','dd-mm-yyyy']} notAllowed='' 
        initialValue='15/06/1992' validations={[{'name':'required','message':''}]} />

        <TextField name='Email' display='Email' enabled='true' type='text' accepts='email' 
        allowed={[]} notAllowed={[]} initialValue='' validations={[{'name':'required','message':''},
         {'name':'length','max':'100','min':'6'},{'name':'custom','method':'validateEmail'}]} />

        <RadioButtonGroupField name='Gender' display='Gender' enabled='true' 
        source={[{id:'1',value:'male', display:'Male'},{id:'2',value:'female', display:'Female'}]} 
        initialValue='male' 
        validations={[{'name':'required','message':''}]} />

        <DropDownField name='Country' display='Country' enabled='true' 
        source={[{id:'1',value:'india', display:'India'},{id:'2',value:'usa', display:'USA'}]} 
        initialValue='Select' 
        validations={[{'name':'required','message':''}]}/>

        <div>
            <input type="submit" value="Submit" />
            <input type="button" value="Clear" />
        </div>
        </form>   
        )
}
export default FormField;