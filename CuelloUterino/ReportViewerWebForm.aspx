﻿<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ReportViewerWebForm.aspx.cs" Inherits="ReportViewerForMvc.ReportViewerWebForm" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        html,body{
            width:100%;
        }
    </style>
</head>
<body id="idBody" style="margin: 0px; padding: 0px; height:300px;">


    <form id="form1" runat="server" style="margin: 0px; padding: 0px; height:300px; overflow-x:scroll;"  width="verSize()">

        <div style="margin: 0px; padding: 0px; height:300px;" class="col col-lg-12" width="verSize()">
            <asp:ScriptManager ID="ScriptManager1" runat="server" >
                <Scripts>
                    <asp:ScriptReference Assembly="ReportViewerForMvc" Name="ReportViewerForMvc.Scripts.PostMessage.js" />
                </Scripts>
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
        </div>
    </form>
</body>

    <script>

        function setBody() {

            var a = screen.width;

            document.getElementById("idBody").style.width = a + "px";
            
        }

        setBody();
    </script>
</html>
