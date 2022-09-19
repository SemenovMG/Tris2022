using Microsoft.EntityFrameworkCore;
using Tris2022.Entity;

#nullable disable

namespace Tris2022.Infrastructure.Data
{
    public class DeansOfficeContext : DbContext
    {
        public DbSet<Student> Products { get; set; }
        public DeansOfficeContext(DbContextOptions<DeansOfficeContext> options)
            : base(options)
        {
        }
    }
}
