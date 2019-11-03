using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TODOAPI.Models;

namespace TODOAPI.Data
{
    /*Actually i have inherited this class with IdentityDbContext,because i have an idea of adding
    identity in furthur development or you can use DbContext so that you can configure identity later*/
    public class ApplicationDbContext : IdentityDbContext
    {
     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
     {
     }
     public DbSet<Models.TodoItems> todoItems{get; set;}

     /*This is the ModelCreating method that will override the model objects in the database,
     i have a scenario we have connection with mysql,some versions of mysql are unable to create
     the database due to field lenght issues,key reference issues with the coloms in the table .....these all come 
     into picture when working with identity(msdn -Authentication and Authorization) */
     protected override void OnModelCreating(ModelBuilder builder)
     {
         base.OnModelCreating(builder);
     }
    }
}