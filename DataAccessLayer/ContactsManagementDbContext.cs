using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ContactsManagementDbContext : DbContext
    {
        public ContactsManagementDbContext()
        {
        }

        public ContactsManagementDbContext(DbContextOptions<ContactsManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
