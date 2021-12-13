
function linearUnfold(func, initialValue) {
    if (typeof func !== 'function') {
        throw new Error('First argument is not a function');
    }

    let arr = [],
        state = initialValue,
        value;
    while (state !== null) {
        [state, value] = func(initialValue);
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