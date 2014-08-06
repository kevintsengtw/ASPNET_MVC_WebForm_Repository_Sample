using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sample.Repository.Interface;

namespace Sample.Web.WebForm.Employee
{
    public partial class List : System.Web.UI.Page
    {
        private IEmployeeRepository _repository;

        public List()
        {
            this._repository = Global.GetInstance<IEmployeeRepository>();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.EmployeesDataBind();
            }
        }

        private void EmployeesDataBind()
        {
            var employees = this._repository.GetEmployees();
            this.GridView1.DataSource = employees;
            this.GridView1.DataKeyNames = new string[] { "EmployeeID" };
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                object primaryKey = GridView1.DataKeys[e.Row.RowIndex]["EmployeeID"];
                HyperLink HyperLink_Details = e.Row.FindControl("HyperLink_Details") as HyperLink;

                int employeeID;
                if (int.TryParse(primaryKey.ToString(), out employeeID)
                    && HyperLink_Details != null)
                {
                    HyperLink_Details.NavigateUrl = string.Concat("Details.aspx?id=", employeeID.ToString());
                }
            }
        }

    }
}