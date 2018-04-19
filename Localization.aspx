<%@ Register TagPrefix="cc2" Namespace="WebControlLibrary1" Assembly="WebControlLibrary1" %>
<%@ Page language="c#" Codebehind="Localization.aspx.cs" AutoEventWireup="false" Inherits="dotNetDemo.WebForm1" %>
<%@ Register TagPrefix="cc1" Namespace="CalcCtl" Assembly="CalcCtl" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id=lblGreetings style="Z-INDEX: 101; LEFT: 47px; POSITION: absolute; TOP: 36px" runat="server" Text="<%# GreetingsText %>">
			</asp:label><asp:linkbutton id="lnkJpn" style="Z-INDEX: 104; LEFT: 323px; POSITION: absolute; TOP: 114px" runat="server">Japanese</asp:linkbutton><asp:button id=btnClick style="Z-INDEX: 102; LEFT: 94px; POSITION: absolute; TOP: 111px" runat="server" Text="<%# ButtonText %>">
			</asp:button><asp:linkbutton id="lnkEnglish" style="Z-INDEX: 103; LEFT: 323px; POSITION: absolute; TOP: 89px"
				runat="server">English</asp:linkbutton></form>
	</body>
</HTML>
