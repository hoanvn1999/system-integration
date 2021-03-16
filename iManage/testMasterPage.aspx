<%@ Page Title="" Language="C#" MasterPageFile="~/mpStandard.Master" AutoEventWireup="true" CodeBehind="testMasterPage.aspx.cs" Inherits="iManage.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grd_test" runat="server" AutoGenerateColumns="False" Visible="False">
        <Columns>
            <asp:BoundField DataField="USER_NAME" HeaderText="Username" />
            <asp:BoundField DataField="PASSWORD" HeaderText="Passwd" />
        </Columns>
    </asp:GridView>
</asp:Content>
