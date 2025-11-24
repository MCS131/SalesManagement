using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SalesManagement_SysDev;

public partial class TArrivalDetail
{
    public int ArDetailId { get; set; }

    public int? ArId { get; set; }

    public int? PrId { get; set; }

    public int? ArQuantity { get; set; }

    public virtual TArrival? Ar { get; set; }

    public virtual MProduct? Pr { get; set; }
}
internal class TArrivalDetailDsp
{
    [DisplayName("入荷詳細ID")]
    public int ArDetailId { get; set; }
    [DisplayName("入荷ID")]
    public int? ArId { get; set; }
    [DisplayName("商品ID")]
    public int? PrId { get; set; }
    [DisplayName("商品名")]
    public string PrName { get; set; }
    [DisplayName("数量")]
    public int? ArQuantity { get; set; }
}