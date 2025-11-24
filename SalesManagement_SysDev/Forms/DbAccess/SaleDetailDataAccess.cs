using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class SaleDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetSaleDetailData()
        //引　数   ：なし
        //戻り値   ：売上詳細データ
        //機　能   ：売上詳細データの取得
        ///////////////////////////////
        public List<TSaleDetail> GetSaleDetailData()
        {
            List<TSaleDetail> saledetail = null;
            try
            {
                var context = new SalesManagementContext();
                saledetail = context.TSaleDetails.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return saledetail;

        }

        ///////////////////////////////
        //メソッド名：GetSaleDetailDspData()
        //引　数   ：なし
        //戻り値   ：表示用売上詳細データ
        //機　能   ：表示用売上詳細データの取得
        ///////////////////////////////
        public List<TSaleDetailDsp> GetSaleDetailDspData()
        {
            List<TSaleDetailDsp> saledetail = new List<TSaleDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TSaleDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         select new
                         {
                             t1.SaDetailId,
                             t1.SaId,
                             t1.PrId,
                             t2.PrName,
                             t1.SaQuantity,
                             t1.SaPrTotalPrice
                         };
                foreach (var t in tb)
                {
                    saledetail.Add(new TSaleDetailDsp
                    {
                        SalesDetailID = t.SaDetailId,
                        SalesID = t.SaId,
                        ProductID = t.PrId,
                        ProductName = t.PrName,
                        SalesQuantity = t.SaQuantity,
                        SalesTotalPrice = t.SaPrTotalPrice
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return saledetail;
        }

        ///////////////////////////////
        //メソッド名：AddDetailData()
        //引　数   ：売上詳細情報データ
        //戻り値   ：True or False
        //機　能   ：売上詳細データの追加
        //          ：追加成功の場合True
        //          ：追加失敗の場合False
        ///////////////////////////////
        public bool AddSaleDetaiData(TSaleDetail regDetail)
        {
            try
            {
                var context = new SalesManagementContext();
                context.TSaleDetails.Add(regDetail);
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

        public List<TSaleDetailDsp> GetSaleDetailSelectData(int saleid)
        {
            List<TSaleDetailDsp> DspData = new List<TSaleDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TSaleDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         where t1.SaId == saleid
                         select new
                         {
                             t1.SaDetailId,
                             t1.SaId,
                             t1.PrId,
                             t2.PrName,
                             t1.SaQuantity,
                             t1.SaPrTotalPrice
                         };
                foreach (var t in tb)
                {
                    DspData.Add(new TSaleDetailDsp
                    {
                        SalesDetailID = t.SaDetailId,
                        SalesID = t.SaId,
                        ProductID = t.PrId,
                        ProductName = t.PrName,
                        SalesQuantity = t.SaQuantity,
                        SalesTotalPrice = t.SaPrTotalPrice
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
