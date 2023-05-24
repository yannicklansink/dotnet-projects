const monitors = ['samsung', 'lg', 'oled hp']
monitors.push('chinese knockoff');
const monitor = monitors.pop();
console.log(monitors);


monitors.forEach((monitor) => {
    console.log(monitor);
});