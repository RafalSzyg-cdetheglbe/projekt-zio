import { MeteoDataDTO } from "./MeteoDataDto";
import { UserResponseDTO } from "./UserResponseDto";

export interface MeteoStationDTO {
    id: number;
    name: string | null;
    creator: UserResponseDTO | null;
    meteoData: MeteoDataDTO[] | null;
    latitude: number;
    longitude: number;
}