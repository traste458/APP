using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;


public partial class Informacion_Publicaciones : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Mensaje.LimpiarMensaje(this);
       
        if(!Page.IsPostBack)
        llenarControles();
        //AUD-200909200236-AUD-200909200238- AUD-200909200240
        //Session["aud1"] = "AUD-200909200236";
        //Session["aud2"] = "AUD-200909200238";
        //Session["aud3"] = "AUD-200909200240";
        //this.lbl_NumVital.Text = Session["aud0"].ToString();  
        //this.lbl_NumVital.Text = "AUD-200909200236";
    this.lbl_titulo_principal.Text = "Inscritos por aprobar para audiencia p�blica n�mero: AUD-200909200236";
        //Lista de inscritos a la audicencia p�blica n�mero: 
    }

    private void llenarControles()
    {
        //DbCommand command;

        //Database db = DatabaseFactory.CreateDatabase();

        //command = db.GetStoredProcCommand("GEN_CONSULTAR_PUBLICACIONES");
        //db.AddInParameter(command, "@ID_PUBLICACION", DbType.String, string.Empty);

        //DataSet ds = db.ExecuteDataSet(command);

        //this.gvPublicaciones.DataSource = ds;
        //gvPublicaciones.DataBind();
    }

    protected void ddlPublicaciones_SelectedIndexChanged(object sender, EventArgs e)
    {
                
        
    }
    
    
    protected void gvPublicaciones_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //switch(e.CommandName)
        //{
        //    case "VerArchivo":
                                   

        //        int int_id = Convert.ToInt32(this.gvPublicaciones.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);

        //        string archivo = consultaArchivoPublicacion(int_id);

        //        string path = Server.MapPath("../" + "documentos\\" + archivo);
        //        FileInfo Archivo = new FileInfo(path);
        //        if (Archivo.Exists)
        //        {
        //            Response.Clear();
        //            Response.AddHeader("Content-Disposition", "attachment; filename=" + Archivo.Name);
        //            Response.AddHeader("Content-Length", Archivo.Length.ToString());
        //            Response.ContentType = "application/octet-stream";
        //            Response.WriteFile(Archivo.FullName);
        //            Response.End();
        //        }
        //        else
        //             Mensaje.MostrarMensaje(this, "El archivo no existe.");
        //        break;
        //}      
    }

    
    //protected string consultaArchivoPublicacion(int Id_Publicacion)
    //{
    //    //DbCommand command;

    //    //Database db = DatabaseFactory.CreateDatabase();

    //    //command = db.GetStoredProcCommand("GEN_CONSULTAR_PUBLICACIONES");
    //    //db.AddInParameter(command, "@ID_PUBLICACION", DbType.String, Id_Publicacion.ToString());

    //    //DataSet ds = db.ExecuteDataSet(command);

    //    //string archivo = ds.Tables[0].Rows[0]["ADJUNTO"].ToString();

    //    //return archivo;
    //}
    protected void gvPublicaciones_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         Mensaje.MostrarMensaje(this, "Conceptos de aprobaci�n enviados.");
    }
}
