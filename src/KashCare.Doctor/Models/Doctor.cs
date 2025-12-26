using System;
using System.Collections.Generic;

namespace KashCare.DoctorPatient.Models;

public partial class Doctor
{
    public int Doctorid { get; set; }

    public int Userid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int Departmentid { get; set; }

    public string? Registrationno { get; set; }

    public int? Experienceyears { get; set; }

    public decimal? Consultationfee { get; set; }

    public bool? Isactive { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Doctorclinic> Doctorclinics { get; set; } = new List<Doctorclinic>();

    public virtual ICollection<Doctorclinicschedule> Doctorclinicschedules { get; set; } = new List<Doctorclinicschedule>();

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
