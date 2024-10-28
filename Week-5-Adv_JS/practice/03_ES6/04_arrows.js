// concise way of writing functions. Have a little different behaviour than normal functions.

// 2 ways:

// 1st: using parenthesis.
const mult = (a, b) => {
    console.log(a*b);
};
mult(2,3)

// 2nd: without parenthesis when only 1 expression is present.
const greet = name => console.log(`Hello, ${name}!`);

const add = (a, b) => a + b; // returns a + b

greet("rohanshu")
console.log(add(4, 5));


// Unlike regular functions, arrow functions do not have their own "this" context.
// Instead, they inherit this from the lexical scope.
// Useful in callbacks and event handlers where you want to keep the context of this from the outer function or object.

class Person {
    constructor(name) {
        this.name = name;
    }

    greet() {
        console.log(`Hlo inside instance method "greet" : ${this.name}`);

        setTimeout(() => {
            console.log(`Hello inside set timeout : ${this.name}`);
        }, 0);

        function greet2(){
            console.log(`greeting ${this.name}`);
        }
        // greet2()
    }
}

const person = new Person("Rohanshu");
person.greet();

