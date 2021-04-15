namespace Api.Data
{
    using Api.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    class MusicContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MusicContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                accountEndpoint: _configuration["CosmosDb:Endpoint"],
                accountKey: _configuration["CosmosDb:Key"],
                databaseName: _configuration["CosmosDb:Database"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .ToContainer("Artists")
                .HasNoDiscriminator()
                .HasPartitionKey("Id");
        }
    }
}