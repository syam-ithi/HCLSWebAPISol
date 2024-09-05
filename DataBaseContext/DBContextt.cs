using HCLSWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HCLSWebAPI.DataBaseContext
{
    public class DBContextt:DbContext
    {
        public DBContextt(DbContextOptions<DBContextt> options) : base(options) { }
        public DbSet<AdminType> AdminTypes { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
