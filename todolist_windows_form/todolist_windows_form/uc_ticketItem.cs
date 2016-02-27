using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace todolist_windows_form
{
    public partial class uc_ticketItem : UserControl
    {
        private DataModel.ticket tck;

        // event CheckChanged(Byval )
        public uc_ticketItem()
        {
            InitializeComponent();
        }

        private int privatenumber = -1;

        public DataModel.ticket myTicket
        {
            get
            {
                return tck;
            }
            set
            {
                tck = value;
            }
        }

        public void SrtMynumber(int number)
        {
            MessageBox.Show(number.ToString());
        }

        private void pnlCheck_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlCheck_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void txbTicketSubject_Enter(object sender, EventArgs e)
        {

        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            this.txbTicketSubject.Text = "Detail Clicked";
        }

        private void uc_ticketItem_Load(object sender, EventArgs e)
        {
            this.txbTicketSubject.Text = this.tck.subject;
        }

        private void pnlCheck_Click(object sender, EventArgs e)
        {
            this.tck.done = !(this.tck.done);

            if (this.tck.done)
            {
                this.pnlCheck.BackColor = Color.RosyBrown;
            }
            else
            {
                this.pnlCheck.BackColor = Color.Transparent;
            }
            // this.txbTicketSubject.Text = "panel Clicked";
        }
    }
}
