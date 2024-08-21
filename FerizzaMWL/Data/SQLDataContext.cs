using FerizzaMWL.Models;
using Microsoft.EntityFrameworkCore;

namespace FerizzaMWL.Data
{
    public partial class SQLDataContext : DbContext
    {
        public SQLDataContext()
        {
        }

        public SQLDataContext(DbContextOptions<SQLDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Study> Study { get; set; }
        public virtual DbSet<MwlSCP> MwlSCP { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ModalityList> ModalityList { get; set; }
    }
}
