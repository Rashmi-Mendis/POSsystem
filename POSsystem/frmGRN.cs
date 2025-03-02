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

namespace POSsystem
{
    public partial class frmGRN : Form
    {
       // int x = 1;
        int index;
        SqlConnection sqlCon = new SqlConnection(@"Data Source=MSI;Initial Catalog=db;Integrated Security=True");
        public frmGRN()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmInvetory invetory = new FrmInvetory();
            invetory.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Open();
                string addGRNquery = "INSERT INTO GRN values('" + dateTPickerGRN.Value.Date + "','" + txtitemID.Text + "','" + txtDescript.Text + "','" + txtUnitPrice.Text + "','" + txtQuantity.Text + "' ,'" + dateTPickerExpDate.Value.Date + "', '" + txtTotFee.Text + "' ) ";

                SqlCommand addGRNcomnd = new SqlCommand(addGRNquery, sqlCon);
                addGRNcomnd.ExecuteNonQuery();

                MessageBox.Show("successfully added");

                sqlCon.Close();

                ReceivedData();
                //dgvGRN.Rows.Add(dateTPickerGRN.Value.Date, txtGRN.Text, txtitemID.Text, txtDescript.Text, txtUnitPrice.Text, txtQuantity.Text, dateTPickerExpDate.Value.Date, txtTotFee.Text); //alternative 2         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }    
             
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            sqlCon.Open();

            string invoiceDELETEquery = "DELETE FROM GRN WHERE ItemId = '" + txtitemID.Text + "' ";
            SqlCommand invoiceDELETEcmd = new SqlCommand(invoiceDELETEquery, sqlCon);

            SqlDataReader invoiceDELETEreader;

            try
            {
                invoiceDELETEreader = invoiceDELETEcmd.ExecuteReader();
                MessageBox.Show("Delete GRN Record Successfully");

                while (invoiceDELETEreader.Read())
                {
                }
                sqlCon.Close();
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
            sqlCon.Open();

            //string DeleteRECORDquery = "DELETE FROM GRN WHERE GRNNO = '" + txtGRN.Text + "' ";
            //SqlCommand deleteRECORDcmd = new SqlCommand(DeleteRECORDquery, sqlCon);
    
            //SqlDataReader deleteRECORDreader;

            //try
            //{
            //    deleteRECORDreader = deleteRECORDcmd.ExecuteReader();
            //    MessageBox.Show("Delete GRN Record Successfully");

            //    while (deleteRECORDreader.Read())
            //    {
            //    }
            //    sqlCon.Close();
            //}
            //catch (Exception exx)
            //{
            //    MessageBox.Show(exx.Message);
            //}

            index = dgvGRN.CurrentCell.RowIndex;
            dgvGRN.Rows.RemoveAt(index);


            //dgvGRN.Rows.RemoveAt(dateTPickerGRN.Text, txtGRN.Text, txtitemID.Text, txtDescript.Text, txtUnitPrice.Text, txtQuantity.Text, dateTPickerExpDate.Text, txtTotFee.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //txtGRN.Text = string.Empty;
            txtitemID.Text = string.Empty;
            txtDescript.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtTotFee.Text = string.Empty;

            GetGRNno();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            string UPDTquery = "UPDATE GRN SET  Date='" + dateTPickerGRN.Text + "', ItemId='" + txtitemID.Text + "',Description='" + txtDescript.Text+"', UnitPrice='" + txtUnitPrice.Text + "', Quantity='" + txtQuantity.Text + "', ExpDate='"+dateTPickerExpDate.Text+"', TotalFee='"+txtTotFee.Text+"' WHERE GRNNO = '" + txtGRN.Text + "' ;";
            SqlCommand UPDTcmd = new SqlCommand(UPDTquery, sqlCon);

            try
            {
                SqlDataReader UPDTreader = UPDTcmd.ExecuteReader();
                MessageBox.Show(" Good Received Table Successfully Updated");

                while (UPDTreader.Read())
                {
                }
                sqlCon.Close();
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }

            DataGridViewRow newData = dgvGRN.Rows[index];

            newData.Cells[0].Value = dateTPickerGRN.Value.Date;
            newData.Cells[1].Value = txtGRN.Text;
            newData.Cells[2].Value = txtitemID.Text;
            newData.Cells[3].Value = txtDescript.Text;
            newData.Cells[4].Value = txtUnitPrice.Text;
            newData.Cells[5].Value = txtQuantity.Text;
            newData.Cells[6].Value = dateTPickerExpDate.Value.Date;
            newData.Cells[7].Value = txtTotFee.Text;
        }

        private void dgvGRN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dgvGRN.Rows[index];

            dateTPickerGRN.Text = row.Cells[0].Value.ToString();
            txtGRN.Text = row.Cells[1].Value.ToString();
            txtitemID.Text = row.Cells[2].Value.ToString();
            txtDescript.Text = row.Cells[3].Value.ToString();
            txtUnitPrice.Text = row.Cells[4].Value.ToString();
            txtQuantity.Text = row.Cells[5].Value.ToString();
            dateTPickerExpDate.Text = row.Cells[6].Value.ToString();
            txtTotFee.Text = row.Cells[7].Value.ToString();
        }

        private void ReceivedData()
        {
            sqlCon.Open();
            string getDBVALUESquery = "SELECT * FROM GRN";
            SqlDataAdapter getDBVALUESdataAdapter = new SqlDataAdapter(getDBVALUESquery, sqlCon);
            // SqlCommandBuilder 

            var data = new DataSet();
            getDBVALUESdataAdapter.Fill(data);
            dgvGRN.DataSource = data.Tables[0];
            sqlCon.Close();

        }

        private void GetGRNno()
        {
            try
            {
                sqlCon.Open();
                string getGRNnumquery = "SELECT GRNno FROM GRN";

                SqlCommand getGRNnumcmd = new SqlCommand(getGRNnumquery, sqlCon);

                SqlDataReader GRNnumdataReader = getGRNnumcmd.ExecuteReader();

                while (GRNnumdataReader.Read())
                {
                    string grnNO = GRNnumdataReader.GetValue(0).ToString();
                    int GRNno = int.Parse(grnNO);
                    int NO = GRNno+1;
                    txtGRN.Text = NO.ToString();
                }
                sqlCon.Close();
            }catch(Exception e)
            {
                MessageBox.Show("Clear text feilds");
            }
           
        }

        private void frmGRN_Load(object sender, EventArgs e)
        {
           ReceivedData();
            GetGRNno();
            
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            //if (float.Parse(txtQuantity.Text) >=0)
            //{
            //   float total = float.Parse(txtUnitPrice.Text) * float.Parse(txtQuantity.Text);
            //    txtTotFee.Text = total.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Invalid Number");
            //}

            //this is error showing when empty textbox.... 
        }

        private void txtQuantity_Enter(object sender, EventArgs e)
        {
           // txtTotFee.Text = (float.Parse(txtUnitPrice.Text) * float.Parse(txtQuantity.Text)).ToString();
           //mistake
        }

        private void txtUnitPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                float total = float.Parse(txtUnitPrice.Text) * float.Parse(txtQuantity.Text);
                txtTotFee.Text = total.ToString();
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                float total = float.Parse(txtUnitPrice.Text) * float.Parse(txtQuantity.Text);
                txtTotFee.Text = total.ToString();
            }
        }
    }
}

