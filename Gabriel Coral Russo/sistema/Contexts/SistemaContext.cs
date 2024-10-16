using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using sistema.Models;

namespace sistema.Contexts;

public partial class SistemaContext : DbContext
{
    public SistemaContext()
    {
    }

    public SistemaContext(DbContextOptions<SistemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atividade> Atividades { get; set; }

    public virtual DbSet<Professor> Professores { get; set; }

    public virtual DbSet<Turma> Turmas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NOTE15-S21;Initial Catalog=dev_db;Trusted_Connection=True;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atividade>(entity =>
        {
            entity.HasKey(e => e.AtividadeId).HasName("PK__Atividad__742A5DF45876E068");

            entity.ToTable("Atividades");

            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Turma).WithMany(p => p.Atividades)
                .HasForeignKey(d => d.TurmaId)
                .HasConstraintName("FK__Atividade__Turma__3C69FB99");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.ProfessorId).HasName("PK__Professo__90035949D20606E8");

            entity.ToTable("Professores");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Turma>(entity =>
        {
            entity.HasKey(e => e.TurmaId).HasName("PK__Turma__BABB9304C8B17DAE");

            entity.ToTable("Turmas");

            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Professor).WithMany(p => p.Turmas)
                .HasForeignKey(d => d.ProfessorId)
                .HasConstraintName("FK__Turma__Professor__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
