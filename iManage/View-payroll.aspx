<%@ Page Title="" Language="C#" MasterPageFile="~/mpStandard.Master" AutoEventWireup="true" CodeBehind="View-payroll.aspx.cs" Inherits="iManage.View_payroll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:TextBox ID="TextBox_search" Text="Search By ID Employee" runat="server"></asp:TextBox>
    <asp:Button ID="Button_search" OnClick="buntton_search_Click" runat="server" Text="search"/>
    <h2 class="text-center mt-5 mb-5">Employees has accumulated more thana certain number of days of vacation</h2>
    <div class="d-flex justify-content-center">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1000px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="Employee ID" />
              <asp:BoundField DataField="FIRST_NAME" HeaderText="FIRST NAME" />
            <asp:BoundField DataField="LAST_NAME" HeaderText="LAST NAME" />
            <asp:BoundField DataField="DAYS_REQUIREMENT_WORKING" HeaderText="DAYS REQUIREMENT WORKING" />
            <asp:BoundField DataField="Vacation_Days" HeaderText="Vacation Day" />
        </Columns>
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
