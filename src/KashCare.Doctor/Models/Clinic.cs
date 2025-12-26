using System;
using System.Collections.Generic;

namespace KashCare.DoctorPatient.Models;

public partial class Clinic
{
    public int Clinicid { get; set; }

    public string Name { get; set; } = null!;

    public int Cityid { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public bool? Isactive { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Doctorclinic> Doctorclinics { get; set; } = new List<Doctorclinic>();

    public virtual ICollection<Doctorclinicschedule> Doctorclinicschedules { get; set; } = new List<Doctorclinicschedule>();

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
