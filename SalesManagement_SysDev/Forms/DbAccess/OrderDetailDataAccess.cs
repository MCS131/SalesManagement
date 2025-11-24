using SalesManagement_SysDev.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class OrderDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetOrderDetailData()
        //引　数   ：なし
        //戻り値   ：受注詳細データ
        //機　能   ：受注詳細データの取得
        ///////////////////////////////
        public List<TOrderDetail> GetOrderDetailData()
        {
            List<TOrderDetail> orderdetail = null;
            try
            {
                var context = new SalesManagementContext();
                orderdetail = context.TOrderDetails.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return orderdetail;

        }

        ///////////////////////////////
        //メソッド名：GetOrderDetailDspData()
        //引　数   ：なし
        //戻り値   ：表示用発注詳細データ
        //機　能   ：表示用発注詳細データの取得
        ///////////////////////////////
        public List<TOrderDetailDsp> GetOrderDetailDspData()
        {
            List<TOrderDetailDsp> orderdetail = new List<TOrderDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TOrderDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         select new
                         {
                             t1.OrDetailId,
                             t1.OrId,
                             t1.PrId,
                             t2.PrName,
                             t1.OrQuantity,
                             t1.OrTotalPrice
                         };
                foreach ( var t in tb )
                {
                    orderdetail.Add(new TOrderDetailDsp
                    {
                        OrDetailId = t.OrDetailId,
                        OrId = t.OrId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        OrQuantity = t.OrQuantity,
                        OrTotalPrice = t.OrTotalPrice
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return orderdetail;
        }
        ///////////////////////////////
        //メソッド名：AddDetailData()
        //引　数   ：受注詳細情報データ
        //戻り値   ：True or False
        //機　能   ：受注詳細データの追加
        //          ：追加成功の場合True
        //          ：追加失敗の場合False
        ///////////////////////////////
        public bool AddDetailData(TOrderDetail regDetail)
        {
            try
            {
                var context = new SalesManagementContext();
                context.TOrderDetails.Add(regDetail);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public List<TOrderDetailDsp> GetOrderDetailSelectData(int orderid)
        {
            List<TOrderDetailDsp> DspData = new List<TOrderDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TOrderDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         where t1.OrId == orderid
                         select new
                         {
                             t1.OrDetailId,
                             t1.OrId,
                             t1.PrId,
                             t2.PrName,
                             t1.OrQuantity,
                             t1.OrTotalPrice
                         };
                foreach (var t in tb)
                {
                    DspData.Add(new TOrderDetailDsp
                    {
                        OrDetailId = t.OrDetailId,
                        OrId = t.OrId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        OrQuantity = t.OrQuantity,
                        OrTotalPrice = t.OrTotalPrice
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return DspData;
        }
    }
}
