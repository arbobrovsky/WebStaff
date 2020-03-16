using Data.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

       public DbSet<Staff> Staffs { get; set; }
       public DbSet<Department> Departments { get; set; }
        public DbSet<Fired> Fireds { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Rank> Ranks { get; set; }
      public DbSet<SubDepartment> SubDepartments { get; set; }
       public DbSet<Decree> Decrees { get; set; } //Приказ
       public DbSet<DecreeStaffs> DecreeStaffs { get; set; } //Приказ
    }
}
