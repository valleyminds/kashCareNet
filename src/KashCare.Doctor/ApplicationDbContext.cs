using System;
using System.Collections.Generic;
using KashCare.DoctorPatient.Models;
using Microsoft.EntityFrameworkCore;

namespace KashCare.DoctorPatient;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Doctorclinic> Doctorclinics { get; set; }

    public virtual DbSet<Doctorclinicschedule> Doctorclinicschedules { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Patientfile> Patientfiles { get; set; }

    public virtual DbSet<Patienthistory> Patienthistories { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost:54320;Database=Kashkartptdoc;Username=postgres;Password=Shakeel@99");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Appointmentid).HasName("appointments_pkey");

            entity.ToTable("appointments", "shared");

            entity.Property(e => e.Appointmentid).HasColumnName("appointmentid");
            entity.Property(e => e.Appointmentdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("appointmentdate");
            entity.Property(e => e.Clinicid).HasColumnName("clinicid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Doctorid).HasColumnName("doctorid");
            entity.Property(e => e.Patientid).HasColumnName("patientid");
            entity.Property(e => e.Reason)
                .HasMaxLength(500)
                .HasColumnName("reason");
            entity.Property(e => e.Slotid).HasColumnName("slotid");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Scheduled'::character varying")
                .HasColumnName("status");

            entity.HasOne(d => d.Clinic).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Clinicid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointments_clinicid_fkey");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Doctorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointments_doctorid_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Patientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointments_patientid_fkey");

            entity.HasOne(d => d.Slot).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Slotid)
                .HasConstraintName("appointments_slotid_fkey");
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.HasKey(e => e.Clinicid).HasName("clinics_pkey");

            entity.ToTable("clinics", "doctor");

            entity.Property(e => e.Clinicid).HasColumnName("clinicid");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Cityid).HasColumnName("cityid");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Departmentid).HasName("departments_pkey");

            entity.ToTable("departments", "doctor");

            entity.HasIndex(e => e.Name, "departments_name_key").IsUnique();

            entity.Property(e => e.Departmentid).HasColumnName("departmentid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Doctorid).HasName("doctors_pkey");

            entity.ToTable("doctors", "doctor");

            entity.HasIndex(e => e.Registrationno, "doctors_registrationno_key").IsUnique();

            entity.HasIndex(e => e.Userid, "doctors_userid_key").IsUnique();

            entity.Property(e => e.Doctorid).HasColumnName("doctorid");
            entity.Property(e => e.Consultationfee)
                .HasPrecision(10, 2)
                .HasDefaultValue(0m)
                .HasColumnName("consultationfee");
            entity.Property(e => e.Departmentid).HasColumnName("departmentid");
            entity.Property(e => e.Experienceyears).HasColumnName("experienceyears");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Registrationno)
                .HasMaxLength(50)
                .HasColumnName("registrationno");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Department).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.Departmentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("doctors_departmentid_fkey");
        });

        modelBuilder.Entity<Doctorclinic>(entity =>
        {
            entity.HasKey(e => new { e.Doctorid, e.Clinicid }).HasName("doctorclinics_pkey");

            entity.ToTable("doctorclinics", "doctor");

            entity.Property(e => e.Doctorid).HasColumnName("doctorid");
            entity.Property(e => e.Clinicid).HasColumnName("clinicid");
            entity.Property(e => e.Fee)
                .HasPrecision(10, 2)
                .HasColumnName("fee");
            entity.Property(e => e.Isprimary)
                .HasDefaultValue(false)
                .HasColumnName("isprimary");

            entity.HasOne(d => d.Clinic).WithMany(p => p.Doctorclinics)
                .HasForeignKey(d => d.Clinicid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("doctorclinics_clinicid_fkey");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Doctorclinics)
                .HasForeignKey(d => d.Doctorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("doctorclinics_doctorid_fkey");
        });

        modelBuilder.Entity<Doctorclinicschedule>(entity =>
        {
            entity.HasKey(e => e.Scheduleid).HasName("doctorclinicschedules_pkey");

            entity.ToTable("doctorclinicschedules", "doctor");

            entity.HasIndex(e => new { e.Doctorid, e.Clinicid, e.Dayofweek }, "doctorclinicschedules_doctorid_clinicid_dayofweek_key").IsUnique();

            entity.Property(e => e.Scheduleid).HasColumnName("scheduleid");
            entity.Property(e => e.Clinicid).HasColumnName("clinicid");
            entity.Property(e => e.Dayofweek).HasColumnName("dayofweek");
            entity.Property(e => e.Doctorid).HasColumnName("doctorid");
            entity.Property(e => e.Endtime).HasColumnName("endtime");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Maxpatients)
                .HasDefaultValue(1)
                .HasColumnName("maxpatients");
            entity.Property(e => e.Slotduration)
                .HasDefaultValue(30)
                .HasColumnName("slotduration");
            entity.Property(e => e.Starttime).HasColumnName("starttime");

            entity.HasOne(d => d.Clinic).WithMany(p => p.Doctorclinicschedules)
                .HasForeignKey(d => d.Clinicid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("doctorclinicschedules_clinicid_fkey");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Doctorclinicschedules)
                .HasForeignKey(d => d.Doctorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("doctorclinicschedules_doctorid_fkey");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Patientid).HasName("patients_pkey");

            entity.ToTable("patients", "patient");

            entity.HasIndex(e => e.Userid, "patients_userid_key").IsUnique();

            entity.Property(e => e.Patientid).HasColumnName("patientid");
            entity.Property(e => e.Bloodgroup)
                .HasMaxLength(5)
                .HasColumnName("bloodgroup");
            entity.Property(e => e.Cityid).HasColumnName("cityid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Dateofbirth).HasColumnName("dateofbirth");
            entity.Property(e => e.Emergencycontact)
                .HasMaxLength(20)
                .HasColumnName("emergencycontact");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .HasColumnName("gender");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Patientfile>(entity =>
        {
            entity.HasKey(e => e.Fileid).HasName("patientfiles_pkey");

            entity.ToTable("patientfiles", "patient");

            entity.Property(e => e.Fileid).HasColumnName("fileid");
            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .HasColumnName("filename");
            entity.Property(e => e.Filepath)
                .HasMaxLength(500)
                .HasColumnName("filepath");
            entity.Property(e => e.Filetype)
                .HasMaxLength(50)
                .HasColumnName("filetype");
            entity.Property(e => e.Patientid).HasColumnName("patientid");
            entity.Property(e => e.Uploadedat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("uploadedat");

            entity.HasOne(d => d.Patient).WithMany(p => p.Patientfiles)
                .HasForeignKey(d => d.Patientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("patientfiles_patientid_fkey");
        });

        modelBuilder.Entity<Patienthistory>(entity =>
        {
            entity.HasKey(e => e.Historyid).HasName("patienthistories_pkey");

            entity.ToTable("patienthistories", "patient");

            entity.Property(e => e.Historyid).HasColumnName("historyid");
            entity.Property(e => e.Allergies)
                .HasColumnType("jsonb")
                .HasColumnName("allergies");
            entity.Property(e => e.Chronicdiseases)
                .HasColumnType("jsonb")
                .HasColumnName("chronicdiseases");
            entity.Property(e => e.Currentmeds)
                .HasColumnType("jsonb")
                .HasColumnName("currentmeds");
            entity.Property(e => e.Patientid).HasColumnName("patientid");
            entity.Property(e => e.Symptoms)
                .HasColumnType("jsonb")
                .HasColumnName("symptoms");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");

            entity.HasOne(d => d.Patient).WithMany(p => p.Patienthistories)
                .HasForeignKey(d => d.Patientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("patienthistories_patientid_fkey");
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.HasKey(e => e.Slotid).HasName("slots_pkey");

            entity.ToTable("slots", "doctor");

            entity.HasIndex(e => new { e.Doctorid, e.Clinicid, e.Slotdate, e.Slottime }, "slots_doctorid_clinicid_slotdate_slottime_key").IsUnique();

            entity.Property(e => e.Slotid).HasColumnName("slotid");
            entity.Property(e => e.Bookedcount).HasColumnName("bookedcount");
            entity.Property(e => e.Clinicid).HasColumnName("clinicid");
            entity.Property(e => e.Doctorid).HasColumnName("doctorid");
            entity.Property(e => e.Durationmins)
                .HasDefaultValue(30)
                .HasColumnName("durationmins");
            entity.Property(e => e.Isavailable)
                .HasDefaultValue(true)
                .HasColumnName("isavailable");
            entity.Property(e => e.Maxcapacity)
                .HasDefaultValue(1)
                .HasColumnName("maxcapacity");
            entity.Property(e => e.Slotdate).HasColumnName("slotdate");
            entity.Property(e => e.Slottime).HasColumnName("slottime");

            entity.HasOne(d => d.Clinic).WithMany(p => p.Slots)
                .HasForeignKey(d => d.Clinicid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("slots_clinicid_fkey");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Slots)
                .HasForeignKey(d => d.Doctorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("slots_doctorid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
