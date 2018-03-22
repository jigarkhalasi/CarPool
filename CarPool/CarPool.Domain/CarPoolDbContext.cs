namespace CarPool.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CarPoolDbContext : DbContext
    {
        public CarPoolDbContext()
            : base("name=CarPoolDbContext")
        {
        }

        public virtual DbSet<tblRegistedGroup> tblRegistedGroups { get; set; }
        public virtual DbSet<tblUserRequest> tblUserRequests { get; set; }
        public virtual DbSet<tblUserRGDetail> tblUserRGDetails { get; set; }
        public virtual DbSet<tblUserRGMapping> tblUserRGMappings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
