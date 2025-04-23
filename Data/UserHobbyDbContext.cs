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

    }
}