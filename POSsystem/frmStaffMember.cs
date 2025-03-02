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
    public partial class frmStaffMember : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=MSI;Initial Catalog=db;Integrated Security=True");

        public frmStaffMember()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmStaff stafForm = new frmStaff();
            stafForm.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void getStfMembrID()
        {
            try
            {
                sqlCon.Open();

                string getStffIDquery = "SELECT StaffMembrID FROM StafMmbr";
                SqlCommand getstfIDcmd = new SqlCommand(getStffIDquery, sqlCon);

                SqlDataReader staffIDreader = getstfIDcmd.ExecuteReader();
                while (staffIDreader.Read())
                {
                    string stID = staffIDreader.GetValue(0).ToString();
                    int stfID = int.Parse(stID);
                    int stffID = stfID + 1;
                    txtStMemberID.Text = stffID.ToString();
                }
                sqlCon.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStMemberID.Text = string.Empty;
            txtStName.Text = string.Empty;
            txtStfNIC.Text = string.Empty;
            txtStContct.Text = string.Empty;
            txtAdres.Text = string.Empty;
            txtPwd.Text = string.Empty;

            getStfMembrID();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
                try
                {
                    sqlCon.Open();
                    string StafQuery = "INSERT INTO StafMmbr values ('" + txtStName.Text + "','" + txtStfNIC.Text + "','" + txtStContct.Text + "','" + txtAdres.Text + "','" + txtPwd.Text + "')";
                    SqlCommand stafComnd = new SqlCommand(StafQuery, sqlCon);
                    stafComnd.ExecuteNonQuery();

                    MessageBox.Show("Add Staff Member Successfully");

                    sqlCon.Close();

                }
                catch (Exception exx)
                {
                    MessageBox.Show(exx.Message);
                }
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            sqlCon.Open();

            string DeleteQuery = "DELETE FROM StafMmbr WHERE StaffMembrID = '" + txtStMemberID.Text + "'";
            SqlCommand DELETEcmd = new SqlCommand(DeleteQuery, sqlCon);

            SqlDataReader DELETEreader;

            try
            {
                DELETEreader = DELETEcmd.ExecuteReader();
                MessageBox.Show("Delete Staff Member Successfully");

                while (DELETEreader.Read())
                {
                }
                sqlCon.Close();
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        private void frmStaffMember_Load(object sender, EventArgs e)
        {
            getStfMembrID();
        }

        private void btnStfUpdate_Click(object sender, EventArgs e)
        {

            sqlCon.Open();

            string UPDTquery = "UPDATE StafMmbr SET  Name='" + txtStName.Text + "', NIC='" + txtStfNIC.Text + "', ContactNO='" + txtStContct.Text + "', Adress='" + txtAdres.Text + "', Password='" + txtPwd.Text + "' WHERE StaffMembrID = '" + txtStMemberID.Text + "' ;";
            SqlCommand UPDTcmd = new SqlCommand(UPDTquery, sqlCon);
          
            try
            {
                SqlDataReader UPDTreader = UPDTcmd.ExecuteReader();
                MessageBox.Show("Update Staff Member Successfully");

                while (UPDTreader.Read())
                {
                }
                sqlCon.Close();
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        private void btnStfSearch_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            if (txtStMemberID.Text != "")
            {
                string qry = "SELECT Name, NIC, ContactNO, Adress, Password FROM StafMmbr WHERE StaffMembrID=@StaffMembrID";

                SqlCommand SRCHcmd = new SqlCommand(qry, sqlCon);
                SRCHcmd.Parameters.AddWithValue("@StaffMembrID", int.Parse(txtStMemberID.Text));
                try
                {
                    SqlDataReader SRCHreader = SRCHcmd.ExecuteReader();
                    MessageBox.Show("Searched Staff Member");

                    while (SRCHreader.Read())
                    {
                        // txtAdminID.Text = UPDTreader.GetValue(0).ToString();
                        txtStName.Text = SRCHreader.GetValue(0).ToString();
                        txtStfNIC.Text = SRCHreader.GetValue(1).ToString();
                        txtStContct.Text = SRCHreader.GetValue(2).ToString();
                        txtAdres.Text = SRCHreader.GetValue(3).ToString();
                        txtPwd.Text = SRCHreader.GetValue(4).ToString();
                    }
                    sqlCon.Close();

                }
                catch (Exception eexx)
                {
                    MessageBox.Show(eexx.Message);
                }
            }
        }

        private void chckboxShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chckboxShowPwd.Checked == true)
            {
                txtPwd.UseSystemPasswordChar = false;

            }
            else
            {
                txtPwd.UseSystemPasswordChar = true;
            }
        }
    }
}
