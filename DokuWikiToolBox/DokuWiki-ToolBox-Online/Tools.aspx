<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tools.aspx.cs" Inherits="Tools" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p>
        Step 1</p>
    <p>
        <asp:FileUpload ID="FileUpload1" runat="server" Width="250px" />
    </p>
    Step 2<br />
    <br />
    <asp:Button ID="Btn_WordToDokuWiki" runat="server" Text="Word To DokuWiki" OnClick="Btn_WordToDokuWiki_Click" />
    <br />
    <br />
    Tools<br />
    <br />
    <asp:Button ID="Btn_ReplaceFunction" runat="server" Text="Replace Function" OnClick="Btn_ReplaceFunction_Click" />
    <asp:Button ID="Btn_HyperLinkCreator" runat="server" Text="Hyper Link Creator" OnClick="Btn_HyperLinkCreator_Click" />
    <br />
    <asp:Button ID="Btn_EncodingCleanup" runat="server" Text="Encoding Cleanup" OnClick="Btn_EncodingCleanup_Click" />
    <asp:Button ID="Btn_FileNameCorrection" runat="server" Text="File Name Correction" OnClick="Btn_FileNameCorrection_Click" />
    <br />
    <asp:Button ID="Btn_ChapterSplitter" runat="server" Text="Chapter Splitter" OnClick="Btn_ChapterSplitter_Click" />
    <asp:Button ID="Btn_LabelCreator" runat="server" Text="Label Creator" OnClick="Btn_LabelCreator_Click" />
    <br />
    <asp:Button ID="Btn_Purge" runat="server" Text="Purge" OnClick="Btn_Purge_Click" />
    <br />
    <br />
    Step 3<br />
   
    <br />
Target<br />
<asp:TextBox ID="Tb_Target" runat="server" Width="200px"></asp:TextBox>
<br />
<br />
Replacement<br />
<asp:TextBox ID="Tb_Replacement" runat="server" Width="200px"></asp:TextBox>
<br />
<br />
   
    <br />

<asp:Button ID="Btn_Launch" runat="server" Text="Launch" OnClick="Btn_Launch_Click" />

    <br />
    <br />
    <asp:Label ID="TextBlockConsole" runat="server" Text="Label"></asp:Label>

</asp:Content>

