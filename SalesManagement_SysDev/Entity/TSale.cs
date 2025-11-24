using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class TSale
{
    public int SaId { get; set; }

    public int ClId { get; set; }

    public int SoId { get; set; }

    public int EmId { get; set; }

    public int OrId { get; set; }

    public DateTime SaDate { get; set; }

    public string? SaHidden { get; set; }

    public int SaFlag { get; set; }

    public virtual TOrder Or { get; set; } = null!;

    public virtual MClient Cl { get; set; } = null!;

    public virtual MEmployee Em { get; set; } = null!;

    public virtual MSalesOffice So { get; set; } = null!;

    public virtual ICollection<TSaleDetail> TSaleDetails { get; set; } = new List<TSaleDetail>();
}

internal class TSaleDsp
{
    [DisplayName("売上ID")]
    public int SalesID { get; set; }
    [DisplayName("顧客ID")]
    public int ClientID { get; set; }
    [DisplayName("顧客名")]
    public string ClName { get; set; }
    [DisplayName("営業所ID")]
    public int SalesOfficeID { get; set; }
    [DisplayName("営業所名")]
    public string SalesOfficeName { get; set; }
    [DisplayName("社員ID")]
    public int EmpID { get; set; }
    [DisplayName("社員名")]
    public string EmpName { get; set; }
    [DisplayName("受注ID")]
    public int JOrderID { get; set; }
    [DisplayName("売上日時")]
    public DateTime SaDate { get; set; }    
    [DisplayName("売上管理フラグ")]
    public int SalesFlag { get; set; }
    [DisplayName("売上非表示")]
    public string SalesHidden { get; set; }
}
