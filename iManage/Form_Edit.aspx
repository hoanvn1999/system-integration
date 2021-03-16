<%@ Page Title="" Language="C#" MasterPageFile="~/mpStandard.Master" AutoEventWireup="true" CodeBehind="Form_Edit.aspx.cs" Inherits="iManage.WebForm2"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_Search" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h1 class="font-weight-bold" style="text-align:center">Edit Employee Information</h1>
    <div class="container">
    <h4 class="text-primary">Personal Information:</h4>
  <div class="form-row">
      <%--Cần thiết--%>
    <div class="form-group col-md-6">
      <label for="inputID">Employee ID:</label>
        <%--<asp:TextBox ID="inputID" class="form-control border border-primary" runat="server" ReadOnly="true" ></asp:TextBox>--%>
        <asp:TextBox id="inputEmployeeID" class="form-control border border-primary" type="text" runat="server" name="inputEmployeeID" ReadOnly="true" />
    </div>
    <div class="form-group col-md-6">
      <label for="inputBirthDate">Birth Date:</label>
      <asp:TextBox type="date" class="form-control border border-primary" id="inputBirthDate" runat="server" required/> 
    </div>
  </div>
<div class="form-row">
    <%--Cần thiết--%>
    <div class="form-group col-md-4">
      <label for="inputFirstName">Current First Name:</label>
      <asp:TextBox type="text" class="form-control  border border-primary" id="inputFirstName" name="inputFirstName" runat="server" required/>
    </div>
    <%--Cần thiết--%>
    <div class="form-group col-md-4">
      <label for="inputLastName">Current Last Name:</label>
      <asp:TextBox type="text" class="form-control border border-primary" id="inputLastName" name="inputLastName" runat="server" required/>
    </div>
    <div class="form-group col-md-4">
      <label for="inputMiddleName">Current Middle Name:</label>
      <asp:TextBox type="text" class="form-control border border-primary" id="inputMiddleName" runat="server" />
    </div>
  </div>
<div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputSocial">Social Security Number:</label>
      <asp:TextBox type="text" class="form-control border border-primary" id="inputSocial" runat="server" />
    </div>
    <div class="form-group col-md-3">
      <label for="exampleFormGender">Gender: </label>
        <asp:DropDownList class="form-control border border-primary" id="exampleFormGender"  runat="server" required>
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group col-md-3">
      <label for="inputEthnicity">Ethnicity:</label>
      <asp:TextBox type="text" class="form-control border border-primary" id="inputEthnicity" runat="server" required/>
    </div>
  </div>
 
        
 <h4 class="mt-4 text-success">Contact Information:</h4>
<%--Cần thiết--%>
 <div class="form-group">
    <label for="inputAddress">Current Address: </label>
     <%--Tới sửa--%>
<%--    <input type="text" class="form-control border border-success" id="inputAddress" name="inputAddress" placeholder="1234 Main St" runat="server" required/>--%>
         <asp:TextBox type="text" class="form-control border border-success" id="inputAddress" runat="server"  name="inputAddress" placeholder="1234 Main St" required/>

  </div>
<%--Cần thiết--%>
  <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputEmail">Email:</label>
      <asp:TextBox type="email" class="form-control border border-success" id="inputEmail" name="inputEmail" placeholder="abc@gmail.com" runat="server" required/>
    </div>
    <div class="form-group col-md-6">
      <label for="inputPhone">Phone Number:</label>
      <asp:TextBox type="text" class="form-control border border-success" id="inputPhone" maxlength="10" minlength="10" name="inputPhone" runat="server" required/>
    </div>
  </div>
  
<h4 class="mt-4 text-info">PayRoll Information:</h4>
<div class="form-row">
    <%--Cần thiết--%>
    <div class="form-group col-md-3">
      <label for="inputThruDate">Id Pay Rate:</label>
      <asp:DropDownList  class="form-control border border-info" id="inputPayRateID" name="inputPayRateID" runat="server" >

      </asp:DropDownList>
    </div>
    <%--<div class="form-group col-md-9">
      <label for="inputFromDate">Pay Rate:</label>
      <input type="text" class="form-control border border-info" id="inputFromDate">
    </div>--%>
     <%--Cần thiết--%>
    <div class="form-group col-md-9">
        <label for="inputPayAmount">Pay Amount:</label>
        <asp:TextBox id="inputPayAmount" type="text" class="form-control border border-info" name="inputPayAmount" runat="server" />
    </div>
  </div>
<h4 class="mt-4 text-warning">Others Information:</h4>
    <div class="form-row">
    <div class="form-group col-md-4">
      <label for="inputShare">Shareholder Status:</label>
      <asp:TextBox type="number" class="form-control border border-warning" runat="server" min="0" max="1" id="inputShare" />
    </div>
    <div class="form-group col-md-4">
      <label for="inputBenefit">Benefit  Plan ID:</label>
      <asp:DropDownList  class="form-control border border-warning" id="inputBenefit" runat="server" >
      </asp:DropDownList>
    </div>
    <div class="form-group col-md-4">
      <label for="inputDivision">Division: </label>
      <asp:TextBox type="text" class="form-control border border-warning" id="inputDivision" runat="server" />
    </div>
  </div>
<div class="form-row">
    <div class="form-group col-md-3">
      <label for="inputDayWorking">Days Requirement Of Working:</label>
      <asp:TextBox type="number" class="form-control border border-warning" id="inputDayWorking" runat="server" min="0" max="21" />
    </div>
    <div class="form-group col-md-3">
      <label for="inputHireDate">Hire Date For Working</label>
      <asp:TextBox type="date" class="form-control border border-warning" id="inputHireDate" runat="server" />
    </div>
    <div class="form-group col-md-3">
      <label for="inputThruDate">Thru Date:</label>
      <asp:TextBox type="date" class="form-control border border-warning" id="inputThruDate" runat="server" />
    </div>
    <div class="form-group col-md-3">
      <label for="inputFromDate">From Date</label>
      <asp:TextBox type="date" class="form-control border border-warning" id="inputFromDate" runat="server" />
    </div>
    
  </div>
  <%--<button id="btnSubmit" runat="server" class="btn btn-primary text-center" type="submit" onclick="btnSubmit_click">Sign in</button>--%>
  <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary text-center" Text="Submit" OnClick="Submit_Click" />
</div>

    
</asp:Content>
