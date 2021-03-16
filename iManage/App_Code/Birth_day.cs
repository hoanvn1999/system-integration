using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace iManage.App_Code
{
    public class Birth_day
    {
        Dictionary<string, DataRow> list;
        public Birth_day()
        {
            list = new Dictionary<string, DataRow>();
        }
        public void additem(DataRow row)
        {
            string key = row["EMPLOYEE_ID"].ToString();
                list.Add(key, row);
            
        }
        public DataTable search(string EmpID)
        {
            foreach (var item in list)
            {
                if (item.Key == EmpID)
                {
                    DataTable tb = new DataTable();

                    tb.Columns.Add("EMPLOYEE_ID", typeof(string));
                    tb.Columns.Add("FIRST_NAME", typeof(string));
                    tb.Columns.Add("LAST_NAME", typeof(string));
                    tb.Columns.Add("BIRTH_DATE", typeof(DateTime));
                    DataRow row = item.Value;
                    {
                        DataRow row1 = tb.NewRow();
                        row1[0] = row[0];
                        row1[1] = row[1];
                        row1[2] = row[2];
                        row1[3] = row[3];
                        tb.Rows.Add(row1);

                    }
                    return tb;
                }
            }
                    return null;
                }
            
           
        
        public DataTable GetTable()
        {
            DataTable tb = new DataTable();

            tb.Columns.Add("EMPLOYEE_ID", typeof(string));
            tb.Columns.Add("FIRST_NAME", typeof(string));
            tb.Columns.Add("LAST_NAME", typeof(string));
            tb.Columns.Add("BIRTH_DATE", typeof(DateTime));
            foreach (DataRow row in this.list.Values)
            {
                DataRow row1 = tb.NewRow();
                row1[0] = row[0];
                row1[1] = row[1];
                row1[2] = row[2];
                row1[3] = row[3];
                tb.Rows.Add(row1);

            }
            return tb;
        }
    }
}