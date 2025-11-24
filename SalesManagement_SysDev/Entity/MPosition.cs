using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class MPosition
{
    public int PoId { get; set; }

    public string PoName { get; set; } = null!;

    public int PoFlag { get; set; }

    public string? PoHidden { get; set; }

    public virtual ICollection<MEmployee> MEmployees { get; set; } = new List<MEmployee>();
}

internal class MPositionDsp
{
    [DisplayName("役職ID")]
    public int PoId { get; set; }
    [DisplayName("役職名")]
    public string PoName { get; set; }
    [DisplayName("役職管理フラグ")]
    public int PoFlag { get; set; }
    [DisplayName("非表示理由")]
    public string PoHidden { get; set; }
}
