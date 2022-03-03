/*************Objects**************/
/*************Conventional**************/
var Person={firstName:'chandra',lastName:'R',email:'chandra6900@gmail.com'}
//Observe
console.log(Person.firstName);
console.log(Person.lastName);
console.log(Person.email);
/*************Conventional**************/

/*************Using Destructuring**************/
var Person={firstName:'chandra',lastName:'R',email:'chandra6900@gmail.com'}
//Observe
const {firstName,lastName,email:contact} = Person;
//Observe
console.log(firstName);
console.log(lastName);
//Observe
console.log(contact);
/*************Using Destructuring**************/
/*************Objects**************/

/*************Arrays**************/
/*************Conventional**************/
var Student=['chandra','Tenth Class','chandra6900@gmail.com']
//Observe
console.log(Student[0]);
console.log(Student[1]);
console.log(Student[2]);
/*************Conventional**************/

/*************Using Destructuring**************/
var Student=['chandra','Tenth Class','chandra6900@gmail.com']
//Observe
const [fullName,className,email] = Student;
//Observe
console.log(fullName);
console.log(className);
//Observe
console.log(email);
/*************Using Destructuring**************/
/*************Arrays**************/