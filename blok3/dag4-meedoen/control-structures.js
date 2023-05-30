'use strict'

const person = { name: "yannick", age: 26, city: "Veenendaal"}

for (const value of Object.values(person)) {
    console.log(value);
}

// Dit kan niet met 'use strict' mode.
// x = 5;
// console.log(x);

let arraytje = ['add', 'noot', 'mies']
// map
// foreach

// arraytje.forEach(function (elem) {
//     console.log(elem.toUpperCase())
// });

// arraytje = arraytje.map(function(elem) {
//     return elem
//         .substring(1, 4)
//         .toUpperCase();
// })

// arrow function (c# lambda expressie)
arraytje = arraytje.filter(elem => elem === 'noot' || elem === 'add')
                   .map((elem) => elem
                   .substring(1, 4)
                   .toUpperCase());

// arraytje = arraytje.map((elem) => elem.substring(1, 4).toUpperCase());


for (const value of arraytje) {
    console.log(value);
}







