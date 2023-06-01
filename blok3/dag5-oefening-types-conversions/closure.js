function outerFunction(a) {
    return {
        id: a,
    }
}

const result = outerFunction(42);
console.log(result)