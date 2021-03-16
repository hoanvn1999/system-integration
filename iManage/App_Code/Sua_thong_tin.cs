using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace iManage.App_Code
{
    public class Sua_thong_tin
    {
        DataConnection cn;
        static MySqlConn mySqlNotifyDayOff = new MySqlConn();
        MySqlConnection conn = mySqlNotifyDayOff.GetDBConnection("localhost", "payroll", "root", "123456");
        public  void sua_personnal(string EMPLOYEE_ID)
        {
            string sql = "update ";
        }
        public DataTable load_dropdowlist_server() {
            DataTable table = new DataTable();
            cn = new DataConnection(1);
            string sql = "Select  BENEFIT_PLANS_ID   " +
                        " from BENEFIT_PLANS";        
            table = cn.getTable(sql);
            return table;
        }
        public DataTable load_dropdowlist_mysql()
        {
            DataTable table = new DataTable();
            string Mysql = "Select  idPay_Rates " +
                    " from pay_rates";
            MySqlCommand cmd = new MySqlCommand();
            conn.Open();
            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = Mysql;
            table.Columns.Add("idPay_Rates", typeof(int));
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int Pay_Rates_idPay_Rates = Convert.ToInt32(reader.GetValue(0));
                        table.Rows.Add(Pay_Rates_idPay_Rates);
                    }
                }
            }
            conn.Close();
            conn.Dispose();
            return table;
        }
        public DataTable form_loadSqlServer(string Employee_ID)
        {
            DataTable table = new DataTable();
            cn = new DataConnection(1);
            string sql = "select EMP.EMPLOYMENT_ID, PR.CURRENT_FIRST_NAME, PR.CURRENT_LAST_NAME, PR.CURRENT_MIDDLE_NAME,FORMAT(PR.BIRTH_DATE,'yyyy-MM-dd') AS BIRTH_DATE" +
                ", PR.SOCIAL_SECURITY_NUMBER, PR.CURRENT_ADDRESS_1, PR.CURRENT_GENDER, PR.CURRENT_PHONE_NUMBER,PR.CURRENT_PERSONAL_EMAIL" +
                ", PR.ETHNICITY,PR.SHAREHOLDER_STATUS,PR.BENEFIT_PLAN_ID, EMP.NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH, FORMAT(EMP.HIRE_DATE_FOR_WORKING,'yyyy-MM-dd') AS HIRE_DATE_FOR_WORKING " +
                ",JOB.DIVISION,  FORMAT(JOB.THRU_DATE,'yyyy-MM-dd') AS THRU_DATE, FORMAT(JOB.FROM_DATE,'yyyy-MM-dd') AS FROM_DATE " +
                " FROM EMPLOYMENT EMP, JOB_HISTORY JOB, PERSONAL PR " +
                " WHERE EMP.EMPLOYMENT_ID='" + Employee_ID+"'" +
                "  AND EMP.EMPLOYMENT_ID=JOB.EMPLOYMENT_ID " +
                " AND EMP.EMPLOYMENT_ID=PR.EMPLOYEE_ID";
            table = cn.getTable(sql);
            return table;
        }
     
        public DataTable from_loadMySql(string Employee_ID)
        {
            DataTable table = new DataTable();
            string Mysql = "Select Pay_Rate , Pay_Rates_idPay_Rates " +
                    " from payroll.employee" +
                    " where idEmployee='"+Employee_ID+"' ";
            MySqlCommand cmd = new MySqlCommand();
            conn.Open();
            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = Mysql;
            table.Columns.Add("Pay_Rate", typeof(string));
            table.Columns.Add("Pay_Rates_idPay_Rates", typeof(int));
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string Pay_Rate = reader.GetValue(0).ToString();
                        int Pay_Rates_idPay_Rates = Convert.ToInt32(reader.GetValue(1));
                        table.Rows.Add(Pay_Rate, Pay_Rates_idPay_Rates);
                    }
                }
            }
            
            conn.Close();
            conn.Dispose();
            return table;
        }
        public void update_SQLserver(string Employee_ID, string EMPLOYMENT_ID,string CURRENT_FIRST_NAME, string CURRENT_LAST_NAME, string CURRENT_MIDDLE_NAME,DateTime BIRTH_DATE,string SOCIAL_SECURITY_NUMBER,string CURRENT_ADDRESS_1,string CURRENT_GENDER,string CURRENT_PHONE_NUMBER,string CURRENT_PERSONAL_EMAIL,string ETHNICITY, int SHAREHOLDER_STATUS,int BENEFIT_PLAN_ID, int NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH ,string DIVISION,DateTime THRU_DATE,DateTime FROM_DATE,DateTime HIRE_DATE_FOR_WORKING)
        {
            string sqlEMPLOYMENT = "update [EMPLOYMENT] " +
                " SET EMPLOYMENT_ID ='" + EMPLOYMENT_ID + "'" +
                ",     NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH = " + NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH + "" +
                " ,    HIRE_DATE_FOR_WORKING = '" + HIRE_DATE_FOR_WORKING + "'" +
                " WHERE EMPLOYMENT_ID ='" + Employee_ID + "'";

            string sqlJOB_HISTORY = "update JOB_HISTORY " +
                 " SET FROM_DATE ='" + FROM_DATE + "'" +
                 ", THRU_DATE ='" + THRU_DATE + "'" +
                 ", DIVISION ='" + DIVISION + "'" +
                 ", EMPLOYMENT_ID ='" + EMPLOYMENT_ID + "'" +
                 " WHERE EMPLOYMENT_ID ='" + Employee_ID + "'";

            string sqlPERSONAL = "update PERSONAL " +
                " SET EMPLOYEE_ID ='" + EMPLOYMENT_ID + "'" +
                ",     CURRENT_FIRST_NAME ='" + CURRENT_FIRST_NAME + "'" +
                ",     CURRENT_LAST_NAME ='" + CURRENT_LAST_NAME + "'" +
                ",     CURRENT_MIDDLE_NAME ='" + CURRENT_MIDDLE_NAME + "'" +
                ",     BIRTH_DATE ='" + BIRTH_DATE + "'" +
                ",     SOCIAL_SECURITY_NUMBER ='" + SOCIAL_SECURITY_NUMBER + "'" +
                ",     CURRENT_ADDRESS_1 = '" + CURRENT_ADDRESS_1 + "'" +
                ",     CURRENT_GENDER = '" + CURRENT_GENDER + "'" +
                ",     CURRENT_PHONE_NUMBER = '" + CURRENT_PHONE_NUMBER + "'" +
                ",     CURRENT_PERSONAL_EMAIL = '" + CURRENT_PERSONAL_EMAIL + "'" +
                ",     ETHNICITY ='" + ETHNICITY + "'" +
                ",     SHAREHOLDER_STATUS = '" + SHAREHOLDER_STATUS + "'" +
                ",     BENEFIT_PLAN_ID ='" + BENEFIT_PLAN_ID + "'" +
                "  WHERE EMPLOYEE_ID ='" + Employee_ID + "'";
            cn = new DataConnection(1);
            //cn.thucthiSQL(sqlJOB_HISTORY);
            //cn.thucthiSQL(sqlEMPLOYMENT);
            //cn.thucthiSQL(sqlPERSONAL);
            cn.executeSQL(sqlJOB_HISTORY);
            cn.executeSQL(sqlEMPLOYMENT);
            cn.executeSQL(sqlPERSONAL);
        }
        public void update_MySql(string Employee_ID,string EMPLOYMENT_ID,int Pay_Rates_idPay_Rates,string Pay_Rate, string CURRENT_FIRST_NAME, string CURRENT_LAST_NAME, string CURRENT_MIDDLE_NAME )
        {
            string sql_employee = "update employee " +
                  " SET Last_Name = '" + string.Concat(CURRENT_LAST_NAME," ",CURRENT_MIDDLE_NAME) + "'" +
                  ", First_Name = '" + CURRENT_FIRST_NAME + "'" +
                  ", Pay_Rate = '" + Pay_Rate + "'" +
                  ", Pay_Rates_idPay_Rates ="+Pay_Rates_idPay_Rates+"" +
                  ", idEmployee ='" + EMPLOYMENT_ID + "'" +
                  " WHERE idEmployee ='" + Employee_ID + "'";
            MySqlCommand cmd = new MySqlCommand();
            conn.Open();
            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql_employee;
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
       
           
        }
        
    }
   
