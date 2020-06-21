using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace koloss.Models
{
    public partial class s16534Context : DbContext
    {
        public s16534Context()
        {
        }

        public s16534Context(DbContextOptions<s16534Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtistEvent> ArtistEvent { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventOrganiser> EventOrganiser { get; set; }
        public virtual DbSet<Organiser> Organiser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16534;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.IdArtist)
                    .HasName("Artist_pk");

                entity.Property(e => e.IdArtist).ValueGeneratedNever();

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ArtistEvent>(entity =>
            {
                entity.HasKey(e => new { e.IdEvent, e.IdArtist })
                    .HasName("Artist_Event_pk");

                entity.ToTable("Artist_Event");

                entity.Property(e => e.PerformanceDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdArtistNavigation)
                    .WithMany(p => p.ArtistEvent)
                    .HasForeignKey(d => d.IdArtist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_2_Artis");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.ArtistEvent)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_2_Event");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.IdEvent)
                    .HasName("Event_pk");

                entity.Property(e => e.IdEvent).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EventOrganiser>(entity =>
            {
                entity.HasKey(e => new { e.IdEvent, e.IdOrganiser })
                    .HasName("Event_Organiser_pk");

                entity.ToTable("Event_Organiser");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.EventOrganiser)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Event_Organiser_Table_3");

                entity.HasOne(d => d.IdOrganiserNavigation)
                    .WithMany(p => p.EventOrganiser)
                    .HasForeignKey(d => d.IdOrganiser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Event_Organiser_Organiser");
            });

            modelBuilder.Entity<Organiser>(entity =>
            {
                entity.HasKey(e => e.IdOrganiser)
                    .HasName("Organiser_pk");

                entity.Property(e => e.IdOrganiser).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
