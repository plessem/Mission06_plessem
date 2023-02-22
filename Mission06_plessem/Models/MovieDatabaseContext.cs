using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_plessem.Models
{
    public class MovieDatabaseContext : DbContext
    {
        //Constructor
        public MovieDatabaseContext (DbContextOptions<MovieDatabaseContext> options) : base (options)
        {

        }

        public DbSet<ApplicationResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "Emma",
                    Year = 2020,
                    Director = "Autumn de Wilde", 
                    Rating = "PG"
                },
                new ApplicationResponse
                {
                    MovieId = 2,
                    CategoryId = 1,
                    Title = "Pride and Prejudice",
                    Year = 2005,
                    Director = "Joe Wright",
                    Rating = "PG"
                },
                new ApplicationResponse
                {
                    MovieId = 3,
                    CategoryId = 2,
                    Title = "Tangled",
                    Year = 2010,
                    Director = "Nathan Greno",
                    Rating = "PG"
                }
            );
        }
    }
}
