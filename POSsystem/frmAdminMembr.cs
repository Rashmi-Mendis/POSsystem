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
    public partial class frmAdminMembr : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=MSI;Initial Catalog=db;Integrated Security=True");

        public frmAdminMembr()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmAdmin admnForm = new frmAdmin();
            admnForm.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
             Application.Exit();
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAdminID.Text = string.Empty;
            txtAdminName.Text = string.Empty;
            txtAdminNIC.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtAdminAdress.Text = string.Empty;
            txtAdminPwd.Text = string.Empty;

            getAdminID();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Open();
                string AddingAdmnquery = "INSERT INTO AdminMmber values ('" + txtAdminName.Text + "','" + txtAdminNIC.Text + "','" + txtContact.Text + "','" + txtAdminAdress.Text + "','" + txtAdminPwd.Text + "')";
                SqlCommand AddingadmnComnd = new SqlCommand(AddingAdmnquery, sqlCon);
                AddingadmnComnd.ExecuteNonQuery();

                MessageBox.Show("Add Admin Member Successfully");

                sqlCon.Close();

            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }
        private void getAdminID()
        {
            try
            {
                sqlCon.Open();

                string getAdmnIDquery = "SELECT AdminId FROM AdminMmber";
                SqlCommand getAdmnIDcmd = new SqlCommand(getAdmnIDquery, sqlCon);

                SqlDataReader admnIDreader = getAdmnIDcmd.ExecuteReader();
                while (admnIDreader.Read())
                {
                    string adID = admnIDreader.GetValue(0).ToString();
                    int admnID = int.Parse(adID);
                    int adminID = admnID + 1;
                    txtAdminID.Text = adminID.ToString();
                }
                    sqlCon.Close();                       
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void frmAdminMembr_Load(object sender, EventArgs e)
        {
            getAdminID();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
                sqlCon.Open();

                string DELETEquery = "DELETE FROM AdminMmber WHERE AdminId = '" + txtAdminID.Text + "'";
                SqlCommand DELETEcmd = new SqlCommand(DELETEquery, sqlCon);
            //DELcmd.Parameters.AddWithValue("@AdminId", int.Parse(txtAdminID.Text));
            SqlDataReader DELETEreader;

                try
                {
                DELETEreader = DELETEcmd.ExecuteReader();
                    MessageBox.Show("Delete Admin Member Successfully");

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
        private void SearchADMINData()
        {
            sqlCon.Open();
            if (txtAdminID.Text != "")
            {
                string SearchQuery = "SELECT Name, NIC, ContactNO, Adress, Password FROM AdminMmber WHERE AdminId =@AdminId";

                SqlCommand SRCHcmd = new SqlCommand(SearchQuery, sqlCon);
                SRCHcmd.Parameters.AddWithValue("@AdminId", int.Parse(txtAdminID.Text));
                try
                {
                    SqlDataReader SRCHreader = SRCHcmd.ExecuteReader();
                    MessageBox.Show("Searched Admin Member");

                    while (SRCHreader.Read())
                    {
                        // txtAdminID.Text = SRCHreader.GetValue(0).ToString();
                        txtAdminName.Text = SRCHreader.GetValue(0).ToString();
                        txtAdminNIC.Text = SRCHreader.GetValue(1).ToString();
                        txtContact.Text = SRCHreader.GetValue(2).ToString();
                        txtAdminAdress.Text = SRCHreader.GetValue(3).ToString();
                        txtAdminPwd.Text = SRCHreader.GetValue(4).ToString();
                    }
                    sqlCon.Close();

                }
                catch (Exception eexx)
                {
                    MessageBox.Show(eexx.Message);
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
 
                sqlCon.Open();

                string UPDTquery = "UPDATE AdminMmber SET  Name='"+txtAdminName.Text+"', NIC='"+txtAdminNIC.Text+"', ContactNO='"+txtContact.Text+"', Adress='"+txtAdminAdress.Text+"', Password='"+txtAdminPwd.Text+ "' WHERE AdminId = '" + txtAdminID.Text + "' ;";
                SqlCommand UPDTcmd = new SqlCommand(UPDTquery, sqlCon);
              //  DELcmd.Parameters.AddWithValue("@AdminId", int.Parse(txtAdminID.Text));


                try
                {
                    SqlDataReader UPDTreader = UPDTcmd.ExecuteReader();
                    MessageBox.Show("Update Admin Member Successfully");

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchADMINData();
        }

        private void chckboxShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chckboxShowPwd.Checked == true)
            {
                txtAdminPwd.UseSystemPasswordChar = false;

            }
            else
            {
                txtAdminPwd.UseSystemPasswordChar = true;
            }
        }
    }
}

