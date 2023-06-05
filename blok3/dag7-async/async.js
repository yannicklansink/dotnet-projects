

const films = [
    {
        title: 'Harry Potter',
        lengte: 120,
    },
    {
        title: 'Harry Snotter',
        lengte: 130,
    },
    {
        title: 'Harry',
        lengte: 140,
    }
]

// function addFilms() {
    
//     films.forEach(film => {
//         const template = document.getElementById('template').content.cloneNode(true);
//         template.querySelector('.title').innerText = film.title;
//         template.querySelector('.lengte').innerText = film.lengte;
//         document.querySelector('#films').appendChild(template);
//     })

// }

// addFilms();


// const SuperReader = (file) =>  {
//     return new Promise((resolve, reject) => {
//         console.log("superreader uitgevoerd");
    
//         fs.readLine('bestand.txt', 'utf-8', (err, data) => {
//             if (err) {
//                 reject("foutje")
//             }
//             else {
//                 resolve(data);
//             }
//         })
//     })
// }


// async function lees() {
//     const inhoud = await SuperReader('bestand1.txt');
//     console.log(inhoud);
// }

async function haalOp() {
    try {
        const resp = await fetch('https://randomuser.me/api/?gender=female&results=16');
        const data = await resp.json();
        return data.results;
    } catch(err) {
        console.error('foutje', err);
    }
}


function addUser(results) {
    results.forEach(result => {
        const template = document.getElementById('template').content.cloneNode(true);
        template.querySelector('.title').innerText = result.name.first;
        template.querySelector('.image').src = result.picture.large;
        document.querySelector('#films').appendChild(template);
    })

}

// iife functie
// word uitgevoerd door de interperter direct
(async () => {
    const dataResults = await haalOp();
    console.log(dataResults); 
    addUser(dataResults);
})();



