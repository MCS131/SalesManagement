
using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class ArrivalDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetArrivalDetailData()
        //引　数   ：なし
        //戻り値   ：入荷詳細データ
        //機　能   ：入荷詳細データの取得
        ///////////////////////////////
        public List<TArrivalDetail> GetArrivalData()
        {
            List<TArrivalDetail> arrivaldetail = null;
            try
            {
                var context = new SalesManagementContext();
                arrivaldetail = context.TArrivalDetails.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return arrivaldetail;

        }

        ///////////////////////////////
        //メソッド名：GetArrivalDetailDspData()
        //引　数   ：なし
        //戻り値   ：表示用入荷詳細データ
        //機　能   ：表示用入荷詳細データの取得
        ///////////////////////////////
        public List<TArrivalDetail> GetArrivalDspData()
        {
            List<TArrivalDetail> arrivaldetail = null;
            try
            {
                var context = new SalesManagementContext();
                arrivaldetail = context.TArrivalDetails.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return arrivaldetail;
        }
        public List<TArrivalDetailDsp> GetArrivalDetailSelectData(int arrivalid)
        {
            List<TArrivalDetailDsp> DspData = new List<TArrivalDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TArrivalDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         where t1.ArId == arrivalid
                         select new
                         {
                             t1.ArDetailId,
                             t1.ArId,
                             t1.PrId,
                             t2.PrName,
                             t1.ArQuantity,
                         };
                foreach (var t in tb)
                {
                    DspData.Add(new TArrivalDetailDsp
                    {
                        ArDetailId = t.ArDetailId,
                        ArId = t.ArId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        ArQuantity = t.ArQuantity,
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
        ///////////////////////////////
        //メソッド名：GetArrivalDetailDspData()
        //引　数   ：なし
        //戻り値   ：表示用入荷詳細データ
        //機　能   ：表示用入荷詳細データの取得
        ///////////////////////////////
        public List<TArrivalDetailDsp> GetArrivalDetailDspData()
        {
            List<TArrivalDetailDsp> arrivaldetail = new List<TArrivalDetailDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.TArrivalDetails
                         join t2 in context.MProducts
                         on t1.PrId equals t2.PrId
                         select new
                         {
                             t1.ArDetailId,
                             t1.ArId,
                             t1.PrId,
                             t2.PrName,
                             t1.ArQuantity,
                          };
                foreach (var t in tb)
                {
                    arrivaldetail.Add(new TArrivalDetailDsp
                    {
                        ArDetailId = t.ArDetailId,
                        ArId = t.ArId,
                        PrId = t.PrId,
                        PrName = t.PrName,
                        ArQuantity = t.ArQuantity,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return arrivaldetail;
        }
    }
}
