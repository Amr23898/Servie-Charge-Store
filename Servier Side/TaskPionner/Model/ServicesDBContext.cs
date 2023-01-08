using Microsoft.EntityFrameworkCore;

namespace TaskPionner.Model
{
    public class ServicesDBContext:DbContext
    {
        public ServicesDBContext()
        {

        }
        public ServicesDBContext(DbContextOptions<ServicesDBContext>option):base(option)
        {

        }

        public virtual DbSet<card>cards { get; set; }
        public virtual DbSet<Services> services { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
 
    }
}
