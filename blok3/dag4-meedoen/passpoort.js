
const passpoort = {
    id: 1,
    bsn: 12312323,
    afgiteplaats: 'Oldenzaal',
    toString: function() {
        return `id: ${this.id} en bsn: ${this.bsn} en afgifteplaats: ${this.afgiteplaats}`
    },
    valueOf: function() {
        return this.bsn;
    },
}

console.log(Number(passpoort));
console.log(String(passpoort));

console.log(typeof passpoort.bsn) // number
console.log(typeof passpoort.afgiteplaats) // string
console.log(typeof passpoort); // object

console.log(passpoort.id++) // 1
console.log(++passpoort.id) // 3

passpoort.afgifteDatum = new Date(); // datum van vandaag
passpoort['afgifteDatum'] = '2002'

console.log(passpoort.afgifteDatum) // 2002

class Viool {

    aantalSnaren;

    constructor(aantalSnaren) {
        this.aantalSnaren = aantalSnaren;
    }

}
// Zelfde als het schrijven van een class. Syntax van vroeger.
// function Viool(aantalSnaren) {
//     this.aantalSnaren = aantalSnaren;
// }

const viool1 = new Viool(3);
console.log(viool1 instanceof Viool); // true
console.log(viool1 instanceof Object); // true

console.log(typeof Viool); // function. Dus een class is een function

console.log(Array.isArray(viool1)); // false

for (const prop in passpoort) {
    console.log(prop, passpoort[prop]);
}

console.log(passpoort.bsn);
delete passpoort.bsn;

console.log("--------------------")
for (const prop in passpoort) {
    console.log(prop, passpoort[prop]);
}

// const afgiftedatumopgevraagd = 'afgifteDatum' in passpoort ? passpoort.afgifteDatum :  'Not available';
const afgiftedatumopgevraagd = passpoort?.afgifteDatum ?? 'n/a';

const afgeifteplaats3 = passpoort.afgiteplaats ||= 'Bussum';
















