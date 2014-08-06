using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sample.Repository.Interface;

namespace Sample.Web.WebForm.Employee
{
    public partial class Details : System.Web.UI.Page
    {
        private IEmployeeRepository _repository;

        public Details()
        {
            this._repository = Global.GetInstance<IEmployeeRepository>();
        }

        private int employeeID;
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        private Sample.Domain.Employee instance;
        public Sample.Domain.Employee Instance
        {
            get
            {
                if (this.instance == null)
                {
                    var employee = this._repository.GetOne(this.EmployeeID);
                    this.instance = employee;
                }
                return instance;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.SetDefault();
            }
        }

        private void SetDefault()
        {
            int id;
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                if (!int.TryParse(Request.QueryString["id"].Trim(), out id))
                {
                    Response.Redirect("List.aspx");
                }
                else
                {
                    this.EmployeeID = id;
                    if (this.Instance == null)
                    {
                        Response.Redirect("List.aspx");
                    }
                    else
                    {
                        this.Label_EmployeeID.Text = this.Instance.EmployeeID.ToString();
                        this.TextBox_LastName.Text = this.Instance.LastName;
                        this.TextBox_FirstName.Text = this.Instance.FirstName;
                        this.TextBox_Title.Text = this.Instance.Title;
                        this.TextBox_BirthDate.Text = this.Instance.BirthDate.ToString("yyyy/MM/dd");
                        this.TextBox_HireDate.Text = this.Instance.HireDate.ToString("yyyy/MM/dd");
                    }
                }
            }
        }
    }
}