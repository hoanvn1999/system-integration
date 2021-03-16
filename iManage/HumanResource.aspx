<%@ Page Title="" Language="C#" MasterPageFile="~/mpStandard.Master" AutoEventWireup="true" CodeBehind="HumanResource.aspx.cs" Inherits="iManage.HummanResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--Chèn đường dẫn như Css, JavaScript--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH_Search" runat="server">
    <asp:TextBox ID="txt_search" class="form-control bg-light border-0 small" placeholder="Enter employee's ID..." runat="server"></asp:TextBox>
    <div class="input-group-append">
        <div class="position-relative btn btn-primary">            
            <i class="fas fa-search fa-sm text-white"></i>
            <asp:Button ID="btn_Search" CssClass="btn position-absolute fixed-top" runat="server" Text="   " OnClick="ButtonSearch_Click"/>
        </div>
    </div>       
</asp:Content>
<%--Begin function show HR table--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center text-primary mt-5 mb-5">Employee's Information Summarized</h1>
    
    <div class="d-flex justify-content-center">
        <asp:GridView CssClass="text-center" ID="GridViewHummanResource" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="900px" PageSize="5">
            <Columns>
                <%--Hiển thị dữ liệu từ bảng PERSONAL--%>
                <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID Employee" />
                <asp:BoundField DataField="CURRENT_FIRST_NAME" HeaderText="First Name" />
                <asp:BoundField DataField="CURRENT_LAST_NAME" HeaderText="Last Name" />
                <asp:BoundField DataField="EMPLOYMENT_STATUS" HeaderText="Employee" />
                <asp:BoundField DataField="FROM_DATE" HeaderText="FROM_DATE" />
                <asp:BoundField DataField="THRU_DATE" HeaderText="THRU_DATE" />
                <asp:BoundField DataField="TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH" HeaderText="Vacation Days" />
                <asp:BoundField DataField="CURRENT_GENDER" HeaderText="Gender" />
                <asp:BoundField DataField="ETHNICITY" HeaderText="Ethnicity" />
               
            </Columns>
            <%--Xét thuộc tính classic cho GridView--%>
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
</asp:Content>
<%--End function show HR table--%>

