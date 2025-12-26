using System;
using System.Collections.Generic;

namespace KashCare.DoctorPatient.Models;

public partial class Patienthistory
{
    public int Historyid { get; set; }

    public int Patientid { get; set; }

    public string? Symptoms { get; set; }

    public string? Allergies { get; set; }

    public string? Chronicdiseases { get; set; }

    public string? Currentmeds { get; set; }

    public DateTime? Updatedat { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
