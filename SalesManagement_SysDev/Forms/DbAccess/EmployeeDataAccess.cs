using SalesManagement_SysDev.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Forms.DbAccess
{
    internal class EmployeeDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckEmpIdCDExistence()
        //引　数   ：社員ID
        //戻り値   ：True or False
        //機　能   ：一致する社員IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckEmpCDExistence(int empId)
        {

            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //社員IDで一致するデータが存在するか
                flg = context.MEmployees.Any(x => x.EmId == empId);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：CheckEmpNameCDExistence()
        //引　数   ：社員名
        //戻り値   ：True or False
        //機　能   ：一致する社員名の有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckEmpNameCDExistence(string empname)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //社員名で一致するデータが存在するか
                flg = context.MEmployees.Any(x => x.EmName == empname);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }


        ///////////////////////////////
        //メソッド名：CheckPoIdCDExistence()
        //引　数   ：役職ID
        //戻り値   ：True or False
        //機　能   ：一致する役職IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckPoIdCDExistence(int poid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //役職IDで一致するデータが存在するか
                flg = context.MEmployees.Any(x => x.PoId == poid);
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
                flg = context.MEmployees.Any(x => x.SoId == soid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：CheckClphoneCDExistence()
        //引　数   ：電話番号
        //戻り値   ：True or False
        //機　能   ：一致する電話番号の有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckEmphoneCDExistence(string Emphone)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagementContext();
                //電話番号で一致するデータが存在するか
                flg = context.MEmployees.Any(x => x.EmPhone == Emphone);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：GetEmployeeDspData()
        //引　数   ：なし
        //戻り値   ：社員データ
        //機　能   ：社員データの取得
        ///////////////////////////////
        public List<MEmployeeDsp> GetEmployeeDspData()
        {
            List<MEmployeeDsp> employee = new List<MEmployeeDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.MEmployees
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         join t3 in context.MPositions
                         on t1.PoId equals t3.PoId
                         where t1.EmFlag != 2
                         select new
                         {
                             t1.EmId,
                             t1.EmName,
                             t1.SoId,
                             t2.SoName,
                             t1.PoId,
                             t3.PoName,
                             t1.EmHiredate,
                             t1.EmPassword,
                             t1.EmPhone,
                             t1.EmFlag,
                             t1.EmHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    employee.Add(new MEmployeeDsp()
                    {
                        EmployeeId = t.EmId,
                        EmployeeName = t.EmName,
                        SalesOfficeID = t.SoId,
                        SalesOfficeName = t.SoName,
                        PositionID = t.PoId,
                        PositionName = t.PoName,
                        EmployeeHireDate = t.EmHiredate.ToString("yyyy/MM/dd"),
                        EmPassward = t.EmPassword,
                        EmPhone = t.EmPhone,
                        EmFlag = t.EmFlag,
                        EmHidden = t.EmHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return employee;
        }

        ///////////////////////////////
        //メソッド名：GetEmployeeAllData()
        //引　数   ：なし
        //戻り値   ：表示用社員データ
        //機　能   ：表示用社員データの取得
        ///////////////////////////////
        public List<MEmployeeDsp> GetEmployeeAllData()
        {
            List<MEmployeeDsp> employee = new List<MEmployeeDsp>();
            try
            {
                var context = new SalesManagementContext();
                //tbはIEnumerable型
                var tb = from t1 in context.MEmployees
                         join t2 in context.MSalesOffices
                         on t1.SoId equals t2.SoId
                         join t3 in context.MPositions
                         on t1.PoId equals t3.PoId
                         select new
                         {
                             t1.EmId,
                             t1.EmName,
                             t1.SoId,
                             t2.SoName,
                             t1.PoId,
                             t3.PoName,
                             t1.EmHiredate,
                             t1.EmPassword,
                             t1.EmPhone,
                             t1.EmFlag,
                             t1.EmHidden
                         };

                //IEnumerable型のデータをList型へ
                foreach (var t in tb)
                {
                    employee.Add(new MEmployeeDsp()
                    {
                        EmployeeId = t.EmId,
                        EmployeeName = t.EmName,
                        SalesOfficeID = t.SoId,
                        SalesOfficeName = t.SoName,
                        PositionID = t.PoId,
                        PositionName = t.PoName,
                        EmployeeHireDate = t.EmHiredate.ToString(),
                        EmPassward = t.EmPassword,
                        EmPhone = t.EmPhone,
                        EmFlag = t.EmFlag,
                        EmHidden = t.EmHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return employee;
        }
        ///////////////////////////////
        //メソッド名：AddEmpData()
        //引　数   ：社員データ
        //戻り値   ：True or False
        //機　能   ：社員データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
         public bool AddEmpData(MEmployee regEmp)
        {
            try
            {
                var context = new SalesManagementContext();
                context.MEmployees.Add(regEmp);
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
        //メソッド名：UpdateCategoryData()
        //引　数   ：社員カテゴリデータ
        //戻り値   ：True or False
        //機　能   ：社員カテゴリデータの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateCategoryData(MEmployee updEmp)
        {
            try
            {
                var context = new SalesManagementContext();
                var employee = context.MEmployees.SingleOrDefault(x => x.EmId == updEmp.EmId);
                employee.EmPhone = updEmp.EmPhone;
                employee.EmName = updEmp.EmName;
                employee.SoId = updEmp.SoId;
                employee.EmHiredate = updEmp.EmHiredate;
                employee.EmPassword = updEmp.EmPassword;
                employee.EmFlag = updEmp.EmFlag;
                employee.EmHidden = updEmp.EmHidden;

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
    }
}
