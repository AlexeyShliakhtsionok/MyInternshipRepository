function func_name () {
	var variable_foo,
		variable_bar;

	variable_foo = get_foo();
	variable_bar = get_bar();
	func_name = function () {
		return variable_foo + variable_bar;
	};
	return func_name.apply(this, arguments);
}





// function lazyEvaluation(func, delay) {
//     if (typeof func !== 'function') {
//         throw new Error('First argument is not a function');
//     }
//     if (!Number.isInteger(delay)) {
//         throw new Error('Second argument is not a number');
//     }
//     return (...cfArgs) => {
//         setTimeout(() => {
//             func(...cfArgs)
//         }, delay);
//     }
// }

function someLazyActionsWithArray(...args){
    console.log(args);
    return (...args) =>{func(...args)};
} //???



let test = someLazyActionsWithArray( 1, 2, 3, 4, 5, 6, 7, 8, 9 );
console.log(test);


function getDoubledFirstN(num){

}