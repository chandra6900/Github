
/************************  ES5(2009) Object function defination and member accessing ************************/
//Observe
var Person={
    firstName:'chandra',
    lastName:'R',
    //Observe 
    walk: function(){console.log('walking');},
    talk: function(){console.log('talking');}
    }
Person.firstName;
//Observe
Person.lastName;
Person.walk();
//Observe
Person.talk();
/************************ ES5(2009) Object function defination and member accessing ************************/

/************************  ES6(2015) Object function defination and member accessing ************************/
//Observe
const Person={
    firstName:'chandra',
    lastName:'R',
    //Observe
    walk() {console.log('walking');},
    talk() {console.log('talking');}
    }
Person.firstName;
//Observe
Person["lastName"];
Person.walk();
//Observe
Person['talk']();
/************************ ES6(2015) Object function defination and member accessing ************************/