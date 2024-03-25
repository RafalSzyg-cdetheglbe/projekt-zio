﻿using Microsoft.EntityFrameworkCore;
using WebApi.Models.DbEntities.UserEntities;

namespace WebApi.Models.DbEntities.AuditAndContext
{
    public class MeteoContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<UserAudit>? UserAudit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=projektdb;Username=admin;Password=admin");
    }
}