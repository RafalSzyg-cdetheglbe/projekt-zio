export interface MeteoData {
    id: number;
    name: string;
    latitude: number;
    longitude: number;
    Temperature: string | null;
    Humidity: string | null;
    WindSpeed: string | null;
    AtmosphericPressure: string | null;
    Rainfall: string | null;
}