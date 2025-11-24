using SalesManagement_SysDev.Context;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class SyukkoDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetSyukkoData()
        //引　数   ：なし
        //戻り値   ：出庫データ
        //機　能   ：出庫データの取得
        ///////////////////////////////
        public List<TSyukkoDsp> GetSyukkoDspData()
        {
            List<TSyukkoDsp> syukko = new List<TSyukkoDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TSyukkos
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         join t3 in context.MEmployees
                         on t1.EmId equals t3.EmId into t3Group
                         from t3 in t3Group.DefaultIfEmpty()
                         join t4 in context.MClients
                         on t1.ClId equals t4.ClId
                         where t1.SyFlag != 2
                         select new
                         {
                             t1.SyId,
                             t1.EmId,
                             t3.EmName,
                             t1.ClId,
                             t4.ClName,
                             t1.SoId,
                             t2.SoName,
                             t1.OrId,
                             t1.SyDate,
                             t1.SyStateFlag,
                             t1.SyFlag,
                             t1.SyHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    syukko.Add(new TSyukkoDsp()
                    {
                        SyId = t.SyId,
                        EmId = t.EmId,
                        EmName = t.EmName,
                        ClId = t.ClId,
                        ClName = t.ClName,
                        SoId = t.SoId,
                        SoName = t.SoName,
                        OrID = t.OrId,
                        SyDate = t.SyDate,
                        SyStateFlg = t.SyStateFlag,
                        SyFlag = t.SyFlag,
                        SyHidden = t.SyHidden,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return syukko;

        }

        ///////////////////////////////
        //メソッド名：GetSyukkoDspData()
        //引　数   ：なし
        //戻り値   ：表示用出庫データ
        //機　能   ：表示用出庫データの取得
        ///////////////////////////////
        public List<TSyukkoDsp> GetSyukkoAllData()
        {
            List<TSyukkoDsp> syukko = new List<TSyukkoDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.TSyukkos
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         join t3 in context.MEmployees
                         on t1.EmId equals t3.EmId into t3Group
                         from t3 in t3Group.DefaultIfEmpty()
                         join t4 in context.MClients
                         on t1.ClId equals t4.ClId
                         select new
                         {
                             t1.SyId,
                             t1.EmId,
                             t3.EmName,
                             t1.ClId,
                             t4.ClName,
                             t1.SoId,
                             t2.SoName,
                             t1.OrId,
                             t1.SyDate,
                             t1.SyStateFlag,
                             t1.SyFlag,
                             t1.SyHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    syukko.Add(new TSyukkoDsp()
                    {
                        SyId = t.SyId,
                        EmId = t.EmId,
                        EmName = t.EmName,
                        ClId = t.ClId,
                        ClName = t.ClName,
                        SoId = t.SoId,
                        SoName = t.SoName,
                        OrID = t.OrId,
                        SyDate = t.SyDate,
                        SyStateFlg = t.SyStateFlag,
                        SyFlag = t.SyFlag,
                        SyHidden = t.SyHidden,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return syukko;

        }
        ///////////////////////////////
        //メソッド名：AddSyukkoData()
        //引　数   ：出庫データ
        //戻り値   ：True or False
        //機　能   ：出庫データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddSyukkoData(TSyukko regSyukko)
        {
            try
            {
                var context = new SalesManagementContext();
                context.TSyukkos.Add(regSyukko);
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
        ///////////////////////////////
        //メソッド名：CheckSyIdCDExistence()
        //引　数   ：出庫ID
        //戻り値   ：True or False
        //機　能   ：一致する出庫IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckSyIdCDExistence(int syid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //出庫IDで一致するデータが存在するか
                flg = context.TSyukkos.Any(x => x.SyId == syid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckEmIdCDExistence()
        //引　数   ：社員ID
        //戻り値   ：True or False
        //機　能   ：一致する社員IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckEmIdCDExistence(int emid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //社員IDで一致するデータが存在するか
                flg = context.TSyukkos.Any(x => x.EmId == emid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckClIdCDExistence()
        //引　数   ：顧客ID
        //戻り値   ：True or False
        //機　能   ：一致する顧客IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckClIdCDExistence(int clid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //顧客IDで一致するデータが存在するか
                flg = context.TSyukkos.Any(x => x.ClId == clid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckOrIdCDExistence()
        //引　数   ：受注ID
        //戻り値   ：True or False
        //機　能   ：一致する受注IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckOrIdCDExistence(int orid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //受注IDで一致するデータが存在するか
                flg = context.TSyukkos.Any(x => x.OrId == orid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckSoIdCDExistence()
        //引　数   ：営業所ID
        //戻り値   ：True or False
        //機　能   ：一致する営業所IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckSoIdCDExistence(int soid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //営業所IDで一致するデータが存在するか
                flg = context.TSyukkos.Any(x => x.SoId == soid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
    }
}
