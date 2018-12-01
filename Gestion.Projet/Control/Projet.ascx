<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Projet.ascx.cs" Inherits="Gestion.Projet.Control.Projet" %>


    <div class="row">
	<div class="col-sm-12">
		<asp:Repeater ID="repeater" runat="server">
			<ItemTemplate>
				<%# string.Concat(DataBinder.Eval(Container.DataItem, "trigramme"),"</br>") %>
			</ItemTemplate>

		</asp:Repeater>
	</div>
</div>