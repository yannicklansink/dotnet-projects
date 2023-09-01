export interface Reservatie {
  id: string;
  voornaam: string;
  email: string;
  straatnaam: string | null;
  woonplaats: string | null;
  hoeveelheid: number;
  playtimeId: string;
}
