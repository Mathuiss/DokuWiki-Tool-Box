﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tools.aspx.cs" Inherits="Tools" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="tools.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <p>
        Step 1
    </p>
    <p>
        <asp:FileUpload ID="Btn_FileUpload" runat="server" Width="250px" />
        <asp:Button ID="Btn_Submit" runat="server" OnClick="Btn_Submit_Click" Text="Submit" />
    </p>
    Step 2<br />
    <br />
    <asp:Button ID="Btn_WordToDokuWiki" runat="server" Text="Word To DokuWiki" OnClick="Btn_WordToDokuWiki_Click" />
    <br />
    <br />
    Tools
    <br />
    <div id="wrap">
        <div class="left">
            <ul>
                <li>
                    <asp:Button ID="Btn_ReplaceFunction" runat="server" Text="Replace Function" OnClick="Btn_ReplaceFunction_Click" />
                </li>
                <li>
                    <asp:Button ID="Btn_EncodingCleanup" runat="server" Text="Encoding Cleanup" OnClick="Btn_EncodingCleanup_Click" />
                </li>
                <li>
                    <asp:Button ID="Btn_ChapterSplitter" runat="server" Text="Chapter Splitter" OnClick="Btn_ChapterSplitter_Click" />
                </li>
                <li>
                    <asp:Button ID="Btn_Purge" runat="server" Text="Purge" OnClick="Btn_Purge_Click" />
                </li>
            </ul>
        </div>
        <div class="right">
            <ul>
                <li>
                    <asp:Button ID="Btn_HyperLinkCreator" runat="server" Text="Hyper Link Creator" OnClick="Btn_HyperLinkCreator_Click" />
                </li>
                <li>
                    <asp:Button ID="Btn_FileNameCorrection" runat="server" Text="File Name Correction" OnClick="Btn_FileNameCorrection_Click" />
                </li>
                <li>
                    <asp:Button ID="Btn_LabelCreator" runat="server" Text="Label Creator" OnClick="Btn_LabelCreator_Click" />
                </li>
            </ul>
        </div>
    </div>
    <br />
    Step 3

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
    <asp:Label ID="TextBlockConsole" runat="server"></asp:Label>
</asp:Content>

