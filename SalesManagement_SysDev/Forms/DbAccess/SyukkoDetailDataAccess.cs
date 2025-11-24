using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class SyukkoDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetSyukkoDetailData()
        //引　数   ：なし
        //戻り値   ：出庫詳細データ
        //機　能   ：出庫詳細データの取得
        ///////////////////////////////
        public List<TSyukkoDetailDsp> GetSyukkoDetailData()
        {
            List<TSyukkoDetailDsp> syukkodetail = new List<TSyukkoDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TSyukkoDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         select new
                         {
                             t1.SyDetailId,
                             t1.SyId,
                             t1.PrId,
                             t2.PrName,
                             t1.SyQuantity,
                         };
                foreach (var t in tb)
                {
                    syukkodetail.Add(new TSyukkoDetailDsp
                    {
                        SyDetailId = t.SyDetailId,
                        SyId = t.SyId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        PrNum = t.SyQuantity,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return syukkodetail;

        }

        ///////////////////////////////
        //メソッド名：GetSyukkoDetailDspData()
        //引　数   ：なし
        //戻り値   ：表示用出庫詳細データ
        //機　能   ：表示用出庫詳細データの取得
        ///////////////////////////////
        public List<TSyukkoDetail> GetSyukkoDetailDspData()
        {
            List<TSyukkoDetail> syukkodetail = null;
            try
            {
                var context = new SalesManagementContext();
                syukkodetail = context.TSyukkoDetails.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return syukkodetail;
        }
        public List<TSyukkoDetailDsp> GetSyukkoDetailSelectData(int syukkoid)
        {
            List<TSyukkoDetailDsp> DspData = new List<TSyukkoDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TSyukkoDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         where t1.SyId == syukkoid
                         select new
                         {
                             t1.SyDetailId,
                             t1.SyId,
                             t1.PrId,
                             t2.PrName,
                             t1.SyQuantity,
                         };
                foreach (var t in tb)
                {
                    DspData.Add(new TSyukkoDetailDsp
                    {
                        SyDetailId = t.SyDetailId,
                        SyId = t.SyId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        PrNum = t.SyQuantity,
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
