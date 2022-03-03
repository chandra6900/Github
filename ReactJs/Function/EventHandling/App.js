import React from 'react';
import ReactDOM from 'react-dom';

function App()
{

function jingJong(msg){ alert(msg); }
function tingTong(){ alert('ting tong clicked'); }

const lingLong= function() { alert('ling long clicked');}
const ringRong= () => alert('ring rong clicked');
const pingpong= e => {alert('ping pong clicked');console.log('ping pong clicked'); console.log(e);}

const hingHong=function(e) { alert('hing hong clicked');console.log('hing hong clicked');console.log(e);}
const ningNong= e => { alert('ning nong clicked');console.log('ning nong clicked');console.log(e);}
const suggestedWay= (e,name) => { alert(name+' suggested way clicked');console.log(name+' suggested way clicked');console.log(e);}
return(
    <div>
        
        <h1>Event Demo</h1>

        {/* Calling pre defind function - executes at onload */}
        <button onClick={alert('ding dong clicked')}>ding dong</button>
        {/* Calling Classic user defind function with arguments - executes at onload */}
        <button onClick={jingJong('jing jong clicked')}>jing jong</button>


        {/* Attatching Classic inline function definition without arguments */}
        <button onClick={function(){alert('bing bong clicked');}}>bing bong</button>
        {/* Attatching Arrow inline function definition without arguments */}
        <button onClick={()=>alert('ming mong clicked')}>ming mong</button>

        {/* Attatching Classic inline function definition with arguments*/}
        <button onClick={function(e){alert('king kong clicked');console.log('king kong clicked'); console.log(e)}}>bing bong</button>   
        {/*
        Attatching Arrow inline function definition with arguments
                e => pingpong(e)
                converts to ... 
                function(e){pingpong(e)}
        */}
        <button onClick={e => pingpong(e)}>ping pong</button>

        {/* Attatching Classic user defind function without arguments */}
        <button onClick={tingTong}>ting tong</button>  
        {/* Attatching Const type Classic user defind function without arguments */} 
        <button onClick={lingLong}>ling long</button>
        {/* Attatching Const type Arrow user defind function without arguments */}
        <button onClick={ringRong}>ring rong</button>

        {/* Attatching Const type Classic user defind function with default argument e */}
        <button onClick={hingHong}>hing hong</button>
        {/* Attatching Const type Arrow user defind function with default argument e */}
        <button onClick={ningNong}>ning nong</button>

        {/********* Suggested way ********/}
        <button onClick={e => {suggestedWay(e,'Chandra');}}>Suggested way</button>
    </div>
);

}
export default App;