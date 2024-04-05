using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.DbEntities.AuditAndContext;
using WebApi.Models.DbEntities.MeteoEntities;

namespace WebApi.Models.DTO
{
    public class MeteoDataDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double NumericValue { get; set; }
        public string? StringValue { get; set; }
        public string? Description { get; set; }
        public string? Unit { get; set; }
        public AuditDataDTO? AuditData { get; set; }
        public MeteoDataType DataType { get; set; }

        public MeteoDataDTO(int id, string? name, double numericValue, string? stringValue, string? description, string? unit, AuditDataDTO? auditData, MeteoDataType dataType)
        {
            Id = id;
            Name = name;
            NumericValue = numericValue;
            StringValue = stringValue;
            Description = description;
            Unit = unit;
            AuditData = auditData;
            DataType = dataType;
        }
        public MeteoDataDTO(MeteoData meteoData)
        {
            Id = meteoData.Id;
            Name = meteoData.Name;
            NumericValue = meteoData.NumericValue;
            StringValue = meteoData.StringValue;
            Description = meteoData.Description;
            Unit = meteoData.Unit;
            DataType = meteoData.DataType;
            if (meteoData.AuditData != null)
                AuditData = new AuditDataDTO(meteoData.AuditData);
        }
    }
}
