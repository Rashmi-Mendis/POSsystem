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
    public partial class frmStaff : Form
    {
        public frmStaff()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        //private void btnGRNcheck_Click(object sender, EventArgs e)
        //{
        ////    frmGRN grnForm = new frmGRN();
        ////    grnForm.Show();
        ////    this.Close();
        //}

        private void btnStaffPrint_Click(object sender, EventArgs e)
        {
            frmInvoice invoiceForm = new frmInvoice();
            invoiceForm.Show();
            this.Close();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            frmStaffMember staffMemberForm = new frmStaffMember();
            staffMemberForm.Show();
            this.Close();
        }
    }
}
