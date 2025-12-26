using System;
using System.Collections.Generic;

namespace KashCare.DoctorPatient.Models;

public partial class Appointment
{
    public int Appointmentid { get; set; }

    public int Doctorid { get; set; }

    public int Clinicid { get; set; }

    public int Patientid { get; set; }

    public int? Slotid { get; set; }

    public DateTime Appointmentdate { get; set; }

    public string Status { get; set; } = null!;

    public string? Reason { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Clinic Clinic { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Slot? Slot { get; set; }
}
