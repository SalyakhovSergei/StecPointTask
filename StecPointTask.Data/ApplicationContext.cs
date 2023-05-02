using Microsoft.EntityFrameworkCore;
using StecPointTask.Data.DTO;
using System.Reflection.Emit;

namespace StecPointTask.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<UserDto> User { get; set; }
        public DbSet<OrganizationDto> Organization { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> context): base(context)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserDto>().ToTable("Users").Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Entity<OrganizationDto>().ToTable("Organizations").Property(f => f.Id).ValueGeneratedOnAdd();
        }
    }
}