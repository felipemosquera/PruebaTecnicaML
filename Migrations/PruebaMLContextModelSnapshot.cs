﻿// <auto-generated />
using System;
using Felipe_ML.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Felipe_ML.Migrations
{
    [DbContext(typeof(PruebaMLContext))]
    partial class PruebaMLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Felipe_ML.Models.Dna", b =>
                {
                    b.Property<string>("DnaSequence")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("dnaSequence");

                    b.Property<bool?>("IsHuman")
                        .HasColumnType("bit")
                        .HasColumnName("isHuman");

                    b.Property<bool?>("IsMutant")
                        .HasColumnType("bit")
                        .HasColumnName("isMutant");

                    b.HasKey("DnaSequence")
                        .HasName("PK__Dna__D87608AE1206FDE8");

                    b.ToTable("Dna");
                });
#pragma warning restore 612, 618
        }
    }
}
