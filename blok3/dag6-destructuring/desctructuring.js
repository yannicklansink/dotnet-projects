const course = {
	title: 'ES2015 and 2016',
	description: 'New features of ES2015 and 2016',
	editions: [
		{
			trainer: 'Matt Smith',
			dates: {
				start: '01/01/2016',
				end : '05/01/2016'
			},
			location: {
				address1: 'One Way Street',
				city : 'New York'
			}
		},
		{
			dates: {
				start: '03/05/2016',
				end: '08/05/2016'
			},
			location: {
				address1: 'Two Blocks Road',
				address2: '1234 AB',
				city: 'Las Vegas'
			}
		},
		{
			trainer: 'John Doe',
			dates: {
				start: '10/10/2016',
				end : '15/10/2016'
			},
			location: {
				address1: 'One Way Street',
				city : 'New York'
			}
		},
	]
};

// 1.
// Write 4 lines of code which declare and fill 
// 4 variables with data of the first edition. 
// Do not use destructuring yet title, trainer, startDate, city.

    // const title = course.title;
    // const trainer = course.editions[0].trainer;
    // const startDate = course.editions[0].dates.start;
    // const city = course.editions[0].location.city;

    // console.log(title);
    // console.log(trainer);
    // console.log(startDate);
    // console.log(city);

// 2.
// Comment out your code and try to fill the variables
// in one expression using destructuring 

    // const { title } = course;
    // const { editions: [ { trainer } ] } = course;
    // const { editions: [ { dates: {start: startDate} } ] } = course;
    // const { editions: [{location:{city}}] } = course;

    // console.log(title);
    // console.log(trainer);
    // console.log(startDate);
    // console.log(city);

// 3.
// Write a function firstEdition() and copy the logic from the 
// previous step to the body.
function firstEdition(course) {
    const { title } = course;
    const { editions: [ { trainer } ] } = course;
    const { editions: [ { dates: {start: startDate} } ] } = course;
    const { editions: [{location:{city}}] } = course;

    return { title, trainer, startDate, city };
}


 // 4.
// Invoke the function and save the trainer and city properties 
// of the returned object into two variables t and c, using destructuring.
const {trainer: t, city: c} = firstEdition(course);
console.log(t)
console.log(c, "\n")

// 5.
// Print the 4 values to the console
const { title, trainer, startDate: date, city } = firstEdition(course);
console.log(title)
console.log(trainer)
console.log(date)
console.log(city)
console.log(" ")

// notes
function chat() {
    console.log('chatten')
    console.log(this) // <- global
}
chat();

