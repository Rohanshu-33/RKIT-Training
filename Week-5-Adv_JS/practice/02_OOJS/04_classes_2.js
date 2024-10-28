// the below behaves same as class. the class keyword is just a syntactic sugar on the functions( or we can say objects as everything is object in js)

function Person(name, age){
    this.name = name
    this.age = age
}

Person.prototype.greet = function(){
    console.log(`Hello ${this.name}`);
}

const p1 = new Person("rohanshu", 21)
const p2 = new Person("bob", 23)
console.log(p1.name);
p1.greet();