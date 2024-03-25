using WebApi.Models.DbEntities.AuditAndContext;

namespace WebApi.Models.DbEntities.UserEntities
{
    public class UserAudit : BaseAuditData
    {
        public DateTime? LastLoginAt { get; set; }
    }
}
