// var declarations :
var a = 4
var b = 5.2
var name = "rohanshu"
console.log("Sum of a and b is : ", a + b)
{
    var c = 6
    var a = 5
    var a = 9
}
console.log("Sum of a, b, and c is : ", a + b + c);

console.log("Value of d is : ", d);
var d = 6

// let declarations :
let i = 7
// let i = 9 --> can't be redeclared
let j = 8
console.log("Sum of i and j is : ", i + j);
{
    // let k = 8
    i = 8
}
console.log("Sum of i and j is : ", i + j);
// console.log(k);   --> this will give error as let is block scoped.

/* console.log(k);
let k = 6    --> this will also give error as we cannot access let variables before their initialization */

// const declarations :
const c1 = 3
// const c1 = 6 --> canot be redeclared
// c1 = 5   --> this line will give error as we cannot assign anything new to a const declared variable.
console.log("Value of c1 is : ", c1);

{
    const c2 = 5   // const also are block scoped
}
const c2 = 4
console.log("Value of c2 is : ", c2);


// var is hoisted during the execution of the js code. Their value remains undefined unless something is assigned.
// let and const are in temporal deadzone until they are initialized thus they remain inaccessible until their initialization.