import React from 'react';
import ReactDOM from 'react-dom';

class App extends React.Component{
constructor(props){
    super(props);
    
}

render()
{
    if(this.props.Student===undefined)
    return <h1>Student data not found</h1>;
    else
    return (
        <div>
        <h2>Name:</h2><h1>{this.props.Student.name}</h1>
        <br/>
        <h2>class Name:</h2><h1>{this.props.Student.className}</h1>
        <br/>
        <h2>Subjects:</h2><h1>{this.props.Student.subjects.join(',')}</h1>
        </div>
            );

        //This don't work
        //return '<h1>'+props.Student.name+'</h1>'+'<br/>'+'<h3>ClassName: '+props.Student.className+'</h3>'
        //+'<br/>'+'<h3>Subjects: '+props.Student.subjects.join(',')+'</h3>';

}

}
export default App;