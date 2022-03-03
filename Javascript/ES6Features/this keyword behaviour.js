/***************************/

function Print(){
    //Observe
    console.log(this);
}

//Observe
Print();

/***************************/

/***************************/

const LaserPrinter={
    print:function(){
        //Observe
        console.log(this);
    }
}

//Observe
LaserPrinter.print();

/***************************/

/***************************/
//Observe
var NormalPrint=Print;
const InkjetPrinter={
        //Observe
        NormalPrint
}

//Observe
InkjetPrinter.print();

 /***************************/

 /***************************/
 var Student={
    name:'chandra',
    className:'Tenth Class',
    subjects:["English","Telugu","Tamil"],
    
    printDetails(){
                    console.log('name : '+this.name);
                    console.log('className : '+this.className);
                    console.log('subjects : '+this.subjects);
                    
                    for (let i=0;i<this.subjects.length;i++)
                    {
                     console.log('For the student:'+this.name+
                                    ' in the class:'+this.className+
                                    ' Subject '+(i+1) +' is '+this.subjects[i]);
                    }
                }
}
/***************************/