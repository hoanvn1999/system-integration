<%@ Page Title="" Language="C#" MasterPageFile="~/mpStandard.Master" AutoEventWireup="true" CodeBehind="personalInfo.aspx.cs" Inherits="iManage.personalInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_Search" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <h1 class="text-primary font-weight-bold mt-5 mb-5">Personal Information</h1>
        <asp:Repeater ID="rep_individual_info" runat="server">
            <ItemTemplate>
                <div class="rounded-circle overflow-hidden d-block m-auto" style="height:250px; width:250px">
                    <img src="https://source.unsplash.com/weekly?man/60x60" style="width:250px">
                </div>                
                <h4 class="mt-3"><b>Fullname:</b> <%# Eval("FULL_NAME") %></h4>             
           
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
