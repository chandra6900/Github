import React from 'react';
import ReactDOM from 'react-dom';

class App extends React.Component{

constructor(props)
{
    super(props);
    console.log('App constructor');
}

componentDidMount()
{
    console.log('App componentDidMount');

}

componentDidUpdate()
{
    console.log('App componentDidUpdate');
}

render()
{
    console.log('App render');
    return (<div>
        <button>App Component Count</button>
        </div>);
}

componentWillUnmount()
{
    console.log('App componentWillUnmount');
}

}

export default App;