using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APICurso1500.Models;

namespace APICurso1500.Data
{
    public class APICurso1500Context : DbContext
    {
        public APICurso1500Context (DbContextOptions<APICurso1500Context> options)
            : base(options)
        {
        }

        public DbSet<APICurso1500.Models.Contact>? Contact { get; set; }
    }
}
