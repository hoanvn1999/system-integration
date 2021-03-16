<%@ Page Title="" Language="C#" MasterPageFile="~/mpStandard.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="iManage.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_Search" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="justify-content-center d-flex">
    <asp:GridView ID="GridView1" CssClass="text-center" runat="server" AutoGenerateColumns="False" PageSize="5" CellPadding="4" GridLines="None" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="EMPLOYEE_ID" ForeColor="#333333">
        <AlternatingRowStyle BackColor="White" />
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
            <asp:CommandField ShowDeleteButton="True" />
            <asp:TemplateField>
                <ItemTemplate>
                      <a href="Form_Edit.aspx?EMPLOYMENT_ID=<%# Eval("EMPLOYEE_ID") %>">Edit</a>
                </ItemTemplate>
            </asp:TemplateField>
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
<%--    <div>
        <strong><em><%# DateTime.Now %></em></strong>
        <strong><em>Tên trình duyệt: <%# Request.Browser.Browser %> <br /> Phiên bản: <%# Request.Browser.MajorVersion %> <br /> Hệ điều hành: <%# Request.Browser.Platform %> <br /></em></strong>
    </div>--%>

   
</asp:Content>
