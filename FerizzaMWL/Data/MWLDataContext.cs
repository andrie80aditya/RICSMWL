using System;
using FerizzaMWL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FerizzaMWL.Data
{
    public partial class MWLDataContext : DbContext
    {
        public MWLDataContext()
        {
        }

        public MWLDataContext(DbContextOptions<MWLDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MwlSCPTbl> MwlSCPTbl { get; set; }
        public virtual DbSet<MWLClient> MWLClient { get; set; }
    }
}
