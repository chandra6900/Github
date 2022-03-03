var Employee={
    id:123,
    name:'scott',
    printDetails(){console.log('id :'+this.id+' name :'+this.name);}
}
Employee.printDetails();

var Car={
    id:009,
    name:'Skoda'
}
var carDetailsFunction=Employee.printDetails.bind(Car);
carDetailsFunction();