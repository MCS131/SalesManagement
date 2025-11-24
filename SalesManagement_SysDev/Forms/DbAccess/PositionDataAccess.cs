using Microsoft.EntityFrameworkCore.Migrations;
using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class PositionDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetPositionData()
        //引　数   ：なし
        //戻り値   ：権限データ
        //機　能   ：権限データの取得
        ///////////////////////////////
        public List<MPosition> GetPositionData()
        {
            List<MPosition> position = null;
            try
            {
                var context = new SalesManagementContext();
                position = context.MPositions.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return position;

        }

        ///////////////////////////////
        //メソッド名：GetPositionDspData()
        //引　数   ：なし
        //戻り値   ：表示用権限データ
        //機　能   ：表示用権限データの取得
        ///////////////////////////////
        public List<MPositionDsp> GetPositionDspData()
        {
            List<MPositionDsp> position = new List<MPositionDsp> ();
            try
            {
                var context = new SalesManagementContext();
                var tb = from t1 in context.MPositions
                         where t1.PoFlag != 2
                         select new
                         {
                             t1.PoId,
                             t1.PoName,
                             t1.PoFlag,
                             t1.PoHidden
                         };
                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    position.Add(new MPositionDsp()
                    {
                        PoId = t.PoId,
                        PoName = t.PoName,
                        PoFlag = t.PoFlag,
                        PoHidden = t.PoHidden,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return position;
        }
    }
}
