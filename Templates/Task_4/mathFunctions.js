const addition = (a, b) => {
    return Number(a) + Number(b);
}

const subtraction = (a, b) => {
    return Number(a) - Number(b)
}

const multiplication = (a, b) => {
    return Number(a) * Number(b)
}

const division = (a, b) => {
    return Number(a) / Number(b)
}

const generateKey = args => (args.map(x => `${x.toString()}`).join("|"));

const memoize = fn => {
    const cache = {};
    let result = [];
    return (...args) => {
        const key = generateKey(args);
        const cacheValue = cache[key];
        if (cacheValue) {
            result = [];
            result.push(cacheValue);
            result.push(`- operation: ${fn.name} with values: ${key}`);
            return result;
        }else{
            result = [];
            const computation = fn(...args);
            cache[key] = computation;
            result.push(computation);
            return result;
        }
    };
};

const mAddition = memoize(addition);
const mSubtraction = memoize(subtraction);
const mMultiplication = memoize(multiplication);
const mDivision = memoize(division);