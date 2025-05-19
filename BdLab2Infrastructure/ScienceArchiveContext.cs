using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bd2Domain.Model;

namespace BdLab2Infrastructure;
public partial class ScienceArchiveContext : DbContext
{
    public ScienceArchiveContext()
    {
    }

    public ScienceArchiveContext(DbContextOptions<ScienceArchiveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Journal> Journals { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Publication> Publications { get; set; }

    public virtual DbSet<PublicationType> PublicationTypes { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Reviewer> Reviewers { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1) Конфігурація зв'язку Publication ↔️ Subject через таблицю PublicationSubject
        modelBuilder.Entity<Publication>()
            .HasMany(p => p.Subjects)
            .WithMany(s => s.Publications)
            .UsingEntity<Dictionary<string, object>>(
                "PublicationSubject",                      // ім’я таблиці в БД
                right => right.HasOne<Subject>()
                              .WithMany()
                              .HasForeignKey("SubjectId"),  // колонка що FK на Subjects.Id
                left => left.HasOne<Publication>()
                              .WithMany()
                              .HasForeignKey("PublicationId"), // колонка що FK на Publications.Id
                je =>
                {
                    je.HasKey("PublicationId", "SubjectId");
                    je.ToTable("PublicationSubject");
                });

        // 2) Конфігурація зв'язку Author ↔️ Publication через таблицю AuthorsPublications
        modelBuilder.Entity<Author>()
            .HasMany(a => a.Publications)
            .WithMany(p => p.Authors)
            .UsingEntity<Dictionary<string, object>>(
                "AuthorsPublications",                     // ім’я таблиці в БД
                right => right.HasOne<Publication>()
                              .WithMany()
                              .HasForeignKey("PublicationsId"), // колонка що FK на Publications.Id
                left => left.HasOne<Author>()
                              .WithMany()
                              .HasForeignKey("AuthorId"),       // колонка що FK на Authors.Id
                je =>
                {
                    je.HasKey("AuthorId", "PublicationsId");
                    je.ToTable("AuthorsPublications");
                });
        // 3) Явно вказати, що DbSet<Review> Reviews відповідає таблиці "Review"
        modelBuilder.Entity<Review>()
            .ToTable("Review");
    }
}
