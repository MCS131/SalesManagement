using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class SmallClassificationDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetSmallClassificationData()
        //引　数   ：なし
        //戻り値   ：小分類データ
        //機　能   ：小分類データの取得
        ///////////////////////////////
        public List<MSmallClassification> GetSmallClassificationData()
        {
            List<MSmallClassification> smallclassification = null;
            try
            {
                var context = new SalesManagementContext();
                smallclassification = context.MSmallClassifications.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return smallclassification;

        }

        ///////////////////////////////
        //メソッド名：GetSmallClassificationDspData()
        //引　数   ：なし
        //戻り値   ：表示用小分類データ
        //機　能   ：表示用小分類データの取得
        ///////////////////////////////
        public List<MSmallDsp> GetSmallClassificationDspData()
        {
            List<MSmallDsp> small = new List<MSmallDsp>();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.MSmallClassifications
                         join t2 in context.MMajorClassifications
                         on t1.McId equals t2.McId
                         select new
                         {
                             t1.ScId,
                             t1.ScName,
                             t1.McId,
                             t2.McName,
                         };
                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    small.Add(new MSmallDsp()
                    {
                        SmallId = t.ScId,
                        SmallName = t.ScName,
                        MajorId = t.McId,
                        MajorName = t.McName,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return small;
        }
    }
}
