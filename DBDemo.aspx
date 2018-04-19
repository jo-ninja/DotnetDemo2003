<%@ Page language="c#" Codebehind="DBDemo.aspx.cs" AutoEventWireup="false" Inherits="dotNetDemo.DBDemo" errorPage="file:///C:\Inetpub\wwwroot\dotNetDemo\Localization.aspx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DBDemo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="DataGrid1" runat="server" AllowSorting="True" PageSize="3" AllowPaging="True"
				AutoGenerateColumns="False">
				<SelectedItemStyle ForeColor="White" BackColor="DeepSkyBlue"></SelectedItemStyle>
				<EditItemStyle BackColor="Gainsboro"></EditItemStyle>
				<Columns>
					<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="ID" SortExpression="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
					<asp:TemplateColumn SortExpression="Name" HeaderText="Name">
						<ItemTemplate>
							<asp:Label ID="lblName" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'>
							</asp:Label>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:TextBox Runat="server" ID="txtName" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'>
							</asp:TextBox>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn SortExpression="City" HeaderText="City">
						<ItemTemplate>
							<asp:Label Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "City") %>'>
							</asp:Label>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:TextBox Runat="server" ID="txtCity" Width="100" Text='<%# DataBinder.Eval(Container.DataItem, "City") %>'>
							</asp:TextBox>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn SortExpression="Country" HeaderText="Country">
						<ItemTemplate>
							<asp:Label Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Country") %>'>
							</asp:Label>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:TextBox Runat="server" ID="txtCountry" Width="100" Text='<%# DataBinder.Eval(Container.DataItem, "Country") %>'>
							</asp:TextBox>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="combo">
						<ItemTemplate>
							<asp:DropDownList ID="lstTes" Runat="server"></asp:DropDownList>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Update" HeaderText="Action" CancelText="Cancel"
						EditText="Edit"></asp:EditCommandColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</asp:datagrid></form>
	</body>
</HTML>
