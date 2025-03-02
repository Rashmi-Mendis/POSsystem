using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POSsystem
{
    public partial class frmLogin : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=MSI;Initial Catalog=db;Integrated Security=True");

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try 
            {
                if (cmbAdmnORstaf.SelectedItem.ToString() == "Admin Member")
                {
                    sqlCon.Open();
                    string LoginQuery = "SELECT * FROM AdminMmber WHERE Name='" + txtUsername.Text.Trim() + "' AND Password='" + txtPassword.Text.Trim() + "'";
                    SqlDataAdapter SqldataAdptr = new SqlDataAdapter(LoginQuery, sqlCon);
                    DataTable dataTable = new DataTable();
                    SqldataAdptr.Fill(dataTable);

                    if (dataTable.Rows.Count == 1)
                    {
                        frmAdmin formAdmin = new frmAdmin();
                        formAdmin.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password ");
                    }
                    sqlCon.Close();

                }else if (cmbAdmnORstaf.SelectedItem.ToString() == "Staff Member")
                {
                    sqlCon.Open();
                    string LognQuery = "SELECT * FROM  StafMmbr WHERE Name='" + txtUsername.Text.Trim() + "' AND Password='" + txtPassword.Text.Trim() + "'";
                    SqlDataAdapter sqlDataAdaptr = new SqlDataAdapter(LognQuery, sqlCon);
                    DataTable dataTable = new DataTable();
                    sqlDataAdaptr.Fill(dataTable);

                    if (dataTable.Rows.Count == 1)
                    {
                        frmStaff formStaff = new frmStaff();
                        formStaff.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password ");
                    }
                    sqlCon.Close();
                }
                else
                {
                    MessageBox.Show("Please Select Admin Member or Staff Member");
                }
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }
        private void btnExitt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnShowPwd_Click(object sender, EventArgs e)
        {

        }

        private void chckboxShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chckboxShowPwd.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;

            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
