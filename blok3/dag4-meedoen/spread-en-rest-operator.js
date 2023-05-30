// function declaration (hoisted)
function telOp(a, b = 3) {
    return a + b;
}

// function expression (not hoisted)
const telOp2 = function(a, b) {
    return a + b;
}

console.log(telOp(1))

function telOp3(...args) {
	return args.reduce((prev, elem) => prev + elem, 0) 
}

console.log(telOp3(1, 2, 3))




