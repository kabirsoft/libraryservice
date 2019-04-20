using LibraryService_datalayer.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService_datalayer.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=LibraryDBConstr")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryContext, Configuration>());            
        }
        public DbSet<LibraryService_datalayer.Models.Book> Books { get; set; }
        public DbSet<LibraryService_datalayer.Models.Author> Authors { get; set; }
        public DbSet<LibraryService_datalayer.Models.Cost> Costs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
