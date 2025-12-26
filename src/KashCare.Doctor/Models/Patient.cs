using System;
using System.Collections.Generic;

namespace KashCare.DoctorPatient.Models;

public partial class Patient
{
    public int Patientid { get; set; }

    public int? Userid { get; set; }

    public string Firstname { get; set; } = null!;

    public string? Lastname { get; set; }

    public DateOnly? Dateofbirth { get; set; }

    public string? Gender { get; set; }

    public string? Bloodgroup { get; set; }

    public int? Cityid { get; set; }

    public string? Phone { get; set; }

    public string? Emergencycontact { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Patientfile> Patientfiles { get; set; } = new List<Patientfile>();

    public virtual ICollection<Patienthistory> Patienthistories { get; set; } = new List<Patienthistory>();
}
