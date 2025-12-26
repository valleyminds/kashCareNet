using System;
using System.Collections.Generic;

namespace KashCare.DoctorPatient.Models;

public partial class Patientfile
{
    public int Fileid { get; set; }

    public int Patientid { get; set; }

    public string Filename { get; set; } = null!;

    public string Filepath { get; set; } = null!;

    public string Filetype { get; set; } = null!;

    public DateTime? Uploadedat { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
