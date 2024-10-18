// JS Objects are a collection of key-value pairs where each key is either property or method.

const person = {
    name: "Rohanshu",
    age: 21,
    gender: "Male",
    greet: function(){
        console.log(`Hello ${this.name}`);
    }
}

console.log(person.age);
person.greet();

// const p2 =  new Object(person) // shallow copy is being created here so references are copied as it is.
// p2.name = "james bond"
// console.log(person.name);

const p2 = JSON.parse(JSON.stringify(person))   // deep copy.
p2.name="james bond"
console.log(person.name);
console.log(p2.name);