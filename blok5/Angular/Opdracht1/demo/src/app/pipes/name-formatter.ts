import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: "customNameFormatter"
})
export class CustomPipe implements PipeTransform {
    transform(voornaam: string | null, achternaam: string | null): string {
        if (voornaam === null || achternaam === null) {
            return "";
        }
       return voornaam + " " + achternaam;
     }
}