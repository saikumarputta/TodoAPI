using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TODOAPI.Models;

namespace TODOAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
     {
     }
     public DbSet<Models.TodoItems> todoItems{get; set;}
     protected override void OnModelCreating(ModelBuilder builder)
     {
         base.OnModelCreating(builder);
     }
    }
}