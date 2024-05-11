using System.ComponentModel;

namespace WebApi.Models.DbEntities.MeteoEntities
{
    public enum MeteoDataType
    {
        [Description("Temperature")]
        Temperature = 0,
        [Description("Humidity")]
        Humidity = 1,
        [Description("Wind speed")]
        WindSpeed = 2,
        [Description("Atmospheric pressure")]
        AtmosphericPressure = 3,
        [Description("Rainfall")]
        Rainfall = 4,
    }

    public enum MeteoValueType
    {
        [Description("Text")]
        String = 0,
        [Description("Floating point value")]
        Double = 1,
        [Description("Integer")]
        Integer = 2,
        [Description("True / false")]
        Boolean = 3,
    }
}
