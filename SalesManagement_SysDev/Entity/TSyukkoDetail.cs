using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SalesManagement_SysDev;

public partial class TSyukkoDetail
{
    public int SyDetailId { get; set; }

    public int SyId { get; set; }

    public int PrId { get; set; }

    public int SyQuantity { get; set; }

    public virtual MProduct Pr { get; set; } = null!;

    public virtual TSyukko Sy { get; set; } = null!;
}
internal class TSyukkoDetailDsp
{
    [DisplayName("出庫詳細ID")]
    public int SyDetailId { get; set; }
    [DisplayName("出庫ID")]
    public int SyId { get; set; }
    [DisplayName("商品ID")]
    public int PrId { get; set; }
    [DisplayName("商品名")]
    public string PrName { get; set; }
    [DisplayName("数量")]
    public int PrNum { get; set; }
}