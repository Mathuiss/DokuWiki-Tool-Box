<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ul>
        <li>
            <p>All items with a * are mandatory</p>
        </li>
        <li>
            <p>Name*</p>
            <asp:TextBox ID="Tb_name" runat="server"></asp:TextBox>
        </li>                
        <li>                 
            <p>E-mail*</p> 
            
            <asp:TextBox ID="Tb_email" runat="server"></asp:TextBox>
        </li>                
        <li>                 
            <p>Password*</p> 
            <asp:TextBox ID="Tb_password" runat="server" TextMode="Password"></asp:TextBox>
        </li>
        <li>
            <p>Re-enter Password*</p>
            <asp:TextBox ID="Tb_password2" runat="server" TextMode="Password"></asp:TextBox>
        </li>
    </ul>
    <asp:Button ID="Btn_register" runat="server" Text="Register" OnClick="Btn_register_Click" />
    <asp:SqlDataSource ID="db_connector" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
</asp:Content>

