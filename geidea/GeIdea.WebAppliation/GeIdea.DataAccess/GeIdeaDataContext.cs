using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace GeIdea.DataAccess
{
    public class GeIdeaDataContext : DbContext
    {
        private IConfiguration _configuration;
        public GeIdeaDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("ProdConnection");

                optionsBuilder
                    .UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        public DbSet<Account> Accounts { get; set; }

    }
}
