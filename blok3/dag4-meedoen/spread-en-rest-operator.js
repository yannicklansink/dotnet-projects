// function declaration (hoisted)
function telOp(a, b = 3) {
    return a + b;
}

// function expression (not hoisted)
const telOp2 = function(a, b) {
    return a + b;
}

console.log(telOp(1))


// rest argument
function telOp3(...args) {
	return args.reduce((prev, elem) => prev + elem, 0) 
}

console.log(telOp3(1, 2, 3))

let x = '1';
let y = 1;

console.log(x ? 2 : 3);




