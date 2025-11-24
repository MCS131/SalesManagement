using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class MajorClassificationDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetMajorClassificationData()
        //引　数   ：なし
        //戻り値   ：大分類データ
        //機　能   ：大分類データの取得
        ///////////////////////////////
        public List<MMajorClassification> GetMajorClassificationData()
        {
            List<MMajorClassification> majorclassification = null;
            try
            {
                var context = new SalesManagementContext();
                majorclassification = context.MMajorClassifications.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return majorclassification;

        }

        ///////////////////////////////
        //メソッド名：GetMajorClassificationDspData()
        //引　数   ：なし
        //戻り値   ：表示用大分類データ
        //機　能   ：表示用大分類データの取得
        ///////////////////////////////
        public List<MMajorClassification> GetMajorClassificationDspData()
        {
            List<MMajorClassification> majorclassification = null;
            try
            {
                var context = new SalesManagementContext();
                majorclassification = context.MMajorClassifications.Where(x => x.McFlag == 0).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return majorclassification;
        }
    }
}
