using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using iManage.App_Code;
using System.Data;
namespace iManage
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Sua_thong_tin sua;
        DataTable table;
        string Employee_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Employee_ID = Request.QueryString.Get("EMPLOYMENT_ID");
            //this.Employee_ID = "117";
            if (!IsPostBack)
            {
                loadfrom(Employee_ID);
                load_dropdowlist();
            }
        }
        private void load_dropdowlist()
        {
            sua = new Sua_thong_tin();
            table = new DataTable();
            table = sua.load_dropdowlist_server();
            for(int i=0;i<table.Rows.Count;i++)
                 this.inputBenefit.Items.Add(table.Rows[i]["BENEFIT_PLANS_ID"].ToString());
            
            table = sua.load_dropdowlist_mysql();
            for (int i = 0; i < table.Rows.Count; i++)
                this.inputPayRateID.Items.Add(table.Rows[i]["idPay_Rates"].ToString()); 
          
        }
            private void loadfrom(string Employee_ID)
        {

            table = new DataTable();
            sua = new Sua_thong_tin();
            table = sua.form_loadSqlServer(Employee_ID);
            this.inputEmployeeID.Text  = table.Rows[0]["EMPLOYMENT_ID"].ToString();
            this.inputFirstName.Text  = table.Rows[0]["CURRENT_FIRST_NAME"].ToString();
            this.inputMiddleName.Text = table.Rows[0]["CURRENT_MIDDLE_NAME"].ToString();
            this.inputLastName.Text = table.Rows[0]["CURRENT_LAST_NAME"].ToString();
            this.inputSocial.Text = table.Rows[0]["SOCIAL_SECURITY_NUMBER"].ToString();
            this.exampleFormGender.Text = table.Rows[0]["CURRENT_GENDER"].ToString();
            this.inputEthnicity.Text = table.Rows[0]["ETHNICITY"].ToString();
            this.inputAddress.Text = table.Rows[0]["CURRENT_ADDRESS_1"].ToString();
            this.inputEmail.Text  = table.Rows[0]["CURRENT_PERSONAL_EMAIL"].ToString();
            this.inputPhone.Text = table.Rows[0]["CURRENT_PHONE_NUMBER"].ToString();
            this.inputShare.Text = table.Rows[0]["SHAREHOLDER_STATUS"].ToString();
            this.inputDayWorking.Text = table.Rows[0]["NUMBER_DAYS_REQUIREMENT_OF_WORKING_PER_MONTH"].ToString();
            this.inputDivision.Text = table.Rows[0]["DIVISION"].ToString();
            this.inputBenefit.Text = table.Rows[0]["BENEFIT_PLAN_ID"].ToString();
            // DateTime date = DateTime.ParseExact(table.Rows[0]["BIRTH_DATE"].ToString(), "dd/MM/yyyy", null);
            this.inputBirthDate.Text = table.Rows[0]["BIRTH_DATE"].ToString();
            // DateTime date1 = DateTime.ParseExact(table.Rows[0]["FROM_DATE"].ToString(), "dd/MM/yyyy", null);
            this.inputFromDate.Text = table.Rows[0]["FROM_DATE"].ToString();
           // DateTime date2 = DateTime.ParseExact(table.Rows[0]["HIRE_DATE_FOR_WORKING"].ToString(), "dd/MM/yyyy", null);
            this.inputHireDate.Text = table.Rows[0]["HIRE_DATE_FOR_WORKING"].ToString();
           // var date3 = DateTime.ParseExact(table.Rows[0]["THRU_DATE"].ToString(), "dd/MM/yyyy", null);
            this.inputThruDate.Text = table.Rows[0]["THRU_DATE"].ToString();
            table = new DataTable();
            table = sua.from_loadMySql(Employee_ID);
            this.inputPayAmount.Text = table.Rows[0]["Pay_Rate"].ToString();
            this.inputPayRateID.Text = table.Rows[0]["Pay_Rates_idPay_Rates"].ToString();

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            

            sua = new Sua_thong_tin();

            try
            {
                sua.update_SQLserver(Employee_ID, this.inputEmployeeID.Text, this.inputFirstName.Text, this.inputLastName.Text, this.inputMiddleName.Text, Convert.ToDateTime(this.inputBirthDate.Text), this.inputSocial.Text, this.inputAddress.Text, this.exampleFormGender.SelectedValue, this.inputPhone.Text, this.inputEmail.Text, this.inputEthnicity.Text, Convert.ToInt32(this.inputShare.Text), Convert.ToInt32(this.inputBenefit.SelectedValue), Convert.ToInt32(this.inputDayWorking.Text), this.inputDivision.Text, Convert.ToDateTime(this.inputThruDate.Text), Convert.ToDateTime(this.inputFromDate.Text), Convert.ToDateTime(this.inputHireDate.Text));

                sua.update_MySql(Employee_ID, this.inputEmployeeID.Text.ToString(), Convert.ToInt32(this.inputPayRateID.SelectedValue), this.inputPayAmount.Text, this.inputFirstName.Text.ToString(), this.inputLastName.Text.ToString(), this.inputMiddleName.Text.ToString());

                loadfrom(Employee_ID);
                Response.Write("<script>alert('sua thanh cong'); </script>");
            }
            catch (Exception) { }
        }


    }
}