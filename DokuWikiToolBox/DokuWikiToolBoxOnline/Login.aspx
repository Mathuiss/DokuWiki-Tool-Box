<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="misc_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ul>
        <li>
            <p>E-mail</p>
            <asp:TextBox ID="Tb_email" runat="server"></asp:TextBox>
        </li>
        <li>
            <p>Password</p>
            <asp:TextBox ID="Tb_password" runat="server" TextMode="Password"></asp:TextBox>
        </li>
    </ul>
    <asp:Button ID="Btn_login" runat="server" Text="Log In" />
    <asp:Button ID="Btn_register" runat="server" Text="Register" OnClick="Btn_register_Click" />
</asp:Content>

