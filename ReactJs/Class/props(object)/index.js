import React from 'react';
import ReactDOM from 'react-dom';
import App from './App.js';

const Student={name:'chandra',className:'Tenth Class',subjects:['English','Telugu']};
ReactDOM.render(<App Student={Student} />,document.getElementById('root'));
