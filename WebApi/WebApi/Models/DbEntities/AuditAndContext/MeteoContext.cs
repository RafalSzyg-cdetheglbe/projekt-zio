using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebApi.Models.DbEntities.MeteoEntities;
using WebApi.Models.DbEntities.UserEntities;

namespace WebApi.Models.DbEntities.AuditAndContext
{
    public class MeteoContext : DbContext
    {
        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<BaseAuditData>? BaseAudits { get; set; }
        public virtual DbSet<UserAudit>? UserAudit { get; set; }
        public virtual DbSet<MeteoStation>? MeteoStations { get; set; }
        public virtual DbSet<MeteoData>? MeteoData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MeteoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
