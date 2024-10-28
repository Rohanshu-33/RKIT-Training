class Car {
    #brand;
    #model;
    
    constructor(brand, model) {
      this.#brand = brand;
      this.#model = model;
    }
    
    start() {
      console.log(`${this.#brand} has ${this.#model} model`);
    }
  }
  
let myCar = new Car("BMW", "M4");
myCar.start();
console.log(myCar.brand); // undefined
// console.log(myCar.#brand); // gives error as it is not accessible outside the class
  