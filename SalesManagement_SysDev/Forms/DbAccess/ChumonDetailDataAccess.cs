using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class ChumonDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetChumonDetailData()
        //引　数   ：なし
        //戻り値   ：注文詳細データ
        //機　能   ：注文詳細データの取得
        ///////////////////////////////
        public List<TChumonDetail> GetChumonDetailData()
        {
            List<TChumonDetail> chumondetail = null;
            try
            {
                var context = new SalesManagementContext();
                chumondetail = context.TChumonDetails.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return chumondetail;

        }

        ///////////////////////////////
        //メソッド名：GetChumonDetailDspData()
        //引　数   ：なし
        //戻り値   ：表示用注文詳細データ
        //機　能   ：表示用注文詳細データの取得
        ///////////////////////////////
        public List<TChumonDetailDsp> GetChumonDetailDspData()
        {
            List<TChumonDetailDsp> chumondetail = new List<TChumonDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TChumonDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         select new
                         {
                             t1.ChDetailId,
                             t1.ChId,
                             t1.PrId,
                             t2.PrName,
                             t1.ChQuantity,
                         };
                foreach (var t in tb)
                {
                    chumondetail.Add(new TChumonDetailDsp
                    {
                        ChDetailId = t.ChDetailId,
                        ChId = t.ChId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        ChQuantity = t.ChQuantity,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return chumondetail;
        }
        public List<TChumonDetailDsp> GetChumonDetailSelectData(int chumonid)
        {
            List<TChumonDetailDsp> DspData = new List<TChumonDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TChumonDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         where t1.ChId == chumonid
                         select new
                         {
                             t1.ChDetailId,
                             t1.ChId,
                             t1.PrId,
                             t2.PrName,
                             t1.ChQuantity,
                         };
                foreach (var t in tb)
                {
                    DspData.Add(new TChumonDetailDsp
                    {
                        ChDetailId = t.ChDetailId,
                        ChId = t.ChId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        ChQuantity = t.ChQuantity,
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
