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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmInvetory INvntryForm = new FrmInvetory();
            INvntryForm.Show();
            this.Close();
        }

        private void btnGRNcheck_Click(object sender, EventArgs e)
        {
            frmGRN grn = new frmGRN();
            grn.Show();
            this.Close();
        }

        private void btnAdminPrint_Click(object sender, EventArgs e)
        {
            frmInvoice invoice = new frmInvoice();
            invoice.Show();
            this.Close();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            frmAdminMembr adminMembr = new frmAdminMembr();
            adminMembr.Show();
            this.Close();
        }
    }
}
