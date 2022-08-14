using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public partial class DataContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }


        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

     
    }
}
