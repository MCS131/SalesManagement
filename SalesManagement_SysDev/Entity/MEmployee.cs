using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement_SysDev;

public partial class MEmployee
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int EmId { get; set; }

    public string EmName { get; set; } = null!;

    public int SoId { get; set; }

    public int PoId { get; set; }

    public DateTime EmHiredate { get; set; }

    public string EmPassword { get; set; } = null!;

    public string EmPhone { get; set; } = null!;

    public int EmFlag { get; set; }

    public string? EmHidden { get; set; }

    public virtual MPosition Po { get; set; } = null!;

    public virtual MSalesOffice So { get; set; } = null!;

    public virtual ICollection<TArrival> TArrivals { get; set; } = new List<TArrival>();

    public virtual ICollection<TChumon> TChumons { get; set; } = new List<TChumon>();

    public virtual ICollection<THattyu> THattyus { get; set; } = new List<THattyu>();

    public virtual ICollection<TOrder> TOrders { get; set; } = new List<TOrder>();

    public virtual ICollection<TSale> TSales { get; set; } = new List<TSale>();

    public virtual ICollection<TShipment> TShipments { get; set; } = new List<TShipment>();

    public virtual ICollection<TSyukko> TSyukkos { get; set; } = new List<TSyukko>();

    public virtual ICollection<TWarehousing> TWarehousings { get; set; } = new List<TWarehousing>();
}

internal class MEmployeeDsp
{
    [DisplayName("社員ID")]
    public int EmployeeId { get; set; }
    [DisplayName("社員名")]
    public string EmployeeName { get; set; }
    [DisplayName("営業所ID")]
    public int SalesOfficeID { get; set; }
    [DisplayName("営業所名")]
    public string SalesOfficeName { get; set; }
    [DisplayName("役職ID")]
    public int PositionID { get; set; }
    [DisplayName("役職名")]
    public string PositionName { get; set; }
    [DisplayName("入社年月日")]
    public string EmployeeHireDate { get; set; }
    [DisplayName("パスワード")]
    public string EmPassward { get; set; }
    [DisplayName("電話番号")]
    public string EmPhone { get; set; }
    [DisplayName("社員管理フラグ")]
    public int EmFlag { get; set; }
    [DisplayName("非表示理由")]
    public string EmHidden { get; set; }
}
