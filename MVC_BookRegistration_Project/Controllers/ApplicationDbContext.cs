using Microsoft.EntityFrameworkCore;
using MVC_BookRegistration_Project.Models;

namespace MVC_BookRegistration_Project.Controllers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { 
        
        }
        public DbSet<Book> Books { get; set; }

    }
}
