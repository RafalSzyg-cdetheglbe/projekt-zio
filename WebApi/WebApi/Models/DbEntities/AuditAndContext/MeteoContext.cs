using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebApi.Models.DbEntities.MeteoEntities;
using WebApi.Models.DbEntities.UserEntities;

namespace WebApi.Models.DbEntities.AuditAndContext
{
    public class MeteoContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<BaseAuditData>? BaseAudits { get; set; }
        public DbSet<UserAudit>? UserAudit { get; set; }
        public DbSet<MeteoStation>? MeteoStations { get; set; }
        public DbSet<MeteoData>? MeteoData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MeteoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
