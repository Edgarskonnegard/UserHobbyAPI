using Microsoft.EntityFrameworkCore;
using UserHobbyApi.Models;

namespace UserHobbyApi.Data;

public class UserHobbyDbContext : DbContext
{
    public UserHobbyDbContext(DbContextOptions<UserHobbyDbContext> options)
    : base(options)
    {
    }

    public DbSet<User> Users { get; set;}
    public DbSet<Hobby> Hobbies { get; set;}
    public DbSet<UserHobby> UserHobbies { get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserHobby>()
            .HasKey(uh => uh.Id);

        modelBuilder.Entity<UserHobby>()
            .HasOne( uh => uh.User )
            .WithMany( u => u.UserHobbies )
            .HasForeignKey( uh => uh.UserId );

        modelBuilder.Entity<UserHobby>()
            .HasOne( uh => uh.Hobby)
            .WithMany( h => h.UserHobbies )
            .HasForeignKey( uh => uh.HobbyId);

        //Seed-Data
        modelBuilder.Entity<User>().HasData(
            new User {Id = 1, FirstName = "Anna", LastName = "Andersson", BirthYear = 1990 },
            new User {Id = 2, FirstName="Björn", LastName="Berg", BirthYear=1985}
        );

        modelBuilder.Entity<Hobby>().HasData(
            new Hobby {Id=1, Name="Löpning", Description="Springa i skogen"},
            new Hobby {Id=2, Name="Gitarr", Description="Spela akustisk gitarr"}
        );

        modelBuilder.Entity<UserHobby>().HasData(
            new UserHobby {Id=1, UserId = 1, HobbyId = 1, Url="https://google.com"},
            new UserHobby {Id=2, UserId = 1, HobbyId = 2, Url="https://facebook.com"},
            new UserHobby {Id=3, UserId = 2, HobbyId=2, Url="https://github.com"}
        );

    }
}