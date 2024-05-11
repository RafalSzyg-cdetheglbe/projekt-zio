import { AuditDataDTO } from "./AuditDataDto";

export interface MeteoDataDTO {
    id: number;
    name: string | null;
    description: string | null;
    unit: string | null;
    auditData: AuditDataDTO | null;
    dataType: MeteoDataType;
    value: string | null;
    valueType: MeteoValueType;
}

export enum MeteoDataType {
    Temperature = 0,
    Humidity = 1,
    WindSpeed = 2,
    AtmosphericPressure = 3,
    Rainfall = 4
}

export enum MeteoValueType {
    String = 0,
    Double = 1,
    Integer = 2,
    Boolean = 3
}