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
        public DbSet<Category> Categories { get; set; }

        //seeding the data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
               new Category { CategoryId=1, CategoryName="Action/Adventure" },
               new Category { CategoryId=2, CategoryName ="Comedy" },
               new Category { CategoryId=3, CategoryName ="Drama" },
               new Category { CategoryId=4, CategoryName ="Family" },
               new Category { CategoryId=5, CategoryName ="Horror/Suspense" },
               new Category { CategoryId=6, CategoryName ="Miscellaneous" },
               new Category { CategoryId=7, CategoryName ="Television" },
               new Category { CategoryId=8, CategoryName ="VHS" }

            );

            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    MovieId = 1,
                    CategoryId = 3,
                    Title = "Emma",
                    Year = 2020,
                    Director = "Autumn de Wilde", 
                    Rating = "PG"
                },
                new ApplicationResponse
                {
                    MovieId = 2,
                    CategoryId = 3,
                    Title = "Pride and Prejudice",
                    Year = 2005,
                    Director = "Joe Wright",
                    Rating = "PG"
                },
                new ApplicationResponse
                {
                    MovieId = 3,
                    CategoryId = 4,
                    Title = "Tangled",
                    Year = 2010,
                    Director = "Nathan Greno",
                    Rating = "PG"
                }
            );
        }
    }
}
