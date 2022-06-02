using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Felipe_ML.Models
{
    public partial class PruebaMLContext : DbContext
    {
        public PruebaMLContext()
        {
        }

        public PruebaMLContext(DbContextOptions<PruebaMLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dna> Dnas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-SB43OBK\\SQLEXPRESS;Database=PruebaML;User Id=felipe;Password=12345;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Dna>(entity =>
            {
                entity.HasKey(e => e.DnaSequence)
                    .HasName("PK__Dna__D87608AE1206FDE8");

                entity.ToTable("Dna");

                entity.Property(e => e.DnaSequence)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("dnaSequence");

                entity.Property(e => e.IsHuman).HasColumnName("isHuman");

                entity.Property(e => e.IsMutant).HasColumnName("isMutant");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
