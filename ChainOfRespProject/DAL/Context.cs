using Microsoft.EntityFrameworkCore;

namespace ChainOfRespProject.DAL
{
    public class Context:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-HHOE249\\SQLEXPRESS;initial Catalog=DbChain;integrated security=true");
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
