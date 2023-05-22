
const currentYear = new Date().getFullYear();
document.getElementById("currentYear").textContent = currentYear;

// also possible solution for above:
// let yearSpan = document.querySelector('#copyright-year');
// let currentDate = new Date();
// yearSpan.innerText = currentDate.getFullYear();


function addTrip() {
    let template = document.querySelector('#trip-template').content;
    let clone = document.importNode(template, true);

    clone.querySelector('.city').innerText = 'Amsterdam';
    clone.querySelector('.date').innerText = '4/8/2014';
    clone.querySelector('.review').innerText = 'Amsterdam culture is great. A true taste of what Holland is like.';
    clone.querySelector('.rating').innerText = '8';

    document.querySelector('#trips').appendChild(clone);
}
