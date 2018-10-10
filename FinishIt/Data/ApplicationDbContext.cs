using FinishIt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinishIt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=BeautifulData;Trusted_Connection=True");
        }

        public DbSet<Party> Parties { get; set; }
        public DbSet<Senator> Senators { get; set; }
        public DbSet<State> States { get; set; }
    }
}
