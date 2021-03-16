<%@ Page Title="" Language="C#" MasterPageFile="~/mpStandard.Master" AutoEventWireup="true" CodeBehind="Hiring_Anniversary.aspx.cs" Inherits="iManage.Hiring_Anniversary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPH_Search" runat="server">
    <asp:TextBox ID="txt_search" class="form-control bg-light border-0 small" placeholder="Enter employee's ID..." runat="server"></asp:TextBox>
    <div class="input-group-append">
        <div class="position-relative btn btn-primary">            
            <i class="fas fa-search fa-sm text-white"></i>
            <asp:Button ID="btn_Search" CssClass="btn position-absolute fixed-top" runat="server" Text="   " OnClick="btn_Search_Click"/>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center text-primary mt-5 mb-5">Hiring Anniversary</h1>

    <div class="d-flex justify-content-center">
        <asp:GridView CssClass="text-center" id="GridHiring" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" Width="900px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
            <asp:BoundField DataField="CURRENT_FIRST_NAME" HeaderText="First Name" />
            <asp:BoundField DataField="LAST_NAME" HeaderText="Last Name" />
            <asp:BoundField DataField="HIRE_DATE_FOR_WORKING" HeaderText="Hire Date" />
            <asp:BoundField DataField="EMPLOYMENT_STATUS" HeaderText="Employment Status" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    </div>
    <br />
    <br />
    </asp:Content>
