using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSsystem
{
    public partial class FrmInvetory : Form
    {
        public FrmInvetory()//bool isStaff
        {
            InitializeComponent();
           // isstaff = isStaff;
        }

       // public bool isstaff;

        private void btnGRN_Click(object sender, EventArgs e)
        {
            FrmGRNConfirmation ConfForm = new FrmGRNConfirmation();
            ConfForm.Show();
            this.Hide();

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            frmConfirmation confirmationForm = new frmConfirmation();
            confirmationForm.Show();
            this.Hide();

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            frmStaff staff = new frmStaff();
            staff.Show();
            this.Close();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            frmInvoice invoice = new frmInvoice();
            invoice.Show();
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmInvetory_Load(object sender, EventArgs e)
        {

          //MessageBox.Show("hi");
        }
    }
}
