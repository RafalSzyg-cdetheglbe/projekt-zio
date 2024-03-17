using Microsoft.EntityFrameworkCore;

namespace WebApi.Models.DbEntities.AuditAndContext
{
    public class MeteoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=projektdb;Username=admin;Password=admin");
    }
}
