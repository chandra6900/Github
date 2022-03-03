/************************ Array ************************/
var cars=["Maruthi","Tayota","Skoda"];
var bikes=["Hero","Honda","Tvs"];
//Observe
var vehicles = [...cars,...bikes];
console.log(vehicles);
/************************ Array ************************/

/************************ Objects ************************/
var Person={name:'chandra',walk(){console.log('walking');},talk(){console.log('talking');}};
var Teacher={ className:'Tenth Class',teach(){console.log('teaching');}};
//Observe
var TeachingPerson = {...Person,...Teacher};
console.log(TeachingPerson);
/************************ Objects ************************/