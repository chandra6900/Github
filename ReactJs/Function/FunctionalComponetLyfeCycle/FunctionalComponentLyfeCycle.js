import React,{useState,useEffect} from 'react';

function FunctionalComponetLyfeCycle()
{
    const primaryCountries=[{value:'IN',text:'India'},{value:'US',text:'United States of America'}];
    const[countries,setCountries]=useState(primaryCountries);
    const[neighbourCountries,setNeighbourCountries]=useState([]);
    const url='https://restcountries.eu/rest/v2/all';
    //Only fires once as no arguments given
    useEffect(
        ()=>{
            console.log('useEffectCalled');
            //oncomponenet mount
            fetchData(url,'','UpdateCountries','');               
        }
    ,[])
    const UpdateCountries=(countries)=>
    {
        let fetchedCountries=countries.map((country)=>({value:country.alpha2Code,text:country.name}));
        setCountries(fetchedCountries);    
    }
    const fetchData=(url,data,SuccessCallback,ErrorCallback)=>{
        fetch(url)
        .then(res =>{
            console.log(res);
            return res.json()
        })
        .then(
            (result)=>{
                console.log('result Came');
                [SuccessCallback](result);
            }
        )
    }

    return(
        <div>
            <label>countries</label>
            <select width='500'>
                <option value='Select'>Select</option>
                {
                    countries.map((country)=>{return <option value={country.value}>{country.text}</option>})
                }
            </select>
            <button onClick={fetchData}>UpdateCountries</button>
        </div>
    )
}
export default FunctionalComponetLyfeCycle;