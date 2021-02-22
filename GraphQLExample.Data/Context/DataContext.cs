using GraphQLExample.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLExample.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Representative>().HasData(new object[]
            {
                Entities.Representative.Create(1, "Richard Davidson"),
                Entities.Representative.Create(2, "Shaun Jackson"),
                Entities.Representative.Create(3, "David James"),
                Entities.Representative.Create(4, "Peter Ricks"),
                Entities.Representative.Create(5, "Emily Doe")
            });
            
            modelBuilder.Entity<Client>().HasData(new object[]
            {
                Entities.Client.Create(1, "Beth Dawson"),
                Entities.Client.Create(2, "David Smith"),
                Entities.Client.Create(3, "Jack Dickson"),
                Entities.Client.Create(4, "Joe Doe"),
                Entities.Client.Create(5, "Juliet Anderson")
            });
            
            modelBuilder.Entity<Case>().HasData(new object[]
            {
                Entities.Case.Create(
                    1,
                    "C-01", 
                    "360 No scoped by a blind raindeer", 
                    true, 
                    1,
                    1),
                
                Entities.Case.Create(
                    2,
                    "C-02", 
                    "Crashed into colleagues car", 
                    true, 
                    2,
                    2),
                
                Entities.Case.Create(
                    3,
                    "C-03", 
                    "Double drop kicked my dog on the chin", 
                    false, 
                    3,
                    3),
                
                Entities.Case.Create(
                    4,
                    "C-04", 
                    "Egged my cat and ran over my friend's sheep", 
                    false, 
                    4,
                    4),
                
                Entities.Case.Create(
                    5,
                    "C-05", 
                    "Set fire to my house whilst I slept in my car", 
                    false, 
                    5,
                    5)
            });
        }

        public DbSet<Representative> Representative { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Case> Case { get; set; }
    }
}