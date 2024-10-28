class Calculator {

    constructor(model){
        this.model = model
    }
    
    // Static property
    static PI = 3.14;
    

    // Static method
    static add(a, b) {
        return a + b;
    }

    static disp(){
        console.log(`Name of calc is : ${this.model}`);
    }
    
    disp(){
        console.log(`Name of calc is : ${this.model}`);
    }

    multiply(a, b) {
        return a * b;
    }
}

const calc = new Calculator("casio fs-992")

console.log(Calculator.PI); // gives output

console.log(calc.PI); // undefined

console.log(Calculator.add(5, 3)); // gives output

Calculator.disp(); // undefined

calc.disp(); // gives output

console.log(calc.multiply(5, 3)); // gives output

console.log(calc.add(5, 3)); // error: add is not a function
