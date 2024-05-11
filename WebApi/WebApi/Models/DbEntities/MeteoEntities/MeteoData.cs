using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.DbEntities.AuditAndContext;
using WebApi.Models.DTO;

namespace WebApi.Models.DbEntities.MeteoEntities
{
    public class MeteoData
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }
        public string? Unit { get; set; }

        public BaseAuditData? AuditData { get; set; }
        [ForeignKey(nameof(AuditDataId))]
        public int? AuditDataId { get; set; }
        public MeteoStation? MeteoStation { get; set; }
        [ForeignKey(nameof(StationId))]
        public int? StationId { get; set; }

        public MeteoValueType ValueType { get; set; }
        public MeteoDataType DataType { get; set; }

        public MeteoData() { }
        public MeteoData(MeteoDataDTO dto, BaseAuditData auditData)
        {
            Id = dto.Id;
            Name = dto.Name;
            Description = dto.Description;
            Unit = dto.Unit;
            AuditData = auditData;
            DataType = dto.DataType;
            Value = dto.Value;
            ValueType = dto.ValueType;
            StationId = dto.Id;
        }
    }
}
