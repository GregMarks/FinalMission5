using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext (DbContextOptions<MoviesContext> options) : base (options)
        {

        }
        //I'm not sure if EnterMovies is the correct thing to be here. Check video #3 if it doesn't work
        public DbSet<EnterMovies> responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating( ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category { CategoryID = 1, CategoryName="Action/Adventure"},
                    new Category { CategoryID = 2, CategoryName = "Comedy" },
                    new Category { CategoryID = 3, CategoryName = "Drama" },
                    new Category { CategoryID = 4, CategoryName = "Family" },
                    new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                    new Category { CategoryID = 6, CategoryName = "Television" },
                    new Category { CategoryID = 7, CategoryName = "Miscellaneous" },
                    new Category { CategoryID = 8, CategoryName = "VHS" }
                );

            mb.Entity<EnterMovies>().HasData(

                new EnterMovies
                {
                    MovieID = 1,
                    CategoryID = "1",
                    Title = "Star Wars: The Force Awakens",
                    Year = 2015,
                    Director = "J. J. Abrams",
                    Rating = "PG-13",
                    Edited = "",
                    Lent_To = "",
                    Notes = "",
                },
                new EnterMovies
                {
                    MovieID = 2,
                    CategoryID = "1",
                    Title = "Star Wars: Last Jedi",
                    Year = 2017,
                    Director = "Rian Johnson",
                    Rating = "PG-13",
                    Edited = "",
                    Lent_To = "",
                    Notes = "",
                },
                new EnterMovies
                {
                    MovieID = 3,
                    CategoryID = "1",
                    Title = "Star Wars: Rise of Skywalker",
                    Year = 2019,
                    Director = "J. J. Abrams",
                    Rating = "PG-13",
                    Edited = "",
                    Lent_To = "",
                    Notes = "",
                }
            );
        }
    }
}
