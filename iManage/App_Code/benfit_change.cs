using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace iManage.App_Code
{
    public class benfit_change
    {

        Dictionary<string, DataRow> list;
        public benfit_change()
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
                    tb.Columns.Add("DAYS_REQUIREMENT_WORKING", typeof(int));
                    tb.Columns.Add("Vacation_Days", typeof(int));

                    DataRow row = item.Value;
                    {
                        DataRow row1 = tb.NewRow();
                        row1[0] = row[0];
                        row1[1] = row[1];
                        row1[2] = row[2];
                        row1[3] = row[3];
                        row1[4] = row[4];
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
            tb.Columns.Add("DAYS_REQUIREMENT_WORKING", typeof(int));
            tb.Columns.Add("Vacation_Days", typeof(int));
            foreach (DataRow row in this.list.Values)
            {
                DataRow row1 = tb.NewRow();
                row1[0] = row[0];
                row1[1] = row[1];
                row1[2] = row[2];
                row1[3] = row[3];
                row1[4] = row[4];
                tb.Rows.Add(row1);

            }
            return tb;
        }
    }
}