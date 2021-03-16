using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iManage
{
    public partial class Form_Edit : System.Web.UI.Page
    {
        EditInfor objEdit;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            objEdit = new EditInfor();
            var employeeID = int.Parse(Request["inputEmployeeID"]);
            var firstName = Request["inputFirstName"];
            var lastName = Request["inputLastName"];
            var address = Request["inputAddress"];
            var email = Request["inputEmail"];
            var payRateID = int.Parse(Request["inputPayRateID"]);
            var payAmount = int.Parse(Request["inputPayAmount"]);
            //Response.Write("<script>alert('Ket qua: " + employeeID + " - " + firstName + " - " + lastName + address + email + payRateID + payAmount + "');</script>");

            if (objEdit.addInformation(employeeID, firstName, lastName, address, email, payRateID, payAmount) != -1)
            {
                Response.Write("<script>alert('Added successful new employee');</script>");
            }
            else
            {
                Response.Write("<script>alert('Existing key Employee ID');</script>");
            }
            Response.Redirect("Admin.aspx");


            

        }
    }
}