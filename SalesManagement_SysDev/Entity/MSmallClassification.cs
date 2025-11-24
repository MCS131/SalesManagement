using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class MSmallClassification
{
    public int ScId { get; set; }

    public int McId { get; set; }

    public string ScName { get; set; } = null!;

    public int ScFlag { get; set; }

    public string? ScHidden { get; set; }

    public virtual ICollection<MProduct> MProducts { get; set; } = new List<MProduct>();

    public virtual MMajorClassification Mc { get; set; } = null!;
}

internal class MSmallDsp
{
    [DisplayName("小分類ID")]
    public int SmallId { get; set; }
    [DisplayName("小分類名")]
    public string SmallName { get; set; }
    [DisplayName("大分類ID")]
    public int MajorId { get; set; }
    [DisplayName("大分類名")]
    public string MajorName { get; set;}
}