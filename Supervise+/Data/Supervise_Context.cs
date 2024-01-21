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
        
        public DbSet<Supervise_.Models.sp_user_account>? sp_user_account { get; set; }
        
        public DbSet<Supervise_.Models.sp_gp_setting>? sp_gp_setting { get; set; }
        
        public DbSet<Supervise_.Models.sp_student>? sp_student { get; set; }
        
        public DbSet<Supervise_.Models.sp_instructor>? sp_instructor { get; set; }
        
        public DbSet<Supervise_.Models.sp_GP_Group>? sp_GP_Group { get; set; }
        

      
    }
}
