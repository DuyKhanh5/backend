using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIEproject.Models
{
    public partial class APIEprojectContext : DbContext
    {
        public APIEprojectContext()
        {
        }

        public APIEprojectContext(DbContextOptions<APIEprojectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Office> Offices { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Staff> Staffs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-UVHIUHV\\SQLEXPRESS; database=APIEproject; uid=sa; pwd=123456; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Office>(entity =>
            {
                entity.ToTable("Office");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("date")
                    .HasColumnName("date_create");

                entity.Property(e => e.NameOffice)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name_office");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OfficeId)
                    .HasConstraintName("FK__Orders__office_i__37A5467C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__user_id__36B12243");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("staffs");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Designation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("designation");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.StaffName)
                    .HasMaxLength(255)
                    .HasColumnName("staff_name");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.OfficeId)
                    .HasConstraintName("FK__staffs__phone_nu__3A81B327");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConfirmPassword)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
