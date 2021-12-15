// 10. Lazy Loading of functions

//10.1 Example (by using JS-implemented bind and apply) https://blog.gypsydave5.com/posts/2015/3/21/basic-lazy-evaluation-and-memoization-in-javascript/

function numbersAdditing(a, b) {
	return a + b;
}

function makeItLazyEvaluated(funct) {
	return funct.bind.apply(funct, arguments);
}

let evaluatedFunction = makeItLazyEvaluated(numbersAdditing, 41, 22);

let result = evaluatedFunction(); // Call by need

// 10.2 Example (Lazy on Function.prototype)
Function.prototype.makeLazyEvaluated = function (funct, context, ...args) {
	return function (...params) {
		const id = Date.now().toString();
		context[id] = funct;
		const result = context[id](...args.concat(params));
		delete context[id];
		return result;
	};
};

// 10.3 Example (function implementation)

function makeTheFunctionLazyAgain(funct, context, ...args) {
	return function (...params) {
		const id = Date.now().toString();
		context[id] = funct;
		const result = context[id](...args.concat(params));
		delete context[id];
		return result;
	};
}

let test = makeTheFunctionLazyAgain(numbersAdditing, numbersAdditing, 55, 2);
let someVariable = test();
console.log(someVariable);
