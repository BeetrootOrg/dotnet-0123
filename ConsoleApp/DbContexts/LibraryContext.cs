using System;
using System.Collections.Generic;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.DbContexts;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAuthor> TblAuthors { get; set; }

    public virtual DbSet<TblBook> TblBooks { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("User ID=postgres;Password=db_learn;Host=localhost;Port=5432;Database=library;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAuthor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tbl_authors_pkey");

            entity.ToTable("tbl_authors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BirthYear).HasColumnName("birth_year");
            entity.Property(e => e.DeathYear).HasColumnName("death_year");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<TblBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tbl_books_pkey");

            entity.ToTable("tbl_books");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Isbn)
                .IsRequired()
                .HasMaxLength(13)
                .HasColumnName("isbn");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Author).WithMany(p => p.TblBooks)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_books_author_id_fkey");
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tbl_customers_pkey");

            entity.ToTable("tbl_customers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tbl_orders_pkey");

            entity.ToTable("tbl_orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("return_date");
            entity.Property(e => e.TakenDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("taken_date");

            entity.HasOne(d => d.Book).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_orders_book_id_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_orders_customer_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
