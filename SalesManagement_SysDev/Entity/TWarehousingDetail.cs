using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SalesManagement_SysDev;

public partial class TWarehousingDetail
{
    public int WaDetailId { get; set; }

    public int WaId { get; set; }

    public int PrId { get; set; }

    public int WaQuantity { get; set; }

    public virtual MProduct Pr { get; set; } = null!;

    public virtual TWarehousing Wa { get; set; } = null!;
}
internal class TWarehousingDetailDsp
{
    [DisplayName("入庫詳細ID")]
    public int WaDetailId { get; set; }
    [DisplayName("入庫ID")]
    public int WaId { get; set; }
    [DisplayName("商品ID")]
    public int PrId { get; set; }
    [DisplayName("商品名")]
    public string PrName { get; set; }
    [DisplayName("数量")]
    public int PrQuantity { get; set; }
}
