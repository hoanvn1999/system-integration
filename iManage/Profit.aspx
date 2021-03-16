<%@ Page Title="" Language="C#" MasterPageFile="~/mpStandard.Master" AutoEventWireup="true" CodeBehind="Profit.aspx.cs" Inherits="iManage.Profit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPH_Search" runat="server">
<asp:TextBox ID="txt_search" class="form-control bg-light border-0 small" placeholder="Enter employee's ID..." runat="server"></asp:TextBox>
    <div class="input-group-append">
        <div class="position-relative btn btn-primary">            
            <i class="fas fa-search fa-sm text-white"></i>
            <asp:Button ID="btn_Search" CssClass="btn position-absolute fixed-top" runat="server" Text="   " OnClick="ButtonSearchPF_Click"/>
        </div>
    </div>   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center text-primary mt-5 mb-5">Profit Summarized</h1>
    <div class="d-flex justify-content-center">
        <asp:GridView CssClass="text-center" ID="GridViewProfit" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="900px">
            <Columns>
                <%--Hiển thị dữ liệu từ bảng PERSONAL--%>
                <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="Employee ID" />
                <asp:BoundField DataField="CURRENT_FIRST_NAME" HeaderText="First Name" />
                <asp:BoundField DataField="CURRENT_LAST_NAME" HeaderText="Last Name" />
                <%--Hiển thị dữ liệu từ bảng BENEFIT_PLANS--%>
                <asp:BoundField DataField="PERCENTAGE_COPAY" HeaderText="Average Benefits Paid" />
                <asp:BoundField DataField="DEDUCTABLE" HeaderText="DEDUCTABLE" />
            </Columns>
            <%--Xét thuộc tính Classic cho GridView--%>
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
