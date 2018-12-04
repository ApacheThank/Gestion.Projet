<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Jalon.ascx.cs" Inherits="Gestion.Projet.Control.JalonControl" %>



<h3 ID="projet_trigramme" runat="server">Projet: </h3>
<h5>Liste des jalons</h5>
<hr />
<label ID="id_label" runat="server"></label>	
<div class="row">
	<div class="col-sm-4">
		<asp:Repeater ID="repeater" runat="server">
			<ItemTemplate>
                <a href="/Jalon/<%# DataBinder.Eval(Container.DataItem, "id") %>" class="list-group-item list-group-item-action"><%# DataBinder.Eval(Container.DataItem, "libelle") %></a>
                <input type="button" class="btn btn-warning" href="#myModal" value="Editer" data-toggle="modal" />
                <input type="button" class="btn btn-danger" href="#" value="Supprimer" data-toggle="modal" />
            </ItemTemplate>
		</asp:Repeater>
	</div>
</div>

<!-- Modal -->
<div class="modal fade" id="myModal" role="dialog" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Ajout un jalon</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                <button type="submit" class="btn btn-primary">Ajouter</button>
            </div>
        </div>
    </div>
</div>