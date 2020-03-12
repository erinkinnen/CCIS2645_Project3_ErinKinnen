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

        private Boolean FormValidation()
        {
            Boolean blnOk = true;
            String strMessage = "";
            txtError.Text = "";

            if(ddlClient.SelectedIndex == 0)
            {
                blnOk = false;
                strMessage += "Please select a Client from the dropdown";
            }

            if(txtContact.Text.Trim().Length < 1)
            {
                blnOk = false;
                strMessage += " Contact is required.";
            }

            if(!Int64.TryParse(txtPhone.Text.Trim(), out Int64 result))
            {
                blnOk = false;
                strMessage += "Phone number is required. ";
            }
            else if (result.ToString().Length != 10)
            {
                blnOk = false;
                strMessage += "Phone number must be 10 digits.";
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