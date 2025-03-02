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
    public partial class frmInvoice : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=MSI;Initial Catalog=db;Integrated Security=True");
        
        int indexx;
        public frmInvoice()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           // bool isStaff = true;
            FrmInvetory inventry = new FrmInvetory(); //isStaff
            inventry.Show();
            this.Hide();
        }
        private void ReceiveData()
        {
            sqlCon.Open();
            string ReceiveQuery = "SELECT InvoiceNO  FROM Invoice";

            SqlCommand cmd = new SqlCommand(ReceiveQuery, sqlCon);

            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                txtInvoiceNo.Text = dataReader.GetValue(0).ToString();
            }
            sqlCon.Close();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

            try {
                sqlCon.Open();
                string invoiceADDquery = "INSERT INTO Invoice values('" + txtItemId.Text + "','" + cmbDecript.SelectedItem.ToString() + "', '" + txtQty.Text + "','" + txtPrice.Text + "', '" + txtTotal.Text + "', '" + dateTPickrInvoice.Value.Date + "' ) ";

                SqlCommand invoiceADDcomnd = new SqlCommand(invoiceADDquery, sqlCon);
                invoiceADDcomnd.ExecuteNonQuery();

                MessageBox.Show("successfully added");

                sqlCon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                       

            dgvInvoice.Rows.Add(dateTPickrInvoice.Value.Date, txtInvoiceNo.Text, txtItemId.Text, cmbDecript.SelectedItem.ToString(), txtQty.Text, txtPrice.Text, txtTotal.Text); //alternative 2

            txtTot.Text = "0";
            for (int i = 0; i < dgvInvoice.Rows.Count; i++)
            {
                txtTot.Text = Convert.ToString(float.Parse(txtTot.Text) + float.Parse(dgvInvoice.Rows[i].Cells[6].Value.ToString()));
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            sqlCon.Open();

            string invoiceDELETEquery = "DELETE FROM Invoice WHERE ItemId = '" + txtItemId.Text + "' ";
            SqlCommand invoiceDELETEcmd = new SqlCommand(invoiceDELETEquery, sqlCon);

            SqlDataReader invoiceDELETEreader;

            try
            {
                invoiceDELETEreader = invoiceDELETEcmd.ExecuteReader();
                MessageBox.Show("Delete Invoice Record Successfully");

                while (invoiceDELETEreader.Read())
                {

                    
                }
                sqlCon.Close();
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
            
            indexx = dgvInvoice.CurrentCell.RowIndex;
            dgvInvoice.Rows.RemoveAt(indexx);

            UpdateQuantity();
        }

        private void btnClearr_Click(object sender, EventArgs e)
        {
            //txtInvoiceNo.Text = string.Empty;
            txtItemId.Text = string.Empty;
            cmbDecript.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtTotal.Text = string.Empty;
          
           // ReceiveData();

        }

        private void dgvGRN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           indexx = e.RowIndex;
            DataGridViewRow roww = dgvInvoice.Rows[indexx];

            dateTPickrInvoice.Text = roww.Cells[0].Value.ToString();
            txtInvoiceNo.Text = roww.Cells[1].Value.ToString();
            txtItemId.Text = roww.Cells[2].Value.ToString();
            cmbDecript.Text = roww.Cells[3].Value.ToString();
            txtQty.Text = roww.Cells[4].Value.ToString();
            txtPrice.Text = roww.Cells[5].Value.ToString();
            txtTotal.Text = roww.Cells[6].Value.ToString();

          //  DataGridViewTextBoxCell { ColumnIndex = 4, RowIndex = 0 }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //sqlCon.Open();
            //string invoiceUPDTquery = "UPDATE Invoice SET  ItemId='" + txtItemId.Text + "', Description='" + cmbDecript.Text + "', Quantity='" + txtQty.Text + "', UnitPrice='" + txtPrice.Text + "', Total='" + txtTotal.Text + "' WHERE ItemId = '" + txtItemId.Text + "' ;";
            //SqlCommand invoiceUPDTcmd = new SqlCommand(invoiceUPDTquery, sqlCon);

            //try
            //{
            //    SqlDataReader invoiceUPDTreader = invoiceUPDTcmd.ExecuteReader();
            //    MessageBox.Show("Update Invoice Table Successfully");

            //    while (invoiceUPDTreader.Read())
            //    {
            //        int ItemID = int.Parse(invoiceUPDTreader["ItemId"].ToString());
            //        float Quantity = float.Parse(invoiceUPDTreader["Quantity"].ToString());

            //        float txtQuanty = float.Parse(txtQty.Text);


            //        if (txtQuanty>)
            //        {

            //        }
            //        float updateQuanty = Quantity - txtQuanty;

            //        // MessageBox.Show("hii here");
            //        invoiceUPDTreader.Close();

            //        String updateQuery = "UPDATE GRN SET  Quantity = " + updateQuanty.ToString() + "  WHERE ItemId = " + txtItemId.Text;
            //        SqlCommand updateGRNcmd = new SqlCommand(updateQuery, sqlCon);
            //        updateGRNcmd.ExecuteNonQuery();
            //        MessageBox.Show("Updated Database \n" + "Results \n Item ID : " + ItemID.ToString() + " \n DBstoredQuantity : " + Quantity.ToString() + " \n Entered Quantity : " + txtQuanty.ToString() + "\n Updated Quantity :" + updateQuanty.ToString());

            //    }
            //    sqlCon.Close();
            //}
            //catch (Exception exx)
            //{
            //    MessageBox.Show(exx.Message);
            //}


            //DataGridViewRow newDataa = dgvInvoice.Rows[indexx];

            //newDataa.Cells[1].Value = txtInvoiceNo.Text;
            //newDataa.Cells[2].Value = txtItemId.Text;
            //newDataa.Cells[3].Value = cmbDecript.SelectedItem.ToString();
            //newDataa.Cells[4].Value = txtQty.Text;
            //newDataa.Cells[5].Value = txtPrice.Text;
            //newDataa.Cells[6].Value = txtTotal.Text;
        
      
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            cmbDecript.Items.Clear();
            sqlCon.Open();
            SqlCommand AddcmboLstCMD = sqlCon.CreateCommand();
            AddcmboLstCMD.CommandType = CommandType.Text;
            AddcmboLstCMD.CommandText = "SELECT Description FROM GRN ";
            AddcmboLstCMD.ExecuteNonQuery();

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdptr = new SqlDataAdapter(AddcmboLstCMD);
            dataAdptr.Fill(dataTable);

            foreach(DataRow dr in dataTable.Rows)
            {
                cmbDecript.Items.Add(dr["Description"]).ToString();
            }
            sqlCon.Close();
            ReceiveData();
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {
                txtTotal.Text = (float.Parse(txtQty.Text) * float.Parse(txtPrice.Text)).ToString();

               UpdateStock();
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotal.Text = (float.Parse(txtQty.Text) * float.Parse(txtPrice.Text)).ToString();
            }
        }

        private void txtTot_Enter(object sender, EventArgs e)
        {
            txtTot.Text = "0";
            for (int i = 0; i < dgvInvoice.Rows.Count; i++)
            {
                txtTot.Text = Convert.ToString(float.Parse(txtTot.Text) + float.Parse(dgvInvoice.Rows[i].Cells[6].Value.ToString()));
            }
        }

        private void txtPay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBalance.Text = (float.Parse(txtPay.Text) - float.Parse(txtTot.Text)).ToString();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string title = "Sale & Inventory System Receipt";
           // Font t = new Font(12);
            //t.FontFamily(Calibri,6);
            richTxtBill.Text += "\n";
            richTxtBill.Text += "\n";
            richTxtBill.Text += "\t\t"+title+"\n";
            richTxtBill.Text += "\n";
            richTxtBill.Text += "\n";
            richTxtBill.Text += "\t Invoice NO: " + txtInvoiceNo.Text+ "\n";
            richTxtBill.Text += "\t Date      : " + dateTPickrInvoice.Text +"\n";
            richTxtBill.Text += "\n";
            richTxtBill.Text += "\n";

            richTxtBill.Text += "\t Item ID \t Description \t Quantity \t UnitPrice \t Total \t \n";


            for (int i=0; i<dgvInvoice.Rows.Count; i++)
            {
                richTxtBill.Text += "-";
                for (int j=2; j<dgvInvoice.Columns.Count; j++)
                {
                    richTxtBill.Text = richTxtBill.Text + "\t" + dgvInvoice.Rows[i].Cells[j].Value.ToString()+"\t";
                }
                richTxtBill.Text += "\n";
            }

            richTxtBill.Text += "\n";
            richTxtBill.Text += "\n";
            richTxtBill.Text += " ---------------------------------------------------------------------------------------------------------------------------------------------------\n";
            richTxtBill.Text += "\tTotal   : "+txtTot.Text+"\n";
            richTxtBill.Text += "\tPay     : "+txtPay.Text + "\n";
            richTxtBill.Text += "\tBalance : "+txtBalance.Text + "\n";
            richTxtBill.Text += " --------------------------------------------------------------------------------------------------------------------------------------------------\n";
            richTxtBill.Text += "\n";
            richTxtBill.Text += "\n";
            richTxtBill.Text += "\n";
            richTxtBill.Text += " --------------------------------------------------COME AGAIN-------------------------------------------------------------------------";

           // printDialog1.Document = printDocument1;
            //printDialog1.ShowDialog();

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTxtBill.Text, new Font("Lucida Sans", 18, FontStyle.Regular), Brushes.Black, new Point(5,5));
        }

        private void cmbDecript_SelectedIndexChanged(object sender, EventArgs e)
        {

            sqlCon.Open(); 
            
            string getDBtoTXTQuery = "SELECT * FROM GRN WHERE Description='"+cmbDecript.Text+"'";
            SqlCommand getDBtoTXTcmd = new SqlCommand(getDBtoTXTQuery, sqlCon);

            getDBtoTXTcmd.ExecuteNonQuery();
            SqlDataReader getDBtoTXTdataReadr;
            getDBtoTXTdataReadr = getDBtoTXTcmd.ExecuteReader();

            while (getDBtoTXTdataReadr.Read())
            {
                string ItemId = (string)getDBtoTXTdataReadr["ItemId"].ToString();
                txtItemId.Text = ItemId;

                string UnitPrice = (string)getDBtoTXTdataReadr["UnitPrice"].ToString();
                txtPrice.Text = UnitPrice;

                string ExpDate = (string)getDBtoTXTdataReadr["ExpDate"].ToString();
                DateTime expDate = DateTime.Parse(ExpDate);

                DateTime currentDate = dateTPickrInvoice.Value;
                if(currentDate >= expDate)
                {
                    MessageBox.Show("Expired Item ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            sqlCon.Close();
        }

        private void  UpdateStock()
        {
            String searchQuery = "SELECT * FROM GRN  WHERE ItemId='" + txtItemId.Text + "'";
            SqlCommand command = new SqlCommand(searchQuery, sqlCon);

            sqlCon.Open();
            SqlDataReader read = command.ExecuteReader();
            if (read.HasRows)
            {
                try
                {
                    while (read.Read())
                    {
                        int ItemID = int.Parse(read["ItemId"].ToString());
                        float Quantity = float.Parse(read["Quantity"].ToString());

                       float txtQuanty = float.Parse(txtQty.Text);

                       float updateQuanty = Quantity - txtQuanty;

                       // MessageBox.Show("hii here");
                       read.Close();

                        String updateQuery = "UPDATE GRN SET  Quantity = " + updateQuanty.ToString() + "  WHERE ItemId = " + txtItemId.Text;
                        SqlCommand updateGRNcmd = new SqlCommand(updateQuery, sqlCon);
                        updateGRNcmd.ExecuteNonQuery();
                        MessageBox.Show("Updated Database \n" + "Results \n Item ID : " + ItemID.ToString() + " \n DBstoredQuantity : " + Quantity.ToString() + " \n Entered Quantity : " + txtQuanty.ToString() + "\n Updated Quantity :" + updateQuanty.ToString());                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Stock Updated Successfully ");
                    
                }
            }
            else
            {
                MessageBox.Show("No data Found");
                // No data in table
            }
            sqlCon.Close();
        }

        private void UpdateQuantity()
        {
            String searchQuery = "SELECT * FROM GRN  WHERE ItemId='" + txtItemId.Text + "'";
            SqlCommand command = new SqlCommand(searchQuery, sqlCon);

            sqlCon.Open();
            SqlDataReader read = command.ExecuteReader();
            if (read.HasRows)
            {
                try
                {
                    while (read.Read())
                    {
                        int ItemID = int.Parse(read["ItemId"].ToString());
                        float Quantity = float.Parse(read["Quantity"].ToString());

                        float txtQuanty = float.Parse(txtQty.Text);

                        float updateQuanty = Quantity + txtQuanty;

                        // MessageBox.Show("hii here");
                        read.Close();

                        String updateQuery = "UPDATE GRN SET  Quantity = " + updateQuanty.ToString() + "  WHERE ItemId = " + txtItemId.Text;
                        SqlCommand updateGRNcmd = new SqlCommand(updateQuery, sqlCon);
                        updateGRNcmd.ExecuteNonQuery();
                        MessageBox.Show("Updated Database \n" + "Results \n Item ID : " + ItemID.ToString() + " \n DBstoredQuantity : " + Quantity.ToString() + " \n Entered Quantity : " + txtQuanty.ToString() + "\n Updated Quantity :" + updateQuanty.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Stock Updated Successfully ");

                }
            }
            else
            {
                MessageBox.Show("No data Found");
                // No data in table
            }
            sqlCon.Close();

        }

    }
}
