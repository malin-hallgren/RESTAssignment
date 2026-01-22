using Microsoft.EntityFrameworkCore;
using RESTAssignment.Models;

namespace RESTAssignment.Data
{
    public class RESTAssignmentDbContext : DbContext
    {
        public RESTAssignmentDbContext(DbContextOptions<RESTAssignmentDbContext> options) : base(options)
        {
        
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, FirstName = "John", LastName = "Doe", Phone = "123-456-7890" },
                new Person { Id = 2, FirstName = "Jane", LastName = "Smith", Phone = "987-654-3210" },
                new Person { Id = 3, FirstName = "Alice", LastName = "Johnson", Phone = "555-123-4567" },
                new Person { Id = 4, FirstName = "Bob", LastName = "Brown", Phone = "444-987-6543" },
                new Person { Id = 5, FirstName = "Charlie", LastName = "Davis", Phone = "333-222-1111" }
            );

            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Name = "Hiking", Description = "Long walks in nature and challenging terrain"},
                new Interest { Id = 2, Name = "Cooking", Description = "Creating delicious meals and experimenting with recipes"},
                new Interest { Id = 3, Name = "Photography", Description = "Capturing moments through the lens of a camera" },
                new Interest { Id = 4, Name = "Gaming", Description = "Playing video games across various platforms" },
                new Interest { Id = 5, Name = "Traveling", Description = "Exploring new places and experiencing different cultures" },
                new Interest { Id = 6, Name = "Reading", Description = "Diving into books and expanding knowledge" },
                new Interest { Id = 7, Name = "Music", Description = "Listening to and creating music across genres" },
                new Interest { Id = 8, Name = "Fitness", Description = "Engaging in physical activities to maintain health and wellness" },
                new Interest { Id = 9, Name = "Gardening", Description = "Cultivating plants and creating beautiful outdoor spaces" }
            );

            modelBuilder.Entity<PersonInterest>().HasData(
                new PersonInterest { Id = 1, PersonId = 1, InterestId = 1 },
                new PersonInterest { Id = 2, PersonId = 1, InterestId = 3 },
                new PersonInterest { Id = 3, PersonId = 1, InterestId = 5 },
                new PersonInterest { Id = 4, PersonId = 2, InterestId = 2 },
                new PersonInterest { Id = 5, PersonId = 2, InterestId = 6 },
                new PersonInterest { Id = 6, PersonId = 2, InterestId = 7 },
                new PersonInterest { Id = 7, PersonId = 2, InterestId = 9 },
                new PersonInterest { Id = 8, PersonId = 3, InterestId = 1 },
                new PersonInterest { Id = 9, PersonId = 3, InterestId = 4 },
                new PersonInterest { Id = 10, PersonId = 3, InterestId = 8 },
                new PersonInterest { Id = 11, PersonId = 4, InterestId = 2 },
                new PersonInterest { Id = 12, PersonId = 4, InterestId = 5 },
                new PersonInterest { Id = 13, PersonId = 5, InterestId = 3 },
                new PersonInterest { Id = 14, PersonId = 5, InterestId = 7 },
                new PersonInterest { Id = 15, PersonId = 5, InterestId = 9 },
                new PersonInterest { Id = 16, PersonId = 5, InterestId = 8 }

            );

            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, PersonId = 1, InterestId = 1, Url = "https://www.visitstockholm.com/see-do/activities/hiking-trails/" },
                new Link { Id = 2, PersonId = 2, InterestId = 2, Url = "https://cooking.nytimes.com/" },
                new Link { Id = 3, PersonId = 3, InterestId = 4, Url = "https://www.ign.com/" },
                new Link { Id = 4, PersonId = 4, InterestId = 5, Url = "https://www.lonelyplanet.com/" },
                new Link { Id = 5, PersonId = 5, InterestId = 7, Url = "https://www.spotify.com/" },
                new Link { Id = 6, PersonId = 1, InterestId = 3, Url = "https://www.nationalgeographic.com/photography" },
                new Link { Id = 7, PersonId = 2, InterestId = 6, Url = "https://www.goodreads.com/" },
                new Link { Id = 8, PersonId = 3, InterestId = 8, Url = "https://www.fitnessblender.com/" },
                new Link { Id = 9, PersonId = 4, InterestId = 9, Url = "https://www.gardeningknowhow.com/" },
                new Link { Id = 10, PersonId = 5, InterestId = 1, Url = "https://www.alltrails.com/" },
                new Link { Id = 11, PersonId = 2, InterestId = 9, Url = "https://www.rhs.org.uk/" },
                new Link { Id = 12, PersonId = 5, InterestId = 8, Url = "https://www.bodybuilding.com/" },
                new Link { Id = 13, PersonId = 1, InterestId = 5, Url = "https://www.tripadvisor.com/" },
                new Link { Id = 14, PersonId = 2, InterestId = 7, Url = "https://www.rollingstone.com/music/" },
                new Link { Id = 15, PersonId = 3, InterestId = 1, Url = "https://www.hikingproject.com/" },
                new Link { Id = 16, PersonId = 4, InterestId = 2, Url = "https://www.allrecipes.com/" },
                new Link { Id = 17, PersonId = 5, InterestId = 3, Url = "https://www.digitalphotomentor.com/" },
                new Link { Id = 18, PersonId = 4, InterestId = 5, Url = "https://www.nationalgeographic.com/travel/" },
                new Link { Id = 19, PersonId = 2, InterestId = 6, Url = "https://www.projectgutenberg.org/" },
                new Link { Id = 20, PersonId = 3, InterestId = 8, Url = "https://www.myfitnesspal.com/" }

            );
        }
    }
}
