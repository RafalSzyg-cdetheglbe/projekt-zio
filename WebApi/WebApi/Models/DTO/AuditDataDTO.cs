using WebApi.Models.DbEntities.AuditAndContext;
using WebApi.Models.DbEntities.UserEntities;

namespace WebApi.Models.DTO
{
    public class AuditDataDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; } //dla usera

        public AuditDataDTO(int id, DateTime createdAt, DateTime updatedAt, DateTime? lastLoginAt)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            LastLoginAt = lastLoginAt;
        }

        public AuditDataDTO(BaseAuditData auditData)
        {
            Id = auditData.Id;
            CreatedAt = auditData.CreatedAt;
            UpdatedAt = auditData.UpdatedAt;
        }
        public AuditDataDTO(UserAudit userAudit)
        {
            Id = userAudit.Id;
            CreatedAt = userAudit.CreatedAt;
            UpdatedAt = userAudit.UpdatedAt;
            LastLoginAt = userAudit.LastLoginAt;
        }
    }
}
