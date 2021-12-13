// Task_4 Linear unfold

// 4.1 Example (function implementation)

function linearUnfold(funct, initialValue) {

    // Check block
    if (typeof funct !== 'function') {
        throw new Error('First argument is not a function');
    }

    let arr = [],
        state = initialValue,
        value;
    while (state !== null) {
        [state, value] = funct(initialValue);
        arr.push(value);
    }
    return arr;
}

function funcWithRandomValue(state) {
    let value = Math.floor(Math.random() * 10);
    if (value >= 9) {
        state = null;
    }
    return [
        state,
        value
    ]
}

let testArr = linearUnfold(funcWithRandomValue, 0);

console.log(testArr);