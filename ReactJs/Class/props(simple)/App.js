import React from 'react';
import ReactDOM from 'react-dom';

class  App extends React.Component
{
    constructor(props)
    {
    
     super();
     this.name=props.name;
     console.log(props);
     console.log(this);
    }

    render()
    {

        if(this.name===undefined)
        return 'Hello';
        else
        return 'Hello '+this.name;
    }
}

export default App;