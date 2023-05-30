let logTekst = 'bestanden: aaa.mp3, bbb.mp3, ccc.txt en ddd.mp3';
let regex = /\b\w+\.mp3\b/g;
let regexfilled = logTekst.match(regex);

//De regular expression \b\w+\.mp3\b zoekt naar alle woorden (bestandsnamen) die eindigen op '.mp3'. 
// De \b aan het begin en einde van de regex zorgt ervoor dat alleen hele woorden worden gematcht (dus bijvoorbeeld niet 'aaa.mp4.mp3'). 
// De \w+ matcht één of meer woord karakters (equivalent aan [a-zA-Z0-9_]). De \.mp3 matcht de string '.mp3'. 
// De g aan het einde van de regex zorgt ervoor dat alle voorkomens in de string worden gevonden, niet alleen de eerste.

console.log(regexfilled); // Outputs: ['aaa.mp3', 'bbb.mp3', 'ddd.mp3']
