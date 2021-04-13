using Microsoft.EntityFrameworkCore;

namespace WebApiMovieDB.Models
{
    public partial class MovieBaseContext : DbContext
    {
        public MovieBaseContext(DbContextOptions<MovieBaseContext> options) : base(options)
        {
        }

        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<MovieCast> MovieCast { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actors>(entity =>
            {
                entity.HasKey(e => e.ActorId);

                entity.Property(e => e.ActorId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MovieCast>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MovieRole)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.Property(e => e.MovieId).ValueGeneratedNever();

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
