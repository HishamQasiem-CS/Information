using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Task.Models;

namespace Task.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        
        }
        public DbSet<InformationUser>informationUsers { get; set; }
    }
}
