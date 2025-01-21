using Microsoft.EntityFrameworkCore;

namespace Library.API.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
