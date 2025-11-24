using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SalesManagement_SysDev;

public partial class THattyuDetail
{
    public int HaDetailId { get; set; }

    public int HaId { get; set; }

    public int PrId { get; set; }

    public int HaQuantity { get; set; }

    public virtual THattyu Ha { get; set; } = null!;

    public virtual MProduct Pr { get; set; } = null!;
}
internal class THattyuDetailDsp
{
    [DisplayName("発注詳細ID")]
    public int HaDetailId { get; set; }
    [DisplayName("発注ID")]
    public int HaId { get; set;}
    [DisplayName("商品ID")]
    public int PrId { get; set;}
    [DisplayName("商品名")]
    public string PrName { get; set; }
    [DisplayName("数量")]
    public int HaQuantity { get; set;}
}
