using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;
using WebApp2BytesMusic.E_BytesMusic;

namespace WebApp2BytesMusic.Catalog
{
    public partial class CatalogManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            lblMessage.Text = string.Empty;
        }
        private void BindData()
        {
            try
            {
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/readCatalog";
                DataTable dtCatalog = new DataTable();

                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    string response = client.DownloadString(url);

                    dtCatalog = response != "" ? Util.DataConvert.JSONToDataTable(response) : setColumnsInNewDataTable();
                    if (dtCatalog != null && dtCatalog.Rows.Count > 0)
                    {
                        gridViewCatalog.DataSource = dtCatalog;
                        gridViewCatalog.DataBind();
                    }
                    else
                    {
                        dtCatalog.Rows.Add(dtCatalog.NewRow());
                        gridViewCatalog.DataSource = dtCatalog;
                        gridViewCatalog.DataBind();
                        int columncount = gridViewCatalog.Rows[0].Cells.Count;
                        gridViewCatalog.Rows[0].Cells.Clear();
                        gridViewCatalog.Rows[0].Cells.Add(new TableCell());
                        gridViewCatalog.Rows[0].Cells[0].ColumnSpan = columncount;
                        gridViewCatalog.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }


            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                return;

            }
        }
        protected DataTable setColumnsInNewDataTable()
        {
            DataTable dt = new DataTable();

            //[ID_USER] ,[USERNAME] ,[PASSWORD] ,[EMAIL], [BIRTHDAY], [USER_PHOTO],[USER_TYPE]
            //TODO: 
            dt.Columns.Add("ID_CATALOG", typeof(int));
            dt.Columns.Add("COD_CATALOG_PARENT", typeof(int));
            dt.Columns.Add("COD_CATALOG", typeof(String));
            dt.Columns.Add("VALUE", typeof(String));


            return dt;

        }
        protected void gridViewCatalog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gridViewCatalog.EditIndex)
            {
                //Label lblId = gridViewCatalog.Rows[e.RowIndex].FindControl("lblId") as Label;
                //(e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void gridViewCatalog_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViewCatalog.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void gridViewCatalog_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViewCatalog.EditIndex = -1;
            BindData();
        }

        protected void gridViewCatalog_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                string messageValidations = string.Empty;
                TextBox txtNewCodeCatalogParent = (TextBox)gridViewCatalog.FooterRow.FindControl("txtNewCodeCatalogParent");
                TextBox txtNewCodeCatalog = (TextBox)gridViewCatalog.FooterRow.FindControl("txtNewCodeCatalog");
                TextBox txtNewValue = (TextBox)gridViewCatalog.FooterRow.FindControl("txtNewValue");
                string codeCatalogParent = txtNewCodeCatalogParent.Text;
                string codeCatalog = txtNewCodeCatalog.Text;
                string valueCatalog = txtNewValue.Text;

                ECatalog catalog = new ECatalog();
                catalog.Cod_Catalog_Parent = codeCatalogParent;
                catalog.Cod_Catalog = codeCatalog;
                catalog.Value = valueCatalog;

                messageValidations = Util.Validator.CatalogValidations(catalog);
                if (messageValidations != string.Empty)
                {
                    lblMessage.Text = messageValidations;
                    return;
                }
                try
                {
                    string url = ConfigurationManager.AppSettings["apiGateway"] + "/checkExistCatalog";
                    var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                    request.Accept = "application/json";
                    request.ContentType = "application/json";
                    request.Method = "POST";
                    string requestJson = JsonConvert.SerializeObject(catalog);
                    byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                    Stream newStream = request.GetRequestStream();
                    newStream.Write(bytes, 0, bytes.Length);
                    newStream.Close();
                    newStream.Dispose();
                    var response = request.GetResponse();
                    var stream = response.GetResponseStream();
                    var sr = new StreamReader(stream).ReadToEnd();

                    int returnValue = Int32.Parse(sr);
                    //int returnValue = new BL_BytesMusic.Catalog(strConnString).CheckExist(catalog);
                    if (returnValue != 0)
                    {
                        lblMessage.Text = "Catalog already registered!";
                        return;
                    }

                    string urlSave = ConfigurationManager.AppSettings["apiGateway"] + "/saveCatalog";
                    var requestSave = (HttpWebRequest)WebRequest.Create(new Uri(urlSave));
                    requestSave.Accept = "application/json";
                    requestSave.ContentType = "application/json";
                    requestSave.Method = "POST";
                    string requestJsonSave = JsonConvert.SerializeObject(catalog);
                    byte[] bytesSave = Encoding.UTF8.GetBytes(requestJsonSave);
                    Stream newStreamSave = requestSave.GetRequestStream();
                    newStreamSave.Write(bytesSave, 0, bytesSave.Length);
                    newStreamSave.Close();
                    var responseSave = requestSave.GetResponse();
                    var streamSave = responseSave.GetResponseStream();
                    var srSave = new StreamReader(stream).ReadToEnd();
                    //                    new BL_BytesMusic.Catalog(strConnString).Save(catalog);

                    lblMessage.Text = "Se agrego correctamente el catalog";
                }
                catch (Exception exp)
                {
                    lblMessage.Text = "Error en el servidor intentelo en unos momentos";

                    return;
                }

                BindData();
            }
        }
        protected void gridViewCatalog_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string messageValidations = string.Empty;
            Label lblId = gridViewCatalog.Rows[e.RowIndex].FindControl("lblId") as Label;
            TextBox txtCodeCatalogParent = (TextBox)gridViewCatalog.Rows[e.RowIndex].FindControl("txtCodeCatalogParent");
            TextBox txtCodeCatalog = (TextBox)gridViewCatalog.Rows[e.RowIndex].FindControl("txtCodeCatalog");
            TextBox txtValue = (TextBox)gridViewCatalog.Rows[e.RowIndex].FindControl("txtValue");

            int idCatalog = Convert.ToInt32(lblId.Text);
            string codeCatalogParent = txtCodeCatalogParent.Text;
            string codeCatalog = txtCodeCatalog.Text;
            string valueCatalog = txtValue.Text;


            ECatalog catalog = new ECatalog();
            catalog.Id_Catalog = idCatalog;
            catalog.Cod_Catalog_Parent = codeCatalogParent;
            catalog.Cod_Catalog = codeCatalog;
            catalog.Value = valueCatalog;

            messageValidations = Util.Validator.CatalogValidations(catalog);
            if (messageValidations != string.Empty)
            {
                lblMessage.Text = messageValidations;
                return;
            }

            try
            {
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/checkExistCatalog";
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "POST";
                string requestJson = JsonConvert.SerializeObject(catalog);
                byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                Stream newStream = request.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
                newStream.Dispose();
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream).ReadToEnd();

                int returnValue = Int32.Parse(sr);
                //int returnValue = new BL_BytesMusic.Catalog(strConnString).CheckExist(catalog);
                //int returnValue = new BL_BytesMusic.Catalog(strConnString).CheckExist(catalog);
                if (returnValue != 0)
                {
                    lblMessage.Text = "Catalog already registered!";
                    return;
                }
                //string urlUpdate = ConfigurationManager.AppSettings["apiGateway"] + "/updateCatalog";
                //var requestUpdate = (HttpWebRequest)WebRequest.Create(new Uri(urlUpdate));

                //request.Accept = "application/json";
                //request.ContentType = "application/json";
                //request.Method = "PUT";
                //string requestJsonUpdate = JsonConvert.SerializeObject(catalog);
                //byte[] bytesUpdate = Encoding.UTF8.GetBytes(requestJsonUpdate);
                //Stream newStreamUpdate = request.GetRequestStream();
                //newStreamUpdate.Write(bytesUpdate, 0, bytesUpdate.Length);
                //newStreamUpdate.Close();
                //var responseUpdate = requestUpdate.GetResponse();
                //var streamUpdate = responseUpdate.GetResponseStream();
                //var srUpdate = new StreamReader(streamUpdate);
                ////new BL_BytesMusic.Catalog(strConnString).Update(catalog);
                //lblMessage.Text = "Se actualizo correctamente el catalog";
                string urlUpdate = ConfigurationManager.AppSettings["apiGateway"] + "/updateCatalog";
                var requestUpdate = (HttpWebRequest)WebRequest.Create(new Uri(urlUpdate));

                requestUpdate.Accept = "application/json";
                requestUpdate.ContentType = "application/json";
                requestUpdate.Method = "PUT";
                string requestJsonUpdate = JsonConvert.SerializeObject(catalog);
                byte[] bytesUpdate = Encoding.UTF8.GetBytes(requestJsonUpdate);
                using (Stream newStreamUpdate = requestUpdate.GetRequestStream())
                {
                    newStreamUpdate.Write(bytesUpdate, 0, bytesUpdate.Length);
                }
                string responseUpdateString = string.Empty;
                using (WebResponse responseUpdate = requestUpdate.GetResponse())
                {
                    using (Stream streamUpdate = responseUpdate.GetResponseStream())
                    {
                        using (StreamReader srUpdate = new StreamReader(streamUpdate))
                        {
                            responseUpdateString = srUpdate.ReadToEnd();
                        }
                    }
                }
                lblMessage.Text = string.Empty;
                gridViewCatalog.EditIndex = -1;
                BindData();
                //new BL_BytesMusic.Catalog(strConnString).Update(catalog);
                lblMessage.Text = "Se actualizo correctamente el catalog";

            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                return;

            }
           
        }

        protected void gridViewCatalog_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gridViewCatalog.DataKeys[e.RowIndex].Values[0]);

                string url = ConfigurationManager.AppSettings["apiGateway"] + "/deleteCatalog";
                url += "/" + id;
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "Delete";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                lblMessage.Text = "Se elimino correctamente el catalog";

            }
            catch (Exception exp)
            {
                lblMessage.Text = "Error en el servidor intentelo en unos momentos";
                return;
            }

            BindData();
        }
    }
}