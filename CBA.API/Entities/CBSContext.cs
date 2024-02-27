using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace CBA.API.Entities
{
    public class CBSContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TransactionDB");
        }
        public DbSet<Transaction>  transactions { get; set; }
    }
}
