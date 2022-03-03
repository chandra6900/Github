/************************  var ************************/
//Scope
function varKeyword(){
    for(var i=0;i<5;i++)
    {
    //Observe
    console.log(i);
    }
    //Observe
    console.log('var Value is Accessable out side for block: '+i);
    }

    //Call function to see
    varKeyword();

/************************  var ************************/

/************************  let ************************/
//Scope
function letKeyword(){
    for(let j=0;j<5;j++)
    {
    //Observe
    console.log(j);
    }
    //Observe
    console.log('let Value is not Accessable out side for block: '+j);
    }

    //Call function to see
    letKeyword();

/************************  let ************************/

/************************  const ************************/

//Assignment

const a=10;
console.log(a);
a=20; //Error 

//Scope
function constKeyword(){
    if(true){
    const k=10;
    //Observe
    console.log(k);
    }
    //Observe
    console.log('const Value is not Accessable out side if block: '+k);
    }
/************************  const ************************/