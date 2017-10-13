using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestEditOwner.Model
{
    public partial class Test1Context : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<LegalEntity> LegalEntity { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-7VFQEFS\SQLEXPRESS;Database=Test1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccoutId);

                entity.Property(e => e.AccoutId)
                    .HasColumnName("AccoutID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Balance).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Number).HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<LegalEntity>(entity =>
            {
                entity.Property(e => e.LegalEntityId)
                    .HasColumnName("LegalEntityID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.LegalEntity)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_LegalEntity_Account");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.SecondName).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Person_Account");
            });
        }
    }
}
