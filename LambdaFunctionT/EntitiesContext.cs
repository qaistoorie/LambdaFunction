using LambdaFunctionT.Models;
using Microsoft.EntityFrameworkCore;

namespace LambdaFunctionT
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext(DbContextOptions<EntitiesContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
