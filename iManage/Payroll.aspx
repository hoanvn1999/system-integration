<%@ Page Title="" Language="C#" MasterPageFile="~/mpStandard.Master" AutoEventWireup="true" CodeBehind="Payroll.aspx.cs" Inherits="iManage.Payroll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_Search" runat="server">
    <asp:TextBox ID="txt_search" class="form-control bg-light border-0 small" placeholder="Enter employee's ID..." runat="server"></asp:TextBox>
    <div class="input-group-append">
        <div class="position-relative btn btn-primary">            
            <i class="fas fa-search fa-sm text-white"></i>
            <asp:Button ID="btn_Search" CssClass="btn position-absolute fixed-top" runat="server" Text="   " OnClick="ButtonSearchPR_Click"/>
        </div>
    </div>
</asp:Content>
<%--Bắt đầu nội dung chức năng show bảng Lương--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center text-primary mt-5 mb-5">Employee's Paroll Summarized</h1>
    <%--Hiển thị bảng lương qua GridView--%>
    <div class="d-flex justify-content-center">
        <asp:GridView CssClass="text-center" ID="GridViewPayroll" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="900px" AutoGenerateColumns="False" PageSize="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID Employee" />
                 <asp:BoundField DataField="CURRENT_FIRST_NAME" HeaderText="First Name" />
                <asp:BoundField DataField="CURRENT_LAST_NAME" HeaderText="Last Name" />
                <asp:BoundField DataField="ETHNICITY" HeaderText="Ethnicity" />
                <asp:BoundField DataField="EMPLOYMENT_STATUS" HeaderText="Employee status" />
                 <asp:BoundField DataField="DEPARTMENT" HeaderText="Department" />
                  <asp:BoundField DataField="FROM_DATE" HeaderText="From Date" />
                <asp:BoundField DataField="THRU_DATE" HeaderText="Thru Date" />
                <asp:BoundField DataField="Pay_Amount" HeaderText="Pay Amount" />
               
            </Columns>
            <%--Xét màu classic cho GridView--%>
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
<%--Kết thúc nội dung chức năng show bảng Lương--%>

