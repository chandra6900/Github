/***************Normal******************/ 
var Print=
//Observe
function()
{ 
    console.log("hello"); 
}
//Calling
Print();
/***************Normal******************/ 

/***************Normal with Parameter******************/ 
var PrintSum=
//Observe
function(a,b)
{ 
    console.log("sum:"+(a+b)); 
}
//Calling
PrintSum(2,3);
/***************Normal with Parameter******************/ 

/***************Arrow******************/ 
var ArrowPrint=
//Observe
()=>
{
    console.log("hello");
}
//Calling
ArrowPrint();
/***************Arrow******************/ 


/***************Arrow with Parameter******************/ 
var ArrowPrintSum=
//Observe
(a,b)=>
{
    console.log("sum:"+(a+b));
}
//Calling
ArrowPrint(2,3);
/***************Arrow with Parameter******************/ 
