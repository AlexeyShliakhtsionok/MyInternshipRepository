// Task_1 Partial Application

// 1 Bind usage ------------------------------------------

// 1.1 Example ( JavaScript built-in alternative)

const normalFunct = (a, b, c, d, f) =>  a * b * c * d * f ;

console.log(normalFunct(1,2,3,4,5)); // 120

const intermediatePartialFunction = normalFunct.bind(null, 3, 4); // Declaring new partial function wich awaiting for remaining parameters

console.log(intermediatePartialFunction); // [Function: bound normalFunct]

const resultPartialFunction = intermediatePartialFunction(1, 2, 5);// Declaring of function that recived remaining parameters and returns the result

console.log(resultPartialFunction); // 120


// 1.2 Example (using "bind" to get function context from object)

var calculator = {
    number: 5,
    getSumm: function(a , b , c)
    { return this.number + a + b + c }
}

var partialSum = calculator.getSumm.bind(calculator, 2, 3);

console.log(partialSum); // [Function: bound getSumm]

var resultSum = partialSum(4);

console.log(resultSum); // 14


// 1.3 Example (function implementation)

const add = (x, y, z, w) => x + y + z + w;

function partialApplication(fn, ...partialArgs) {

    if(typeof fn !== "function"){
        throw new Error("First argument is not a function");
    };

    if (fn.length === partialArgs.length) {
        return fn(...partialArgs);
    } 
    else {

        return function awaitFunc (...awaitingArgs) {
         
            if (fn.length !== awaitingArgs.length + partialArgs.length) {
                partialArgs = partialArgs.concat(awaitingArgs);
                return awaitFunc
            }
            else{
                return fn(...partialArgs, ...awaitingArgs);
            }
        };
    };
};

const sum = partialApplication(normalFunct, 1, 2); // As a result we recieved the function, that awaits for missing parameters
const step_1 = sum(3); // Same result
const step_2 = step_1(4); // Same result
const result_step = step_2(2)  // Evaluation of origin function as the partial function recieved all parameters

console.log(sum);
console.log(step_1);
console.log(step_2);
console.log("The result is: " + result_step);





