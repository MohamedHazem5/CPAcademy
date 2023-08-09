
using Microsoft.EntityFrameworkCore;


namespace CPAcademy.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
