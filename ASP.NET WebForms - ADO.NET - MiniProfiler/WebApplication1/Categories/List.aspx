<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebApplication1.Categories.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
		OnRowDataBound="GridView1_RowDataBound">
		<Columns>
			<asp:BoundField DataField="CategoryID" HeaderText="CategoryID" />
			<asp:BoundField DataField="CategoryName" HeaderText="CategoryName" />
			<asp:BoundField DataField="Description" HeaderText="Description" />
			<asp:TemplateField HeaderText="Option">
				<ItemTemplate>
					<asp:HyperLink ID="HyperLink_Details" runat="server" Text="Details"></asp:HyperLink>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>

</asp:Content>
