using dotnetAPI_Rubrica.Models;
using dotnetAPI_Rubrica.Models.DTO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnetAPI_Rubrica.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //seed table contact with 5 contact
            builder.Entity<Contact>().HasData(new Contact
            {
                Id = 1,
                Name = "Mario",
                Lastname = "Rossi",
                Email = "marocorssi@gmail.com",
                TelephoneNumber = "3333333333",
                UserId = "63accc2d-c69b-4ce5-9f76-3415fc98ce1e"
            },
            new Contact
            {
                Id = 2,
                Name = "Luigi",
                Lastname = "Verdi",
                Email = "luigiverdi@gmail.com",
                TelephoneNumber = "123123123",
                UserId = "2b5b0646-712c-4e6a-a6c2-8e887ca5ffb9"
            },
            new Contact
            {
                Id = 3,
                Name = "Giovanni",
                Lastname = "Bianchi",
                Email = "giovabianchi@gmail.com",
                TelephoneNumber = "456456456",
                UserId = "2b5b0646-712c-4e6a-a6c2-8e887ca5ffb9"
            },
            new Contact
            {
                Id = 4,
                Name = "Paolo",
                Lastname = "Neri",
                Email = "paroloneri@gmail.com",
                TelephoneNumber = "789789789",
                UserId = "63accc2d-c69b-4ce5-9f76-3415fc98ce1e"
            },
            new Contact
            {
                Id = 5,
                Name = "Marco",
                Lastname = "Gialli",
                Email = "marcogialli@gmail.com",
                TelephoneNumber = "159159159",
                UserId = "63accc2d-c69b-4ce5-9f76-3415fc98ce1e"
            });
            base.OnModelCreating(builder);
        }
        
        
    }
}
