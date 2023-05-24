console.log("-----")

const startScript = document.querySelector('#startScript')
startScript.innerHTML = 'Het script start';

let medewerker = { naam: 'John', title: 'CEO', intern: true }

const employeeInfoElement = document.querySelector('#employee')

medewerker.status = 'actief'

employeeInfoElement.innerHTML = "Naam: " + medewerker.naam + "<br>" +
                                "Title: " + medewerker.title + "<br>" +
                                "Actief: " + medewerker.status;

// `${medewerker.naam}\n${medewerker.title} is net in dienst`
employeeInfoElement.innerText = `${medewerker.naam}, ${medewerker.title} 
                                    is momenteel ${medewerker.status}
                                    ${medewerker.intern ? 'interne medeweker' : 'gast'}
                                `;

medewerker.leeftijd = 10;
if (medewerker.leeftijd) {
    employeeInfoElement.innerHTML += "Leeftijd: " + medewerker.leeftijd;
} else {
    employeeInfoElement.innerHTML += "Leeftijd: Not available";
}

for (const prop in medewerker) {
    console.log(prop + " " + medewerker[prop]);
}

for (const entry of Object.entries(medewerker)) {
    console.log(entry);
    /*
        ['naam', 'John']
        ['title', 'CEO']
        ['intern', true]
        ['status', 'actief']
        ['leeftijd', 10]
    */
}

// monitors.forEach((medewerker) => {
//     console.log(medewerker);
// });



