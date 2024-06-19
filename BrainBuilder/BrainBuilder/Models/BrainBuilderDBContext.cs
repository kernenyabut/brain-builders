using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BrainBuilder.Models
{
    public partial class BrainBuilderDBContext : DbContext
    {
        public BrainBuilderDBContext()
        {
        }

        public BrainBuilderDBContext(DbContextOptions<BrainBuilderDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Achievements> Achievements { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Avatars> Avatars { get; set; }
        public virtual DbSet<BillingType> BillingType { get; set; }
        public virtual DbSet<CreditCardTypes> CreditCardTypes { get; set; }
        public virtual DbSet<CreditCards> CreditCards { get; set; }
        public virtual DbSet<GameStats> GameStats { get; set; }
        public virtual DbSet<GameStatsMatching> GameStatsMatching { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Profiles> Profiles { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Stats> Stats { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }
        public virtual DbSet<UserSubscriptions> UserSubscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=KERNEN-LAPTOP\\SQLEXPRESS01;Database=BrainBuilderDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__Accounts__B19E45E93ECAB2B8");

                entity.Property(e => e.AccountId).HasColumnName("Account_Id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ProvinceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Account_Province_FK");
            });

            modelBuilder.Entity<Achievements>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.DatePlayed).HasColumnType("datetime");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Achievements)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_Achievements_Games_Id");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Achievements)
                    .HasForeignKey<Achievements>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_Account_Achievements_Id");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Avatars>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AvatarCode)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Avatars)
                    .HasForeignKey<Avatars>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_Account_Avatar_Id");
            });

            modelBuilder.Entity<BillingType>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__BillingT__A25C5AA68A862850");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CreditCardTypes>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("CreditCard_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .ValueGeneratedNever();

                entity.Property(e => e.CardNumberPrefixList)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<CreditCards>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("Account_Id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CardCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ExpiryMonth)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiryYear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Province).HasMaxLength(2);

                entity.Property(e => e.SecurityCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.CreditCards)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__CreditCar__Accou__693CA210");

                entity.HasOne(d => d.CardCodeNavigation)
                    .WithMany(p => p.CreditCards)
                    .HasForeignKey(d => d.CardCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CreditCar__CardC__6A30C649");
            });

            modelBuilder.Entity<GameStats>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("Account_Id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.GameStats)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__GameStats__Accou__6C190EBB");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameStats)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("PK_GameId_Games_Id");
            });

            modelBuilder.Entity<GameStatsMatching>(entity =>
            {
                entity.ToTable("GameStats_Matching");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountId).HasColumnName("Account_Id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.GameStatsMatching)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__GameStats__Accou__6E01572D");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.GameStatsMatching)
                    .HasForeignKey<GameStatsMatching>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_Id_GameStats_Id");
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.GameId)
                    .HasName("Games_PK");

                entity.Property(e => e.DatePublished).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Instructions)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profiles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Bio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Motto)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceCode).HasMaxLength(2);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Profiles)
                    .HasForeignKey<Profiles>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_Account_Profile_Id");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.ProvinceCode)
                    .HasConstraintName("FK_Province_Profile_ProvinceCode");
            });

            modelBuilder.Entity<Provinces>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("ProvinceLookup_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Stats>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Subscriptions>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Subscrip__A25C5AA6830329D4");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<UserSubscriptions>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("Account_Id");

                entity.Property(e => e.BillingTypeCode).HasMaxLength(2);

                entity.Property(e => e.InitalPaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentDue).HasColumnType("datetime");

                entity.Property(e => e.SubscriptionCode).HasMaxLength(2);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.UserSubscriptions)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Account_UserSubscription_Id");

                entity.HasOne(d => d.BillingTypeCodeNavigation)
                    .WithMany(p => p.UserSubscriptions)
                    .HasForeignKey(d => d.BillingTypeCode)
                    .HasConstraintName("FK_Subscriptions_BillingType_Code");

                entity.HasOne(d => d.SubscriptionCodeNavigation)
                    .WithMany(p => p.UserSubscriptions)
                    .HasForeignKey(d => d.SubscriptionCode)
                    .HasConstraintName("FK_Subscriptions_UserSubscriptions_Code");
            });
        }
    }
}
