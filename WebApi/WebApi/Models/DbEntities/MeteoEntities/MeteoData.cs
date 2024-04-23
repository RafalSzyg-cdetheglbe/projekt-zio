﻿using System.ComponentModel.DataAnnotations;
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
        public double NumericValue { get; set; }
        public string? StringValue { get; set; }
        public string? Description { get; set; }
        public string? Unit { get; set; }
        public BaseAuditData? AuditData { get; set; }
        [ForeignKey(nameof(AuditDataId))]
        public int? AuditDataId { get; set; }
        public MeteoDataType DataType { get; set; }

        public MeteoData(MeteoDataDTO dto, BaseAuditData auditData)
        {
            Id = dto.Id;
            Name = dto.Name;
            NumericValue = dto.NumericValue;
            StringValue = dto.StringValue;
            Description = dto.Description;
            Unit = dto.Unit;
            AuditData = auditData;
            DataType = dto.DataType;
        }
    }
}