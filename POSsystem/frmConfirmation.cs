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
    public partial class frmConfirmation : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=MSI;Initial Catalog=db;Integrated Security=True");

        public frmConfirmation()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmInvetory frmInvetory = new FrmInvetory();
            frmInvetory.Show();
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            sqlCon.Open();
            string CONFIRMquery = "SELECT * FROM AdminMmber WHERE NIC='" + txtNICnum.Text.Trim() + "' AND Password='" + txtPassword.Text.Trim() + "'";
            SqlDataAdapter sqlDataAdaptr = new SqlDataAdapter(CONFIRMquery, sqlCon);
            DataTable dataTable = new DataTable();
            sqlDataAdaptr.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {
                frmAdmin formAdmin = new frmAdmin();
                formAdmin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password ");
            }
            sqlCon.Close();

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

        private void frmConfirmation_Load(object sender, EventArgs e)
        {
            txtNICnum.Focus();
        }
    }
}
