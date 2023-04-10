using System;
using System.Collections.Generic;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.DbContexts;

public partial class ShopContext : DbContext
{
    public ShopContext()
    {
    }

    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    public virtual DbSet<TblOrdersProduct> TblOrdersProducts { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("User ID=user;Password=password;Host=localhost;Port=5432;Database=shop;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tbl_customers_pkey");

            entity.ToTable("tbl_customers");

            entity.HasIndex(e => e.Email, "tbl_customers_email").IsUnique();

            entity.HasIndex(e => new { e.LastName, e.FirstName }, "tbl_customers_last_name_first_name");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(1000)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tbl_employees_pkey");

            entity.ToTable("tbl_employees");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Salary)
                .HasColumnType("money")
                .HasColumnName("salary");
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tbl_orders_pkey");

            entity.ToTable("tbl_orders");

            entity.HasIndex(e => e.CustomerId, "tbl_orders_customer_id");

            entity.HasIndex(e => e.EmployeeId, "tbl_orders_employee_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("order_date");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("tbl_orders_customer_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("tbl_orders_employee_id_fkey");
        });

        modelBuilder.Entity<TblOrdersProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tbl_orders_products_pkey");

            entity.ToTable("tbl_orders_products");

            entity.HasIndex(e => e.OrderId, "tbl_orders_products_order_id");

            entity.HasIndex(e => e.ProductId, "tbl_orders_products_product_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Order).WithMany(p => p.TblOrdersProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_orders_products_order_id_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.TblOrdersProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_orders_products_product_id_fkey");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tbl_products_pkey");

            entity.ToTable("tbl_products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
