using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models.db
{
    public partial class HousingEstateContext : DbContext
    {
        public HousingEstateContext()
        {
        }

        public HousingEstateContext(DbContextOptions<HousingEstateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<Information> Information { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=HousingEstate;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>(entity =>
            {
                entity.HasKey(x => x.IdHouse);

                entity.Property(e => e.IdHouse)
                    .HasColumnName("idHouse")
                    .HasViewColumnName("idHouse")
                    .HasMaxLength(7);

                entity.Property(e => e.AreaHouse)
                    .HasColumnName("areaHouse")
                    .HasViewColumnName("areaHouse")
                    .HasMaxLength(10);

                entity.Property(e => e.ColorHouse)
                    .HasColumnName("colorHouse")
                    .HasViewColumnName("colorHouse")
                    .HasMaxLength(10);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.LaneHouse)
                    .HasColumnName("laneHouse")
                    .HasViewColumnName("laneHouse")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdNumberNavigation)
                    .WithMany(p => p.House)
                    .HasForeignKey(x => x.IdNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("add");
            });

            modelBuilder.Entity<Information>(entity =>
            {
                entity.HasKey(x => x.IdNumber);

                entity.Property(e => e.IdNumber)
                    .HasColumnName("idNumber")
                    .HasViewColumnName("idNumber")
                    .HasMaxLength(13);

                entity.Property(e => e.AddressLine)
                    .HasColumnName("addressLine")
                    .HasViewColumnName("addressLine")
                    .HasColumnType("text");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birthDate")
                    .HasViewColumnName("birthDate")
                    .HasMaxLength(10);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasViewColumnName("email")
                    .HasMaxLength(30);

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasViewColumnName("fullname")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasViewColumnName("phone");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasViewColumnName("photo")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.IdUser);

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .HasViewColumnName("idUser");

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasViewColumnName("password")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdNumberNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(x => x.IdNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("have");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        internal Task FindByNameAsync(string idNumber)
        {
            throw new NotImplementedException();
        }

        internal Task FindByName()
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
