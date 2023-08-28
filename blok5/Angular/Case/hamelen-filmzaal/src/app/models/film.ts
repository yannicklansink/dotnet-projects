export interface Film {
    id: string | null;
    titel: string | null;
    afbeeldingUrl: string | null;
    beschrijving: string | null;
    regisseur: string | null;
    lengte: number | null; // format needs to be 85 min. JSON file will have '1h 22 min'. Create a pipe that converts this.

    releaseDatum: Date | null; // YYYY-MM-DD
    tijdUitzending: string[] | null;
    datumUitzending: Date | null;
}