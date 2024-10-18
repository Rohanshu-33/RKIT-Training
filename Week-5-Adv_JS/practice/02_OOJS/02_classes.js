class Person{
    constructor(name, age, gender){
        this.name = name
        this.age = age
        this.gender = gender
    }
    greet(){
        console.log(`Hello ${this.name}`);
    }
}


const p1 = new Person("Rohanshu", 21, "Male")
const p2 = new Person("Alice", 21, "Female")  // without new keyword, we cannot create instance of Person class as constructor is defined.
p1.greet()
p2.greet()