using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4Assignment.Models
{
    public class MovieApplicationContext : DbContext
    {
        //This is the constructor
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options)
        {
        }

        //Takes data from teh ApplicationResponse object and pushes it to the Movies database
        public DbSet<ApplicationResponse> Movies { get; set; }
        public DbSet<MovieCategory> Categories { get; set; }

        //Sets default features when database is created
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieCategory>().HasData(
                new MovieCategory { CategoryId = 1, CategoryName = "Action/Adventure"},
                new MovieCategory { CategoryId = 2, CategoryName = "Comedy"},
                new MovieCategory { CategoryId = 3, CategoryName = "Drama"},
                new MovieCategory { CategoryId = 4, CategoryName = "Family" },
                new MovieCategory { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new MovieCategory { CategoryId = 6, CategoryName = "Miscellaneous" },
                new MovieCategory { CategoryId = 7, CategoryName = "Television"}
                );

            mb.Entity<ApplicationResponse>().HasData(

                //Adds data when database is created
                new ApplicationResponse
                {
                    MovieID = 1,
                    CategoryId = 3,
                    Title = "12 Angry Men",
                    Year = 1957,
                    Director = "Sidney Lumet",
                    Rating = "G",
                    IsEdited = false,
                    LentTo = "",
                    Notes = "Made me better"
                },

                new ApplicationResponse
                {
                    MovieID = 2,
                    CategoryId = 1,
                    Title = "Dawn of the Planet of the Apes",
                    Year = 2014,
                    Director = "Matt Reeves",
                    Rating = "PG-13",
                    IsEdited = false,
                    LentTo = "",
                    Notes = "Incredible film"
                },

                new ApplicationResponse
                {
                    MovieID = 3,
                    CategoryId = 1,
                    Title = "Raiders of the Lost Ark",
                    Year = 1981,
                    Director = "Steven Spielberg",
                    Rating = "PG",
                    IsEdited = false,
                    LentTo = "",
                    Notes = "What an adventure"
                }
            );
        }

    }
}
