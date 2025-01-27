using Library.API.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.API.Tests
{
    public class DatabaseContext
    {
        public async Task<LibraryDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new LibraryDbContext(options);
            await databaseContext.Database.EnsureCreatedAsync();

            return databaseContext;
        }
    }
}
