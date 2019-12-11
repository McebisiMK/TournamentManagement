using Microsoft.EntityFrameworkCore;

namespace TournamentManagement.Entities.Models
{
    public partial class TournamentManagementDBContext : DbContext
    {
        public TournamentManagementDBContext()
        {
        }

        public TournamentManagementDBContext(DbContextOptions<TournamentManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<RegisteredTeam> RegisteredTeam { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__Registrat__TeamI__38996AB5");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.TournamentId)
                    .HasConstraintName("FK__Registrat__Tourn__398D8EEE");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Captain)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Coach)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<RegisteredTeam>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
