using Microsoft.EntityFrameworkCore;

namespace gmp.DomainModels.Entities
{
    public partial class gmpContext : DbContext
    {
        public gmpContext(DbContextOptions<gmpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<AttendanceEventActivityType> AttendanceEventActivityType { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventActivity> EventActivity { get; set; }
        public virtual DbSet<EventActivityType> EventActivityType { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<FeeSchedule> FeeSchedule { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberEventActivity> MemberEventActivity { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<SchoolLocation> SchoolLocation { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=(local);Database=gmp;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendance_Event");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendance_Member");
            });

            modelBuilder.Entity<AttendanceEventActivityType>(entity =>
            {
                entity.HasOne(d => d.Attendance)
                    .WithMany(p => p.AttendanceEventActivityType)
                    .HasForeignKey(d => d.AttendanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttendanceEventActivityType_Attendance");

                entity.HasOne(d => d.EventActivityType)
                    .WithMany(p => p.AttendanceEventActivityType)
                    .HasForeignKey(d => d.EventActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttendanceEventActivityType_EventActivityType");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Phone1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Prefix)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Suffix)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_Role1");

                entity.HasOne(d => d.SchoolLocation)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.SchoolLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_SchoolLocation");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EventEndDate).HasColumnType("datetime");

                entity.Property(e => e.EventStartDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_EventType");
            });

            modelBuilder.Entity<EventActivity>(entity =>
            {
                entity.HasOne(d => d.EventActivityType)
                    .WithMany(p => p.EventActivity)
                    .HasForeignKey(d => d.EventActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventActivity_EventActivityType");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventActivity)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventActivity_Event");
            });

            modelBuilder.Entity<EventActivityType>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FeeSchedule>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountAmount)
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DiscountPercent)
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.FeeSchedule)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeeSchedule_Program");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Levels)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Level_School");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_Role");

                entity.HasIndex(e => e.SchoolLocationId)
                    .HasName("IX_SchoolLocation");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Prefix)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Suffix)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FeeSchedule)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.FeeScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Member_FeeSchedule");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Member_Level");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Member_Role");

                entity.HasOne(d => d.SchoolLocation)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.SchoolLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Member_SchoolLocation");

            });

            modelBuilder.Entity<MemberEventActivity>(entity =>
            {
                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Result)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.EventActivity)
                    .WithMany(p => p.MemberEventActivity)
                    .HasForeignKey(d => d.EventActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberEventActivity_EventActivity");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberEventActivity)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberEventActivity_Member");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Notes)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Payment_Member");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_TransactionType");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.Property(e => e.BaseFee).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Program_School");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.EventActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registration_EventActivity");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registration_Member");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Registration_Payment");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_School");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SchoolLocation>(entity =>
            {
                entity.HasIndex(e => e.SchoolId)
                    .HasName("IX_School");

                entity.Property(e => e.Address1)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StateCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.School)
                    .WithMany(p => p.SchoolLocations)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchoolLocation_School");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
