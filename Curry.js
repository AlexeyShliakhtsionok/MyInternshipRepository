// Task_2 Curried Application

// 2.1 Example (function implementation)

const addOperation = (x, y, z, w) => x + y + z + w;

function curry(fn = required()) {
    if (typeof fn !== "function") {
        throw new Error("First argument is not a function");
    }
    let length = fn.length;
    return function curriedFunct(currentArg, i = 1, args = []) {
        const allArgs = [...args, currentArg];
        return i === length ? fn(...allArgs) : nextArg => curriedFunct(nextArg, i + 1, allArgs);
    };
}

let newCurriedFunc = curry(addOperation);
console.log(newCurriedFunc);

let step__1 = newCurriedFunc(3);
console.log(step__1);

let result__step = step__1(2)(5)(8) ;
console.log(result__step);


// 2.2 ( JavaScript built-in alternative)


let curryJS = curry(addOperation);
console.log(curryJS);

let stp_1 = curryJS(5);
console.log(stp_1);

let rslt_stp = stp_1(10, 100000)(2)(3); //for note: the second argument which equals to 100000 were ignored
console.log(rslt_stp);




