<%@ Page language="c#" Codebehind="CustomWebControls.aspx.cs" AutoEventWireup="false" Inherits="dotNetDemo.CustomWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="CalcCtl" Assembly="CalcCtl" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CustomWebControls</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT>
				<cc1:SimpleCalc id="SimpleCalc1" style="Z-INDEX: 101; LEFT: 53px; POSITION: absolute; TOP: 38px"
					runat="server" Text2="4" Text1="2" HeaderText="Addition"></cc1:SimpleCalc>
				<cc1:SimpleCalc id="SimpleCalc5" style="Z-INDEX: 105; LEFT: 261px; POSITION: absolute; TOP: 199px"
					runat="server" Text2="4" Text1="2" HeaderText="a + b + 2" CalculationOperation="Custom"></cc1:SimpleCalc>
				<cc1:SimpleCalc id="SimpleCalc4" style="Z-INDEX: 104; LEFT: 464px; POSITION: absolute; TOP: 40px"
					runat="server" Text2="4" Text1="2" HeaderText="Addition" CalculationOperation="Division"></cc1:SimpleCalc>
				<cc1:SimpleCalc id="SimpleCalc3" style="Z-INDEX: 103; LEFT: 330px; POSITION: absolute; TOP: 39px"
					runat="server" Text2="4" Text1="2" HeaderText="Addition" CalculationOperation="Multiplication"></cc1:SimpleCalc>
				<cc1:SimpleCalc id="SimpleCalc2" style="Z-INDEX: 102; LEFT: 191px; POSITION: absolute; TOP: 38px"
					runat="server" Text2="4" Text1="2" HeaderText="Addition" CalculationOperation="Subtraction"></cc1:SimpleCalc></FONT>
		</form>
	</body>
</HTML>
