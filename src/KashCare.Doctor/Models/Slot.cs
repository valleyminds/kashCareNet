using System;
using System.Collections.Generic;

namespace KashCare.DoctorPatient.Models;

public partial class Slot
{
    public int Slotid { get; set; }

    public int Doctorid { get; set; }

    public int Clinicid { get; set; }

    public DateOnly Slotdate { get; set; }

    public TimeOnly Slottime { get; set; }

    public int Durationmins { get; set; }

    public int Maxcapacity { get; set; }

    public int Bookedcount { get; set; }

    public bool Isavailable { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Clinic Clinic { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;
}
