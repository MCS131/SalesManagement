using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesManagement_SysDev;

public partial class MSalesOffice
{
    public int SoId { get; set; }

    public string SoName { get; set; } = null!;

    public string SoAddress { get; set; } = null!;

    public string SoPhone { get; set; } = null!;

    public string SoPostal { get; set; } = null!;

    public string SoFax { get; set; } = null!;

    public int SoFlag { get; set; }

    public string? SoHidden { get; set; }

    public virtual ICollection<MClient> MClients { get; set; } = new List<MClient>();

    public virtual ICollection<MEmployee> MEmployees { get; set; } = new List<MEmployee>();

    public virtual ICollection<TArrival> TArrivals { get; set; } = new List<TArrival>();

    public virtual ICollection<TChumon> TChumons { get; set; } = new List<TChumon>();

    public virtual ICollection<TOrder> TOrders { get; set; } = new List<TOrder>();

    public virtual ICollection<TSale> TSales { get; set; } = new List<TSale>();

    public virtual ICollection<TShipment> TShipments { get; set; } = new List<TShipment>();

    public virtual ICollection<TSyukko> TSyukkos { get; set; } = new List<TSyukko>();
}
internal class MSalesOfficeDsp
{
    [DisplayName("営業所ID")]
    public int SaleId { get; set; }
    [DisplayName("営業所名")]
    public string SaleName { get; set; }
    [DisplayName("住所")]
    public string SaleAddr { get; set; }
    [DisplayName("電話番号")]
    public string SalePhone { get; set; }
    [DisplayName("郵便番号")]
    public string SalePostal { get; set; }
    [DisplayName("FAX番号")]
    public string SaleFax { get; set;}
    [DisplayName("営業所管理フラグ")]
    public int SaleFlg { get; set; }
    [DisplayName("非表示理由")]
    public string SaleHidden { get; set; }
}
