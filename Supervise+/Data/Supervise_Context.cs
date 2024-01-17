using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supervise_.Models;

namespace Supervise_.Data
{
    public class Supervise_Context : DbContext
    {
        public Supervise_Context (DbContextOptions<Supervise_Context> options)
            : base(options)
        {
        }

        public DbSet<Supervise_.Models.facultys> facultys { get; set; } = default!;

        public DbSet<Supervise_.Models.GP_Settings>? GP_Settings { get; set; }

        public DbSet<Supervise_.Models.Student>? Student { get; set; }
    }
}
