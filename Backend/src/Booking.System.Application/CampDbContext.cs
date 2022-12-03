using Booking.System.Domain;
using Booking.System.Domain.Booking;
using Booking.System.Domain.IdentityAspNet;

using Microsoft.EntityFrameworkCore;

namespace Booking.System.Application
{
    public partial class CampDbContext : DbContext
    {
        public CampDbContext(DbContextOptions<CampDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<BirthCertificateForeign> BirthCertificateForeigns { get; set; } = null!;
        public virtual DbSet<BirthCertificateRu> BirthCertificateRus { get; set; } = null!;
        public virtual DbSet<Camp> Camps { get; set; } = null!;
        public virtual DbSet<Child> Children { get; set; } = null!;
        public virtual DbSet<Feature> Features { get; set; } = null!;
        public virtual DbSet<LocalAdministrator> LocalAdministrators { get; set; } = null!;
        public virtual DbSet<Parent> Parents { get; set; } = null!;
        public virtual DbSet<PassportForeign> PassportForeigns { get; set; } = null!;
        public virtual DbSet<PassportRu> PassportRus { get; set; } = null!;
        public virtual DbSet<Shift> Shifts { get; set; } = null!;
        public virtual DbSet<ShiftByShiftType> ShiftByShiftTypes { get; set; } = null!;
        public virtual DbSet<ShiftRequest> ShiftRequests { get; set; } = null!;
        public virtual DbSet<ShiftType> ShiftTypes { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<SuperAdministrator> SuperAdministrators { get; set; } = null!;
        public virtual DbSet<WorkingMode> WorkingModes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AddressContent)
                    .HasColumnType("character varying")
                    .HasColumnName("address_content");

                entity.Property(e => e.Citizenship)
                    .HasColumnType("character varying")
                    .HasColumnName("citizenship");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BirthCertificateForeign>(entity =>
            {
                entity.HasKey(e => e.BirthCertificateId)
                    .HasName("birth_certificate_foreign_pkey");

                entity.ToTable("birth_certificate_foreign");

                entity.Property(e => e.BirthCertificateId)
                    .HasColumnName("birth_certificate_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.DateOfIssue).HasColumnName("date_of_issue");

                entity.Property(e => e.IssuedBy)
                    .HasColumnType("character varying")
                    .HasColumnName("issued_by");

                entity.Property(e => e.Number)
                    .HasColumnType("character varying")
                    .HasColumnName("number");

                entity.Property(e => e.Series)
                    .HasColumnType("character varying")
                    .HasColumnName("series");
            });

            modelBuilder.Entity<BirthCertificateRu>(entity =>
            {
                entity.HasKey(e => e.BirthCertificateId)
                    .HasName("birth_certificate_ru_pkey");

                entity.ToTable("birth_certificate_ru");

                entity.Property(e => e.BirthCertificateId)
                    .HasColumnName("birth_certificate_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.DateOfIssue).HasColumnName("date_of_issue");

                entity.Property(e => e.IssuedBy)
                    .HasColumnType("character varying")
                    .HasColumnName("issued_by");

                entity.Property(e => e.Number)
                    .HasMaxLength(6)
                    .HasColumnName("number");

                entity.Property(e => e.Series)
                    .HasMaxLength(6)
                    .HasColumnName("series");
            });

            modelBuilder.Entity<Camp>(entity =>
            {
                entity.ToTable("camp");

                entity.HasIndex(e => e.WorkingModeId, "fki_working_mode_fkey");

                entity.Property(e => e.CampId)
                    .HasColumnName("camp_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.About).HasColumnName("about");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.ChildrensHolidayCertificate).HasColumnName("childrens_holiday_certificate");

                entity.Property(e => e.ChildsAgeEnd).HasColumnName("childs_age_end");

                entity.Property(e => e.ChildsAgeStart).HasColumnName("childs_age_start");

                entity.Property(e => e.EducationalLicense).HasColumnName("educational_license");

                entity.Property(e => e.Food)
                    .HasColumnType("character varying")
                    .HasColumnName("food");

                entity.Property(e => e.LegalEntity)
                    .HasColumnType("character varying")
                    .HasColumnName("legal_entity");

                entity.Property(e => e.MedicalLicense).HasColumnName("medical_license");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.NumberOfBuildings).HasColumnName("number_of_buildings");

                entity.Property(e => e.ShortName)
                    .HasColumnType("character varying")
                    .HasColumnName("short_name");

                entity.Property(e => e.TheAreaOfTheLand).HasColumnName("the_area_of_​​the_land");

                entity.Property(e => e.WebsiteLink)
                    .HasColumnType("character varying")
                    .HasColumnName("website_link");

                entity.Property(e => e.WorkingModeId).HasColumnName("working_mode_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Camps)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("address_fkey");

                entity.HasOne(d => d.WorkingMode)
                    .WithMany(p => p.Camps)
                    .HasForeignKey(d => d.WorkingModeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("working_mode_fkey");
            });

            modelBuilder.Entity<Child>(entity =>
            {
                entity.ToTable("child");

                entity.HasIndex(e => e.BirthCertificateForeignId, "fki_birth_foreign_fkey");

                entity.HasIndex(e => e.BirthCertificateRuId, "fki_birth_ru_fkey");

                entity.Property(e => e.ChildId)
                    .HasColumnName("child_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.BirthCertificateForeignId).HasColumnName("birth_certificate_foreign_id");

                entity.Property(e => e.BirthCertificateRuId).HasColumnName("birth_certificate_ru_id");

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.PassportForeignId).HasColumnName("passport_foreign_id");

                entity.Property(e => e.PassportRuId).HasColumnName("passport_ru_id");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(256)
                    .HasColumnName("patronymic");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("character varying")
                    .HasColumnName("phone_number");

                entity.Property(e => e.Snils)
                    .HasColumnType("character varying")
                    .HasColumnName("snils");

                entity.Property(e => e.Surname)
                    .HasMaxLength(256)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("address_fkey");

                entity.HasOne(d => d.BirthCertificateForeign)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.BirthCertificateForeignId)
                    .HasConstraintName("birth_foreign_fkey");

                entity.HasOne(d => d.BirthCertificateRu)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.BirthCertificateRuId)
                    .HasConstraintName("birth_ru_fkey");

                entity.HasOne(d => d.PassportForeign)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.PassportForeignId)
                    .HasConstraintName("passport_foreign_fkey");

                entity.HasOne(d => d.PassportRu)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.PassportRuId)
                    .HasConstraintName("passport_ru_fkey");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("feature");

                entity.Property(e => e.FeatureId)
                    .HasColumnName("feature_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CampId).HasColumnName("camp_id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.HasOne(d => d.Camp)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.CampId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("camp_id");
            });

            modelBuilder.Entity<LocalAdministrator>(entity =>
            {
                entity.ToTable("local_administrator");

                entity.HasIndex(e => e.LocalAdministratorId, "fki_id_local_admin_fkey");

                entity.HasIndex(e => e.LocalAdministratorId, "fki_local_administrator_id");

                entity.Property(e => e.LocalAdministratorId).HasColumnName("local_administrator_id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Patronomyc)
                    .HasColumnType("character varying")
                    .HasColumnName("patronomyc");

                entity.Property(e => e.Surname)
                    .HasColumnType("character varying")
                    .HasColumnName("surname");

                entity.HasOne(d => d.LocalAdministratorNavigation)
                    .WithOne(p => p.LocalAdministrator)
                    .HasForeignKey<LocalAdministrator>(d => d.LocalAdministratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("local_administrator_fkey");

                entity.HasMany(d => d.IdCamps)
                    .WithMany(p => p.IdLocalAdmins)
                    .UsingEntity<Dictionary<string, object>>(
                        "LocalAdministratorCamp",
                        l => l.HasOne<Camp>().WithMany().HasForeignKey("IdCamp").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("camp_fkey"),
                        r => r.HasOne<LocalAdministrator>().WithMany().HasForeignKey("IdLocalAdmin").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("local_admin_fkey"),
                        j =>
                        {
                            j.HasKey("IdLocalAdmin", "IdCamp").HasName("local_administrator_camp_pkey");

                            j.ToTable("local_administrator_camp");

                            j.IndexerProperty<string>("IdLocalAdmin").HasColumnName("id_local_admin");

                            j.IndexerProperty<int>("IdCamp").HasColumnName("id_camp");
                        });
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("parent");

                entity.HasIndex(e => e.AddressId, "fki_address_fkey");

                entity.HasIndex(e => e.PassportForeignId, "fki_passport_foreign_fkey");

                entity.HasIndex(e => e.PassportRuId, "fki_passport_ru_fkey");

                entity.HasIndex(e => e.StatusId, "fki_status_fkey");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.PassportForeignId).HasColumnName("passport_foreign_id");

                entity.Property(e => e.PassportRuId).HasColumnName("passport_ru_id");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(256)
                    .HasColumnName("patronymic");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("character varying")
                    .HasColumnName("phone_number");

                entity.Property(e => e.Snils)
                    .HasColumnType("character varying")
                    .HasColumnName("snils");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Surname)
                    .HasMaxLength(256)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("address_fkey");

                entity.HasOne(d => d.ParentNavigation)
                    .WithOne(p => p.Parent)
                    .HasForeignKey<Parent>(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("parent_id_fkey");

                entity.HasOne(d => d.PassportForeign)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.PassportForeignId)
                    .HasConstraintName("passport_foreign_fkey");

                entity.HasOne(d => d.PassportRu)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.PassportRuId)
                    .HasConstraintName("passport_ru_fkey");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("status_fkey");

                entity.HasMany(d => d.Children)
                    .WithMany(p => p.Parents)
                    .UsingEntity<Dictionary<string, object>>(
                        "ParentChild",
                        l => l.HasOne<Child>().WithMany().HasForeignKey("ChildId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("child_fkey"),
                        r => r.HasOne<Parent>().WithMany().HasForeignKey("ParentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("parent_fkey"),
                        j =>
                        {
                            j.HasKey("ParentId", "ChildId").HasName("parent_child_pkey");

                            j.ToTable("parent_child");

                            j.IndexerProperty<string>("ParentId").HasColumnName("parent_id");

                            j.IndexerProperty<int>("ChildId").HasColumnName("child_id");
                        });
            });

            modelBuilder.Entity<PassportForeign>(entity =>
            {
                entity.HasKey(e => e.PassportId)
                    .HasName("passport_foreign_pkey");

                entity.ToTable("passport_foreign");

                entity.Property(e => e.PassportId)
                    .HasColumnName("passport_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.DateOfIssue).HasColumnName("date_of_issue");

                entity.Property(e => e.IssuedBy)
                    .HasColumnType("character varying")
                    .HasColumnName("issued_by");

                entity.Property(e => e.Number)
                    .HasColumnType("character varying")
                    .HasColumnName("number");

                entity.Property(e => e.Series)
                    .HasColumnType("character varying")
                    .HasColumnName("series");

                entity.Property(e => e.Validity).HasColumnName("validity");
            });

            modelBuilder.Entity<PassportRu>(entity =>
            {
                entity.HasKey(e => e.PassportId)
                    .HasName("passport_ru_pkey");

                entity.ToTable("passport_ru");

                entity.Property(e => e.PassportId)
                    .HasColumnName("passport_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.DateOfIssue).HasColumnName("date_of_issue");

                entity.Property(e => e.IssuedBy)
                    .HasColumnType("character varying")
                    .HasColumnName("issued_by");

                entity.Property(e => e.Number)
                    .HasMaxLength(6)
                    .HasColumnName("number");

                entity.Property(e => e.Series)
                    .HasMaxLength(4)
                    .HasColumnName("series");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("shift");

                entity.HasIndex(e => e.CampId, "fki_camp_fkey");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shift_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CampId).HasColumnName("camp_id");

                entity.Property(e => e.DateEnd).HasColumnName("date_end");

                entity.Property(e => e.DateStart).HasColumnName("date_start");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.HasOne(d => d.Camp)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.CampId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("camp_fkey");
            });

            modelBuilder.Entity<ShiftByShiftType>(entity =>
            {
                entity.ToTable("shift_by_shift_type");

                entity.Property(e => e.ShiftByShiftTypeId)
                    .HasColumnName("shift_by_shift_type_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.ShiftId).HasColumnName("shift_id");

                entity.Property(e => e.ShiftTypeId).HasColumnName("shift_type_id");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.ShiftByShiftTypes)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("shift_id");

                entity.HasOne(d => d.ShiftType)
                    .WithMany(p => p.ShiftByShiftTypes)
                    .HasForeignKey(d => d.ShiftTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("shift_type_fkey");
            });

            modelBuilder.Entity<ShiftRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("shift_request_pkey");

                entity.ToTable("shift_request");

                entity.HasIndex(e => e.ChildId, "fki_child_fkey");

                entity.HasIndex(e => e.ParentId, "fki_parent_fkey");

                entity.HasIndex(e => e.ShiftByShiftTypeId, "fki_shift_by_shift_type");

                entity.Property(e => e.RequestId)
                    .HasColumnName("request_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ChildId).HasColumnName("child_id");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.ShiftByShiftTypeId).HasColumnName("shift_by_shift_type_id");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.ShiftRequests)
                    .HasForeignKey(d => d.ChildId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("child_fkey");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.ShiftRequests)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("parent_fkey");

                entity.HasOne(d => d.ShiftByShiftType)
                    .WithMany(p => p.ShiftRequests)
                    .HasForeignKey(d => d.ShiftByShiftTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("shift_by_shift_type");
            });

            modelBuilder.Entity<ShiftType>(entity =>
            {
                entity.ToTable("shift_type");

                entity.Property(e => e.ShiftTypeId)
                    .HasColumnName("shift_type_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<SuperAdministrator>(entity =>
            {
                entity.ToTable("super_administrator");

                entity.HasIndex(e => e.SuperAdministratorId, "fki_super_administrator_fkey");

                entity.Property(e => e.SuperAdministratorId).HasColumnName("super_administrator_id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Patronomyc)
                    .HasColumnType("character varying")
                    .HasColumnName("patronomyc");

                entity.Property(e => e.Surname)
                    .HasColumnType("character varying")
                    .HasColumnName("surname");

                entity.HasOne(d => d.SuperAdministratorNavigation)
                    .WithOne(p => p.SuperAdministrator)
                    .HasForeignKey<SuperAdministrator>(d => d.SuperAdministratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("super_administrator_fkey");
            });

            modelBuilder.Entity<WorkingMode>(entity =>
            {
                entity.ToTable("working_mode");

                entity.Property(e => e.WorkingModeId)
                    .HasColumnName("working_mode_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.FridayEnd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("friday_end");

                entity.Property(e => e.FridayStart)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("friday_start");

                entity.Property(e => e.MondayEnd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("monday_end");

                entity.Property(e => e.MondayStart)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("monday_start");

                entity.Property(e => e.SaturdayEnd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("saturday_end");

                entity.Property(e => e.SaturdayStart)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("saturday_start");

                entity.Property(e => e.SundayEnd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("sunday_end");

                entity.Property(e => e.SundayStart)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("sunday_start");

                entity.Property(e => e.ThursdayEnd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("thursday_end");

                entity.Property(e => e.ThursdayStart)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("thursday_start");

                entity.Property(e => e.TuesdayEnd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("tuesday_end");

                entity.Property(e => e.TuesdayStart)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("tuesday_start");

                entity.Property(e => e.WednesdayEnd)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("wednesday_end");

                entity.Property(e => e.WednesdayStart)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("wednesday_start");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
