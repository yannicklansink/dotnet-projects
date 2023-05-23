

// const form = document.querySelector('form');

// form.addEventListener('submit', (event) => {
//     event.preventDefault(); // voorkom standaard gedrag van versturen.
//     const bsn = document.querySelector('#bsn');

//     const bsnWaarde = bsn.value;
//     console.log(bsnWaarde);
    
//     const labelText = document.querySelector('label');
//     console.log(labelText.innerText);

//     const identificatie = document.querySelector('#identificatie');
//     console.log(identificatie.value);
// });



const input = document.getElementById('identificatie');
const datalist = document.getElementById('identificaties');
const bsnWaarde = document.querySelector('#bsn');

input.addEventListener('input', () => {
  const inputValue = input.value;
  const options = Array.from(datalist.options).map(option => option.value);

  if (!options.includes(inputValue)) {
    input.setCustomValidity('Please select a valid identification option.');
  } else {
    input.setCustomValidity('');

    setValues(bsnWaarde, inputValue);
    
    const saveToStorage = {
      bsn: bsnWaarde.value,
      identificatie: inputValue
    };
    
    localStorage.setItem('userData', JSON.stringify(saveToStorage));
  }
});

const userStorage = document.getElementById('wisBrowser');
userStorage.addEventListener('click', () => {
  localStorage.clear();
});

fetch('https://randomuser.me/api')
  .then(response => response.json())
  .then(data => {
    // Process the JSON data
    console.log(data);
    console.log(data.results[0].email);
  })
  .catch(error => {
    // Handle any errors
    console.error('Error:', error);
  });


