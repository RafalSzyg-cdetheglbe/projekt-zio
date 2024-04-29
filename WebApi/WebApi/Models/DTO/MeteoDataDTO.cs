using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.DbEntities.AuditAndContext;
using WebApi.Models.DbEntities.MeteoEntities;

namespace WebApi.Models.DTO
{
    public class MeteoDataDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Unit { get; set; }
        public AuditDataDTO? AuditData { get; set; }
        public MeteoDataType DataType { get; set; }
        public string? Value { get; set; }
        public MeteoValueType ValueType { get; set; }

        public MeteoDataDTO(int id, string? name, string? value, MeteoValueType valueType, string? description, string? unit, AuditDataDTO? auditData, MeteoDataType dataType)
        {
            Id = id;
            Name = name;
            Value = value;
            ValueType = valueType;
            Description = description;
            Unit = unit;
            AuditData = auditData;
            DataType = dataType;
        }
        public MeteoDataDTO(MeteoData meteoData)
        {
            Id = meteoData.Id;
            Name = meteoData.Name;
            Value = meteoData.Value;
            ValueType = meteoData.ValueType;
            Description = meteoData.Description;
            Unit = meteoData.Unit;
            DataType = meteoData.DataType;
            if (meteoData.AuditData != null)
                AuditData = new AuditDataDTO(meteoData.AuditData);
        }
    }
}
