import React from 'react';
import ReactDOM from 'react-dom';

class App extends React.Component
{
    constructor(props)
    {
       super(props)
       this.state={initialCount:props.initialCount}
       console.log(this.state);
    }

    updateState(){
        this.setState(
            (prevState,props)=>{return {initialCount:prevState.initialCount+1}}
            )
        }
    updateFiveTimes(){
        this.updateState();
        this.updateState();
        this.updateState();
        this.updateState();
        this.updateState();
    }
    render()
    {
        return (<h1 onClick={()=>this.updateFiveTimes()}>hello {this.state.initialCount}</h1>);
    }
}
export default App;