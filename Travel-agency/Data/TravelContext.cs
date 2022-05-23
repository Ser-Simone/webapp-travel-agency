using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Travel_agency.Models;

namespace Travel_agency.Data
{
    public class TravelContext : DbContext
    {
        public DbSet<Destinations> destinationSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=Db_AgencyTravel;Integrated Security=True");

        }
    }
}
