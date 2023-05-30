console.log("d" * 2);
console.log("20" == 20);
console.log(Number('20') + 18); // 38

let undefinedvalue = undefined;

console.log(Number(undefinedvalue))

// object literal
const auto = {
    brand: 'Opel',
    length: 2.5,
    toString: function() {
        return `Brand: ${this.brand}, Length: ${this.length}`
    },
    valueOf: function() {
        return this.length;
    }
}

const garageLengte = 5;
console.log(garageLengte - auto);
