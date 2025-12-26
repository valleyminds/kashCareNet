using System;
using System.Collections.Generic;

namespace KashCare.DoctorPatient.Models;

public partial class Doctorclinicschedule
{
    public int Scheduleid { get; set; }

    public int Doctorid { get; set; }

    public int Clinicid { get; set; }

    public short Dayofweek { get; set; }

    public TimeOnly Starttime { get; set; }

    public TimeOnly Endtime { get; set; }

    public int Slotduration { get; set; }

    public int Maxpatients { get; set; }

    public bool? Isactive { get; set; }

    public virtual Clinic Clinic { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;
}
