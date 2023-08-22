import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: "customNameFormatter"
})
export class CustomPipe implements PipeTransform {
    transform(voornaam: string, achternaam: string): string {
       return voornaam + " " + achternaam;
     }
}