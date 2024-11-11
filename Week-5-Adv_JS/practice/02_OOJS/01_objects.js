// JS Objects are a collection of key-value pairs where each key is either property or method.

// const person = {
//     name: "Rohanshu",
//     age: 21,
//     gender: "Male",
//     greet: function(){
//         console.log(`Hello ${this.name}`);
//     }
// }

// console.log(person.age);
// person.greet();

// const p2 =  new Object(person) // shallow copy is being created here so references are copied as it is.
// p2.name = "james bond"
// console.log(person.name);

// const p2 = JSON.parse(JSON.stringify(person))   // deep copy.
// p2.name="james bond"
// console.log(person.name);
// console.log(p2.name);

// keys in object

let obj = {
    "id": 1,
    "name": "abc",
    "hobbies": [1, 2, 3, 4]
}

let obj2 = {}

console.log(Object.keys(obj))
console.log(Object.values(obj))
console.log(Object.entries(obj))


// performs shallow copy:
Object.assign(obj2, obj)
obj2.hobbies[0] = 9

console.log(obj.hobbies)
console.log(obj2.hobbies)


// define a new property

Object.defineProperty(obj, "gender", {
    value: "Male",
    // writable: true,
    enumerable: true,
    // configurable: true
})
console.log(obj);


// modify a property

Object.defineProperty(obj, 'age', {
    value: 25,
    writable: false,
    enumerable: true,
    configurable: true
})

obj.age = 30 // no change happens
console.log(obj.age) // Output: 25


// freezing an object (making immutable)
Object.freeze(obj2)
obj2.name = "aaa"
console.log(obj2);


// object comparison
console.log(Object.is("2", 2));

// object is extensible?
// Object.preventExtensions(obj)   can't add new properties
console.log(Object.isExtensible(obj));

// Seal an object
Object.seal(obj)
delete obj.hobbies
console.log(obj.hobbies);

// Object is sealed? i.e. no addition or deletion of property but modification is possible.
console.log(Object.isSealed(obj));

// toString
const object = {
    "name": "abc",
    "age": 21,
    toString() {
        return `\nName: ${this.name}\nAge:${this.age}`
    }
}
console.log(object.toString())


// create object

// Object.create(prtotypeObject, propertiesObject)

//prototype object:
const car = {
    hasWheels: true
};

const myCar = Object.create(car, {  // defining propertiesObject
    brand: {
        value: 'Toyota',
        writable: false,
        enumerable: true
    },
    year: {
        value: 2021,
        writable: true,
        enumerable: true
    }
});

console.log(myCar.brand)
console.log(myCar.year)
console.log(myCar.hasWheels)