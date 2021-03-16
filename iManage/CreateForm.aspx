
<%@ Page Title="" Language="C#" MasterPageFile="~/mpStandard.Master" AutoEventWireup="true" CodeBehind="CreateForm.aspx.cs" Inherits="iManage.Form_Edit" %>
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
        <input id="inputEmployeeID" class="form-control border border-primary" type="number" name="inputEmployeeID" required/>
    </div>
    <div class="form-group col-md-6">
      <label for="inputBirthDate">Birth Date:</label>
      <input type="date" class="form-control border border-primary" id="inputBirthDate"> 
    </div>
  </div>
<div class="form-row">
    <%--Cần thiết--%>
    <div class="form-group col-md-4">
      <label for="inputFirstName">Current First Name:</label>
      <input type="text" class="form-control  border border-primary" id="inputFirstName" name="inputFirstName" required>
    </div>
    <%--Cần thiết--%>
    <div class="form-group col-md-4">
      <label for="inputLastName">Current Last Name:</label>
      <input type="text" class="form-control border border-primary" id="inputLastName" name="inputLastName" required>
    </div>
    <div class="form-group col-md-4">
      <label for="inputMiddleName">Current Middle Name:</label>
      <input type="text" class="form-control border border-primary" id="inputMiddleName">
    </div>
  </div>
<div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputSocial">Social Security Number:</label>
      <input type="text" class="form-control border border-primary" id="inputSocial">
    </div>
    <div class="form-group col-md-3">
      <label for="exampleFormGender">Gender: </label>
        <select class="form-control border border-primary" id="exampleFormGender">
            <option>Male</option>
            <option>Female</option>
        </select>
    </div>
    <div class="form-group col-md-3">
      <label for="inputEthnicity">Ethnicity:</label>
      <input type="text" class="form-control border border-primary" id="inputEthnicity">
    </div>
  </div>
 
        
 <h4 class="mt-4 text-success">Contact Information:</h4>
<%--Cần thiết--%>
 <div class="form-group">
    <label for="inputAddress">Current Address: </label>
    <input type="text" class="form-control border border-success" id="inputAddress" name="inputAddress" placeholder="1234 Main St" required>
  </div>
<%--Cần thiết--%>
  <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputEmail">Email:</label>
      <input type="email" class="form-control border border-success" id="inputEmail" name="inputEmail" placeholder="abc@gmail.com" required>
    </div>
    <div class="form-group col-md-6">
      <label for="inputPhone">Phone Number:</label>
      <input type="number" class="form-control border border-success" id="inputPhone" name="inputPhone">
    </div>
  </div>
  
<h4 class="mt-4 text-info">PayRoll Information:</h4>
<div class="form-row">
    <%--Cần thiết--%>
    <div class="form-group col-md-3">
      <label for="inputThruDate">Id Pay Rate:</label>
      <input type="number" class="form-control border border-info" id="inputPayRateID" name="inputPayRateID" required>
    </div>
    <%--<div class="form-group col-md-9">
      <label for="inputFromDate">Pay Rate:</label>
      <input type="text" class="form-control border border-info" id="inputFromDate">
    </div>--%>
     <%--Cần thiết--%>
    <div class="form-group col-md-9">
        <label for="inputPayAmount">Pay Amount:</label>
        <input id="inputPayAmount" type="number" class="form-control border border-info" name="inputPayAmount"/ required>
    </div>
  </div>
<h4 class="mt-4 text-warning">Others Information:</h4>
    <div class="form-row">
    <div class="form-group col-md-4">
      <label for="inputShare">Shareholder Status:</label>
      <input type="number" class="form-control border border-warning" id="inputShare">
    </div>
    <div class="form-group col-md-4">
      <label for="inputBenefit">Benefit  Plan ID:</label>
      <input type="number" class="form-control border border-warning" id="inputBenefit">
    </div>
    <div class="form-group col-md-4">
      <label for="inputDivision">Division: </label>
      <input type="text" class="form-control border border-warning" id="inputDivision">
    </div>
  </div>
<div class="form-row">
    <div class="form-group col-md-3">
      <label for="inputDayWorking">Days Requirement Of Working:</label>
      <input type="number" class="form-control border border-warning" id="inputDayWorking">
    </div>
    <div class="form-group col-md-3">
      <label for="inputHireDate">Hire Date For Working</label>
      <input type="date" class="form-control border border-warning" id="inputHireDate">
    </div>
    <div class="form-group col-md-3">
      <label for="inputThruDate">Thru Date:</label>
      <input type="date" class="form-control border border-warning" id="inputThruDate">
    </div>
    <div class="form-group col-md-3">
      <label for="inputFromDate">From Date</label>
      <input type="date" class="form-control border border-warning" id="inputFromDate">
    </div>
  </div>
  <%--<button id="btnSubmit" runat="server" class="btn btn-primary text-center" type="submit" onclick="btnSubmit_click">Sign in</button>--%>
  <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary text-center" Text="Submit" OnClick="Button1_Click" />
</div>
</asp:Content>
