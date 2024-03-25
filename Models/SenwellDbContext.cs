using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SenWellTask.Models;

public partial class SenwellDbContext : DbContext
{
    public SenwellDbContext()
    {
    }

    public SenwellDbContext(DbContextOptions<SenwellDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-FF8E3E6\\SQLEXPRESS;Database=SenwellDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C52E0BA8CEE27E7F");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birth_date");
            entity.Property(e => e.DeptName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dept_name");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.HireDate)
                .HasColumnType("date")
                .HasColumnName("hire_date");
            entity.Property(e => e.JoinDate)
                .HasColumnType("date")
                .HasColumnName("join_date");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
