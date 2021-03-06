﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace gameApi.Models1
{
    public partial class gameApiContext : DbContext
    {
        public gameApiContext()
        {
        }

        public gameApiContext(DbContextOptions<gameApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameEarning> GameEarnings { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=gameApi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.Property(e => e.GameId)
                    .ValueGeneratedNever()
                    .HasColumnName("game_id");

                entity.Property(e => e.GameName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("game_name");

                entity.Property(e => e.GamePlatform)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("game_platform");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("genre");

                entity.Property(e => e.Studio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("studio");
            });

            modelBuilder.Entity<GameEarning>(entity =>
            {
                entity.HasKey(e => e.GameId)
                    .HasName("pk_earnings");

                entity.ToTable("game_earnings");

                entity.Property(e => e.GameId)
                    .ValueGeneratedNever()
                    .HasColumnName("game_id");

                entity.Property(e => e.GamePrice).HasColumnName("game_price");

                entity.Property(e => e.TotalSold).HasColumnName("total_sold");

                entity.HasOne(d => d.Game)
                    .WithOne(p => p.GameEarning)
                    .HasForeignKey<GameEarning>(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_earnings");
            });

            modelBuilder.Entity<Studio>(entity =>
            {
                entity.ToTable("studio");

                entity.Property(e => e.StudioId)
                    .HasMaxLength(10)
                    .HasColumnName("studio_id")
                    .IsFixedLength(true);

                entity.Property(e => e.StudioName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("studio_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
