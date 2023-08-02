using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp2BytesMusic
{
    public partial class Desktop : System.Web.UI.Page
    {
        protected int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
                userId = Convert.ToInt32(Request.QueryString["uid"]);
            else
                userId = Convert.ToInt32(Session[Util.Constants.USER]);
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            //DataTable dtPlayerlist = new ServiceReferencePlaylist.PlaylistSoapClient().ReadById(userId);

            //if (dtPlayerlist != null && dtPlayerlist.Rows.Count > 0)
            //{
            //    dlPlaylist.DataSource = dtPlayerlist;
            //    dlPlaylist.DataBind();
            //}
            //else
            //{
            //    dtPlayerlist.Rows.Add(dtPlayerlist.NewRow());
            //    dlPlaylist.DataSource = dtPlayerlist;
            //    dlPlaylist.DataBind();
            //}
            string url = ConfigurationManager.AppSettings["apiGateway"] + "/readPlaylist";
            url += "/" + userId;
            DataTable dtPlayerlist = new DataTable();
            using (var client = new WebClient())
            {

                try
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    string response = client.DownloadString(url);
                    dtPlayerlist = response != "" ? Util.DataConvert.JSONToDataTable(response) : null;
                    if (dtPlayerlist != null && dtPlayerlist.Rows.Count > 0)
                    {
                        dlPlaylist.DataSource = dtPlayerlist;
                        dlPlaylist.DataBind();
                    }
                    else
                    {
                        dtPlayerlist.Rows.Add(dtPlayerlist.NewRow());
                        dlPlaylist.DataSource = dtPlayerlist;
                        dlPlaylist.DataBind();
                    }
                }
                catch(Exception exp)
                {
                    return;
                }
               
            }

        }

        protected void dlPlaylist_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
             e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddList = (DropDownList)e.Item.FindControl("ddlType");
                /*  DataTable dt = new ServiceReferenceCatalog.CatalogSoapClient().GetPlaylistType();*/
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/getPlaylistType";
                DataTable dt = new DataTable();
                using (var client = new WebClient())
                {
                    try
                    {
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        client.Headers[HttpRequestHeader.Accept] = "application/json";
                        string response = client.DownloadString(url);
                        dt = response != "" ? Util.DataConvert.JSONToDataTable(response) : null;
                        ddList.DataSource = dt;
                        ddList.DataTextField = "VALUE";
                        ddList.DataValueField = "COD_CATALOG";
                        ddList.DataBind();

                        DataRowView dr = e.Item.DataItem as DataRowView;
                        ddList.SelectedValue = dr["TYPE"].ToString();
                    }catch(Exception exp)
                    {
                        return;

                    }


                }
         
                    
            }
        }
    }
}