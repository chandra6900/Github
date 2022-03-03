/***************filter function***********/
const ageArray=[14,18,12,15,25,16];
const majors=ageArray.filter((age) => age >= 18);
console.log(majors);
const minors=ageArray.filter((age)=> age<18);
console.log(minors);
/***************filter function***********/

/***************map function***********/
const sampleArray=[1,2,3,4,5];
const squaresOfSampleArray=sampleArray.map((sample) => (sample*sample));
console.log(squaresOfSampleArray);

const ageArray=[14,18,12,15,25,16];
const majorMinorArray=ageArray.map((age) => (age >= 18)); 
console.log(majorMinorArray);
/***************map function***********/