namespace WebApi.Models.DbEntities.MeteoEntities
{
    public enum MeteoDataType
    {
        Temperature = 0,
        Humidity = 1,
        WindSpeed = 2,
        AtmosphericPressure = 3,
        Rainfall = 4,
    }

    public enum MeteoValueType
    {
        String = 0,
        Double = 1,
        Integer = 2,
        Boolean = 3,
    }
}
