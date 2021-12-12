using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeePageDataAccess;
using EmployeePageEntity;

namespace Employee
{
    public partial class EmployeePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDDl();
                populateGrid();
            }

        }

        private void populateGrid()
        {
            EmployeeDataAccess da = new EmployeeDataAccess();
            DataTable dt = da.getGridData();
            gvEmployee.DataSource = dt;
            gvEmployee.DataBind();
        }

        private void bindDDl()
        {
            EmployeeDataAccess da = new EmployeeDataAccess();
            DataTable dt = da.getDDLData(); 
            ddlDepartment.DataValueField = dt.Columns[0].ToString();
            ddlDepartment.DataTextField = dt.Columns[1].ToString();
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, "--Select--");
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeDataAccess da = new EmployeeDataAccess();
                EmployeeEntity en = new EmployeeEntity();
                en.StrFirstName = txtFirstName.Text;
                en.StrLastName = txtLastName.Text;
                en.IntDepartment = Convert.ToInt16(ddlDepartment.SelectedValue);
                if (rdBtnMale.Checked)
                {
                    en.BoolGender = true;
                }
                else
                    en.BoolGender = false;

                if (btnAdd.Text == "Update")
                {
                    int intRegId = Convert.ToInt32(Session["regidSession"]);
                    if (da.UpdateRecord(en, intRegId))
                    {
                        lblMsg.Text = "Registration Updated";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMsg.Text = "Updation failed";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    if (da.Add(en))
                    {
                        lblMsg.Text = "Registration done";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMsg.Text = "Registration failed";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                btnAdd.Text = "Add";
                populateGrid();
                ClrControl();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

      

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            Session["regidSession"]  = e.CommandArgument;
            Int32 intSession= Convert.ToInt32(Session["regidSession"]);
            EmployeeDataAccess da = new EmployeeDataAccess();
            DataTable dt = da.getRegData(intSession);
            txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            txtLastName.Text = dt.Rows[0]["LastName"].ToString();
            ddlDepartment.SelectedValue = dt.Rows[0]["DeptId"].ToString();          
            if (Convert.ToBoolean(dt.Rows[0]["Gender"])==true )
            {
                rdBtnMale.Checked = true;
            }
            else if (Convert.ToBoolean(dt.Rows[0]["Gender"]) == false)
            {
                rdBtnFemale.Checked = true;
            }
            else
            {
                rdBtnMale.Checked = false;
                rdBtnFemale.Checked = false;
            }
            btnAdd.Text = "Update";
        }

        protected void btnDel_Command(object sender, CommandEventArgs e)
        {
            EmployeeDataAccess da = new EmployeeDataAccess(); 
            Int32 intRegid = Convert.ToInt32(e.CommandArgument);           
                if (da.DeleteRecord(intRegid))
                    {
                        lblMsg.Text = "Record deleted";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        populateGrid();

                    }
                    else
                    {
                        lblMsg.Text = "deletion failed";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }

        }

        private void ClrControl()
        {
            try
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                ddlDepartment.SelectedIndex = 0;
                rdBtnFemale.Checked = false;
                rdBtnMale.Checked = false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}