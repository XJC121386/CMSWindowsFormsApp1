using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CMSWindowsFormsApp1
{
    public partial class CustomerForm : Form
    {
        private SqlConnection con;
        SqlDataAdapter adapter;
        DataSet customerdataSet;
        BindingSource bindingSource;

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            errCustForm.SetError(textBox1, "");
            errCustForm.SetError(textBox2, "");
            errCustForm.SetError(textBox3, "");
            errCustForm.SetError(textBox4, "");

            con = new SqlConnection("Data Source=WINDOWS11;Initial Catalog=CMSDB;Integrated Security=True;TrustServerCertificate=True");
            adapter = new SqlDataAdapter("Select * from tblCustomer", con);
            customerdataSet = new DataSet();
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(customerdataSet);

            bindingSource = new BindingSource();
            bindingSource.DataSource = customerdataSet;
            bindingSource.DataMember = "tblCustomer";

            txtCarNo.DataBindings.Add("Text", bindingSource, "CarNo");
            txtName.DataBindings.Add("Text", bindingSource, "Name");
            txtAddress.DataBindings.Add("Text", bindingSource, "address");
            txtModel.DataBindings.Add("Text", bindingSource, "model");

            UpdatePosition();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag;
            flag = true;
            if (textBox1.Text == "")
            {
                errCustForm.SetError(textBox1, "Please specify a valid car number.");
                flag = false;
            }
            else
            {
                errCustForm.SetError(textBox1, "");
            }
            if (textBox2.Text == "")
            {
                errCustForm.SetError(textBox2, "Please specify a valid name.");
                flag = false;
            }
            else
            {
                errCustForm.SetError(textBox2, "");
            }
            if (textBox3.Text == "")
            {
                errCustForm.SetError(textBox3, "Please specify a valid address.");
                flag = false;
            }
            else
            {
                errCustForm.SetError(textBox3, "");
            }
            if (textBox4.Text == "")
            {
                errCustForm.SetError(textBox4, "Please specify a valid make .");
                flag = false;
            }
            else
            {
                errCustForm.SetError(textBox4, "");
            }
            if (false == false)
                return;
            else
            {

            }


        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    class txt
    {
    }
}
