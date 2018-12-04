<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Projet.ascx.cs" Inherits="Gestion.Projet.Control.Projet" %>

<h4>Liste des projets</h4>
<hr />
<div class="row">
	<div class="col-sm-8" id="table_div" runat="server">
          <table>
            <tr>
              <th class="col-sm-6">Nom</th>
              <th></th>
              <th></th>
            </tr>
              <tbody id="tbody_table" runat="server">
              </tbody>
          </table>
	</div>
</div>
<hr />
<div class="col-sm-3">
    <input type="button" class="btn btn-default" href="#myModal" value="Ajouter" data-toggle="modal" />    
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
                <asp:ValidationSummary runat="server" ID="ValidationSummary" 
            DisplayMode="BulletList"
            ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" />
			<asp:TextBox ID="nom" runat="server"></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidatorNom" 
                    runat="server"
                    ErrorMessage="Entrer le trigramme." ControlToValidate="nom"
                    Display="Dynamic" SetFocusOnError="True" CssClass="alert-text" />
           <asp:Repeater ID="dropdown_list" runat="server">              
                <ItemTemplate>
                     <asp:DropDownList ID="responsables" runat="server" AutoPostBack="true">
                       </asp:DropDownList>
                    </ItemTemplate>
               </asp:Repeater>
			<asp:Button ID="valider" runat="server" Text="Valider"/>
			<label ID="res" runat="server"></label>	
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                <asp:Button ID="btn_ajouter_projet" runat="server" Text="Ajouter" OnClick="btn_ajouter_projet_Click"/>
            </div>
        </div>
    </div>
</div>

<!-- Modal -->
<div class="modal fade" id="details" runat="server" role="dialog" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabelDetail">Details du projet</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-sm-3">
                        <label ID="Label1" runat="server">Trigramme: </label>	
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="detail_trigramme" runat="server"></asp:Label>	
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <label ID="Label2" runat="server">Responsable: </label>	
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="responsable_trigramme" runat="server"></asp:Label>	
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>

