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
        //private void DisplayClient(String strClientID)
        //{
        //    DataSet dsData;

        //    dsData = clsDatabase.GetClientByID(strClientID);
        //    if (dsData == null)
        //    {
        //        txtError.Text = "Error retrieving Client";
        //    }
        //    else if (dsData.Tables.Count < 1)
        //    {
        //        txtError.Text = "Error retrieving Client";
        //        dsData.Dispose();
        //    }
        //    else
        //    {
        //        if (dsData.Tables[0].Rows[0]["Instituion"] == DBNull.Value)
        //        {
        //            txtFirstName.Text = "";
        //        }
        //        else
        //        {
        //            txtFirstName.Text = dsData.Tables[0].Rows[0]["FName"].ToString();
        //        }
        //        if (dsData.Tables[0].Rows[0]["LName"] == DBNull.Value)
        //        {
        //            txtLastName.Text = "";
        //        }
        //        else
        //        {
        //            txtLastName.Text = dsData.Tables[0].Rows[0]["LName"].ToString();
        //        }
        //        if (dsData.Tables[0].Rows[0]["MInit"] == DBNull.Value)
        //        {
        //            txtMiddleInitial.Text = "";
        //        }
        //        else
        //        {
        //            txtMiddleInitial.Text = dsData.Tables[0].Rows[0]["MInit"].ToString();
        //        }
        //        if (dsData.Tables[0].Rows[0]["Email"] == DBNull.Value)
        //        {
        //            txtEmail.Text = "";
        //        }
        //        else
        //        {
        //            txtEmail.Text = dsData.Tables[0].Rows[0]["Email"].ToString();
        //        }
        //        if (dsData.Tables[0].Rows[0]["Dept"] == DBNull.Value)
        //        {
        //            txtDepartment.Text = "";
        //        }
        //        else
        //        {
        //            txtDepartment.Text = dsData.Tables[0].Rows[0]["Dept"].ToString();
        //        }
        //        if (dsData.Tables[0].Rows[0]["Phone"] == DBNull.Value)
        //        {
        //            txtPhone.Text = "";
        //        }
        //        else
        //        {
        //            txtPhone.Text = dsData.Tables[0].Rows[0]["Phone"].ToString();
        //        }
        //        if (dsData.Tables[0].Rows[0]["HRate"] == DBNull.Value)
        //        {
        //            txtHourlyRate.Text = "";
        //        }
        //        else
        //        {
        //            txtHourlyRate.Text = dsData.Tables[0].Rows[0]["HRate"].ToString();
        //        }

        //    }
        //}
        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DisplayClient(ddlClient.SelectedValue.ToString());
            //btnRemove.Enabled = true;
            txtError.Text = "";
        }
    }
}