import React from 'react';
import ReactDOM from 'react-dom';

class App extends React.Component
{
    constructor(props)
    {
       super(props)
       this.state={initialCount:props.initialCount}
       console.log('constructor is Called');
       this.clickHandler=this.handleClick.bind(this);
    }

    updateState(){
        this.setState(
            (prevState,props)=>{return {initialCount:prevState.initialCount+1}}
            )
    }

    updateFiveTimes(){
        console.log('updateFiveTimes is Called');
        
        console.log(this);
        this.updateState();
        this.updateState();
        this.updateState();
        this.updateState();
        this.updateState();
    }
    handleClick()
    {
        this.updateFiveTimes();
    }
    render()
    {
        console.log('render is Called');
        return (
        //doesn't work
        //<h1 onClick={this.updateFiveTimes}>hello {this.state.initialCount}</h1>
        //Not viable
        //<h1 onClick={this.updateFiveTimes.bind(this)}>hello {this.state.initialCount}</h1>
        //Not good
        //<h1 onClick={()=>this.updateFiveTimes()}>hello {this.state.initialCount}</h1>
        //better
        <h1 onClick={this.clickHandler}>hello {this.state.initialCount}</h1>
        );
    }

    componentDidMount()
    {
        console.log('componentDidMount Called');
    }

    componentDidUpdate()
    {
        console.log('componentDidUpdate Called');
    }

    componentWillUnmount()
    {
        console.log('componentWillUnmount Called');
    }
}
export default App;