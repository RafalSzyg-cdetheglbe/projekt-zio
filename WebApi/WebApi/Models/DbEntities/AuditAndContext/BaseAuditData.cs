using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DbEntities.AuditAndContext
{
    public class BaseAuditData
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
