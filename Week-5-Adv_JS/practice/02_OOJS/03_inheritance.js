class Animal{
    constructor(name){
        this.name = name
    }
    display(){
        console.log(`Name of animal is : ${this.name}`);
    }
}

class Dog extends Animal{
    constructor(name, legs, sound){
        super(name);
        this.legs = legs
        this.sound = sound
    }
    display(){
        super.display()
        console.log(`${this.name} has ${this.legs} legs and make a ${this.sound} sound`);
    }
}

const d1 = new Dog("Golden Retriever", 4, "Bark")
d1.display()

// what is prototypal inheritance