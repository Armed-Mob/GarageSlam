using GS.Shared;
using Microsoft.EntityFrameworkCore;

namespace GS.Server.Data
{
    public class GSContext : DbContext
    {
        public GSContext(DbContextOptions<GSContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Trackable> Trackables { get; set; }
        public DbSet<TrackableColor> TrackableColors { get; set; }
        public DbSet<TrackableYear> TrackableYears { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkOrder>(wo =>
            {
                wo.ToTable(nameof(WorkOrder));

                wo.Property(wo => wo.WorkOrderCost)
                    .HasColumnType("money")
                    .HasPrecision(2);
                wo.Property(wo => wo.WorkOrderPartsCost)
                   .HasColumnType("money")
                   .HasPrecision(2);
                wo.Property(wo => wo.WorkOrderLaborCost)
                   .HasColumnType("money")
                   .HasPrecision(2);
                wo.Property(wo => wo.IsCompleted)
                    .HasColumnType("bit");
            });

            modelBuilder.Entity<Note>(n =>
            {
                n.ToTable(nameof(Note));
            });

            modelBuilder.Entity<TrackableColor>(tc =>
            {
                tc.ToTable(nameof(TrackableColor));
            });

            modelBuilder.Entity<TrackableYear>(ty =>
            {
                ty.ToTable(nameof(TrackableYear));
            });

            modelBuilder.Entity<Trackable>(t =>
            {
                t.ToTable(nameof(Trackable));

                t.Property(t => t.RegistrationExpiry)
                    .HasColumnType("date");
                t.Property(t => t.InsuranceExpiry)
                    .HasColumnType("date");
            });
        }
    }
}
