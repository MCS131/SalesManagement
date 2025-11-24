using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Common
{
    internal class DataInputFormCheck
    {
        ///////////////////////////////
        //メソッド名：CheckNumeric()
        //引　数   ：文字列
        //戻り値   ：True or False
        //機　能   ：数値のチェック
        //          ：数値の場合True
        //          ：数値でない場合False
        ///////////////////////////////
        public bool CheckNumeric(string text)
        {
            bool flg;

            Regex regex = new Regex("^[0-9]+$");
            if (!regex.IsMatch(text))
                flg = false;
            else
                flg = true;

            return flg;
        }

        ///////////////////////////////
        //メソッド名：CheckFullWidth()
        //引　数   ：文字列
        //戻り値   ：True or False
        //機　能   ：全角文字列のチェック
        //          ：全角文字列の場合True
        //          ：全角文字列でない場合False
        ///////////////////////////////
        public bool CheckFullWidth(string text)
        {
            bool flg;

            int textLength = text.Replace("\r\n", string.Empty).Length;
            int textByte = Encoding.GetEncoding("Shift_JIS").GetByteCount(text.Replace("\r\n", string.Empty));
            if (textByte != textLength * 2)
                flg = false;
            else
                flg = true;

            return flg;
        }
        
        ///////////////////////////////
        //メソッド名：CheckcNumericHyphen()
        //引　数   ：文字列
        //戻り値   ：True or False
        //機　能   ：数値とハイフンのチェック
        //          ：数値の場合True
        //          ：数値でない場合False
        ///////////////////////////////
        public bool CheckNumericHyphen(string text)
        {
            bool flg;

            Regex regex = new Regex("^(?=.*\\d)(?=.*-)[0-9\\-]+$");
            if (!regex.IsMatch(text))
                flg = false;
            else
                flg = true;

            return flg;
        }
    }
}
