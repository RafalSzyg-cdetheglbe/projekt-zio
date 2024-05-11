using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.DbEntities.AuditAndContext;
using WebApi.Models.DbEntities.UserEntities;

namespace WebApi.Models.DbEntities.MeteoEntities
{
    public class MeteoStation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public User? Creator { get; set; }
        [ForeignKey(nameof(CreatorId))]
        public int CreatorId { get; set; }
        public List<MeteoData>? MeteoData { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [ForeignKey(nameof(AuditDataId))]
        public int? AuditDataId { get; set; }
        public BaseAuditData? AuditData { get; set; }
        public MeteoStation() { }
    }
}
