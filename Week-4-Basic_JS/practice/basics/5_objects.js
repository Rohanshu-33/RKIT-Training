const object = {
    name: "Rohanshu",
    age: 21,
    email: "abc@gmail.com"
}


console.log(object);
console.log(object.name);

object.email = "xyz@gmail.com"
console.log(object['email']);

const obj2 = object   // shallow copy

obj2.age = 23
console.log(obj2);
console.log(object);

const obj3 = JSON.parse(JSON.stringify(object))   // deep copy
obj3.name = "Meet"
obj3.age = 22
console.log(obj3);
console.log(object);
