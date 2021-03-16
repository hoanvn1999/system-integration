using iManage.App_Code;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace iManage
{
    internal class EditInfor
    {
        public EditInfor()
        {

        }
        DataConnection sqlServerConn = new DataConnection(1);
        MySqlConn mySqlConn = new MySqlConn();
        public int addInformation(int EMPLOYMENT_ID, string CURRENT_FIRST_NAME, string CURRENT_LAST_NAME, string CURRENT_ADDRESS_1, string CURRENT_PERSONAL_EMAIL, int idPay_Rates, int Pay_Amount )
        {
            int result = 1;
            mySqlConn.GetDBConnection("localhost", "payroll", "root", "123456");

            if (!sqlServerConn.checkKey(EMPLOYMENT_ID, "EMPLOYMENT", "EMPLOYMENT_ID") && !mySqlConn.checkKey(idPay_Rates, "pay_rates", "idPay_Rates"))
            {
                //Truy vấn vào bảng SQL server
                var querySqlServer_table_EMPLOYMENT = "insert into EMPLOYMENT(EMPLOYMENT_ID) values(" + EMPLOYMENT_ID + ")";
                sqlServerConn.executeSQL(querySqlServer_table_EMPLOYMENT);

                var querySqlServer_table_JOB_HISTORY = "insert into JOB_HISTORY(EMPLOYMENT_ID) values(" + EMPLOYMENT_ID + ")";
                sqlServerConn.executeSQL(querySqlServer_table_JOB_HISTORY);

                var querySqlServer_table_EMPLOYMENT_WORKING_TIME = "insert into EMPLOYMENT_WORKING_TIME(EMPLOYMENT_ID) values(" + EMPLOYMENT_ID + ")";
                sqlServerConn.executeSQL(querySqlServer_table_EMPLOYMENT_WORKING_TIME);

                //Truy vấn vào bảng MySQL
                var querySqlServer_table_PERSONAL = "insert into PERSONAL(EMPLOYEE_ID, CURRENT_FIRST_NAME, CURRENT_LAST_NAME, CURRENT_ADDRESS_1, CURRENT_PERSONAL_EMAIL) values("+ EMPLOYMENT_ID + ", '"+ CURRENT_FIRST_NAME + "', '"+ CURRENT_LAST_NAME + "', '"+ CURRENT_ADDRESS_1 + "', '" + CURRENT_PERSONAL_EMAIL + "')";
                sqlServerConn.executeSQL(querySqlServer_table_PERSONAL);

                string queryMySql = "insert into pay_rates(idPay_Rates, Pay_Amount) values("+ idPay_Rates + ", "+ Pay_Amount + ");";
                mySqlConn.executeQuery(queryMySql);
            }
            else
            {
                result = -1;
            }
            return result;
        }
        public string deleteInformaton(int EMPLOYEE_ID)
        {
            string result;
            try
            {   
                var date = DateTime.Now;
                var query = "update JOB_HISTORY set THRU_DATE = getdate() where EMPLOYMENT_ID = " + EMPLOYEE_ID;
                sqlServerConn.executeSQL(query);
                result = "Successful delete";
            }
            catch(Exception e)
            {
                result = e.ToString();
            }
            return result;
        }
    }
}