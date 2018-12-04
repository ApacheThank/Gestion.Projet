using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Gestion.Projet.Bean;
using Gestion.Projet.Service;

namespace Gestion.Projet.Control
{
    public partial class Projet: System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                List<Project> projets = FactoryServices.createServices().getProjets();
                StringBuilder html = new StringBuilder();
                Table tb = new Table();
                foreach (var projet in projets)
                {
                    TableRow tr = new TableRow();
                    TableCell td1 = new TableCell();
                    TableCell td2 = new TableCell();
                    TableCell td3 = new TableCell();
                    td1.CssClass = "col-sm-6";
                    td1.Text = projet.Trigramme;
                    td2.CssClass = "col-sm-6";
                    td3.CssClass = "col-sm-6";
                    Button btn_edit = new Button();
                    btn_edit.CssClass = "btn btn-warning";
                    btn_edit.Text = "Editer";
                    btn_edit.OnClientClick = "btn_editer_Click";
                    Button btn_delete = new Button();
                    btn_delete.CssClass = "btn btn-danger";
                    btn_delete.Text = "Supprimer";
                    btn_delete.OnClientClick = "btn_supprimer_Click";
                    HyperLink anchor = new HyperLink();
                    anchor.Attributes.Add("href","/About?id="+projet.Id+"&nom="+projet.Trigramme);
                    anchor.CssClass = "list-group-item list-group-item-action";
                    td1.Controls.Add(anchor);
                    td2.Controls.Add(btn_edit);
                    td3.Controls.Add(btn_delete);
                    tr.Cells.Add(td1);
                    tr.Cells.Add(td2);
                    tr.Cells.Add(td3);
                    tbody_table.Controls.Add(tr);
                    //tb.Rows.Add(tr);
                }
                //table_div.Controls.Add(tb);
            Debug.Write("page Load here :::");
        }

        protected void btn_editer_Click(object sender, EventArgs e)
        {
            int id = 2;
            Debug.Write(id);
            Project project = FactoryServices.createServices().getProjectById(id);
            string trigramme = project.Trigramme;
            string Id_responsable = project.Id_responsable.ToString();
            Debug.WriteLine("Parameters: {0}, {1}", trigramme, Id_responsable);

        }

        protected void btn_ajouter_projet_Click(object sender, EventArgs e)
        {
            int id = 2;
            string trigramme = nom.Text;
            bool res = FactoryServices.createServices().insertProjet(trigramme, id);
            Debug.Write(res);

        }

        protected void btn_supprimer_Click(object sender, EventArgs e)
        {
            Debug.Write("supprimer button");
        }
    }
}