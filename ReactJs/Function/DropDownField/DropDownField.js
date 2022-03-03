import React,{useState,useEffect} from 'react';

function DropDownField(props)
{

const handleChange=(e)=>console.log(e);
const initialSource=props.source;
const initialValue=props.initialValue;
const [source,setSource]=useState(initialSource);
const [selected,setSelected]=useState(initialValue);

useEffect(
    ()=>{setSource(initialSource);}
    ,[])

useEffect(
    ()=>{setSelected(selected);}
,[source])    

return(
    <div>
<label>
{props.name}:
<select value={selected} onChange={handleChange}>
    <option value="Select">Select</option>
    </select>
</label>
</div>
)

}
export default DropDownField;