using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CCIS2645_Project3_ErinKinnen
{
    public partial class ServiceEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEventDate.Text = DateTime.Now.ToString("MM-dd-yyyy");
            txtError.Text = "Error Message";

            if (!IsPostBack)
            {
                LoadClients();
            }
        }

        protected void btnMain_ServiceEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlClient.SelectedIndex = 0;
            txtContact.Text = "";
            txtPhone.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        //METHODS

        private void LoadClients()
        {
            DataSet dsData;

            dsData = clsDatabase.GetClientList();
            if (dsData == null)
            {
                txtError.Text = "Error retrieving Client List";
            }
            else if (dsData.Tables.Count < 1)
            {
                txtError.Text = "Error retrieving Client List";
                dsData.Dispose();
            }
            else
            {
                ddlClient.DataSource = dsData.Tables[0];
                ddlClient.DataTextField = "ClientName";
                ddlClient.DataValueField = "ClientID";
                ddlClient.DataBind();

                ddlClient.Items.Insert(0, new ListItem("-- CLIENT --"));
                ddlClient.SelectedIndex = 0;
                dsData.Dispose();
            }
        }
        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DisplayClient(ddlClient.SelectedValue.ToString());
            //btnRemove.Enabled = true;
            txtError.Text = "";
        }
    }
}