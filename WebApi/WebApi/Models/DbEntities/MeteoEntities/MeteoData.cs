using System.ComponentModel.DataAnnotations;
using WebApi.Models.DbEntities.AuditAndContext;

namespace WebApi.Models.DbEntities.MeteoEntities
{
    public class MeteoData
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double NumericValue { get; set; }
        public string StringValue { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public BaseAuditData AuditData { get; set; }
    }
}
