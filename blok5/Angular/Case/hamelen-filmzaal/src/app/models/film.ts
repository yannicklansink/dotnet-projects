export interface Film {
  id: string | null;
  titel: string | null;
  afbeeldingUrl: string | null;
  beschrijving: string | null;
  regisseur: string | null;
  lengte: number | null;
  // plaatsenBeschikbaar: boolean[][];

  releaseDatum: Date | null; // YYYY-MM-DD
  // tijdUitzending: string[] | null;
}
