using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class TOrder
{
    public int OrId { get; set; }

    public int SoId { get; set; }

    public int EmId { get; set; }

    public int ClId { get; set; }

    public string ClCharge { get; set; } = null!;

    public DateTime OrDate { get; set; }

    public int? OrStateFlag { get; set; }

    public int OrFlag { get; set; }

    public string? OrHidden { get; set; }

    public virtual MClient Cl { get; set; } = null!;

    public virtual MEmployee Em { get; set; } = null!;

    public virtual MSalesOffice So { get; set; } = null!;

    public virtual ICollection<TArrival> TArrivals { get; set; } = new List<TArrival>();

    public virtual ICollection<TChumon> TChumons { get; set; } = new List<TChumon>();

    public virtual ICollection<TOrderDetail> TOrderDetails { get; set; } = new List<TOrderDetail>();

    public virtual ICollection<TShipment> TShipments { get; set; } = new List<TShipment>();

    public virtual ICollection<TSyukko> TSyukkos { get; set; } = new List<TSyukko>();

    public virtual ICollection<TSale> TSales { get; set; } = new List<TSale>();
}
internal class TOrderDsp
{
    [DisplayName("受注ID")]
    public int OrderId { get; set; }
    [DisplayName("営業所ID")]
    public int SalesOfficeID { get; set; }
    [DisplayName("営業所名")]
    public string SalesOfficeName { get; set; }
    [DisplayName("社員ID")]
    public int EmpId { get; set; }
    [DisplayName("社員名")]
    public string EmpName { get; set; }
    [DisplayName("顧客ID")]
    public int ClID { get; set; }
    [DisplayName("顧客名")]
    public string ClName { get; set; }
    [DisplayName("顧客担当者名")]
    public string ClCharge { get; set; }
    [DisplayName("受注年月日")]
    public string OrDate { get; set; }
    [DisplayName("受注状態フラグ")]
    public string OrStateFlag { get; set; }
    [DisplayName("受注管理フラグ")]
    public string OrFlag { get; set; }
    [DisplayName("非表示理由")]
    public string OrHidden { get; set;}
}
