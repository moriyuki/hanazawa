using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace todolist_windows_form
{
    public partial class FormTicketDetail : Form
    {
        private DataModel.ticket tck;

        public FormTicketDetail()
        {
            InitializeComponent();
        }

        public FormTicketDetail(DataModel.ticket t)
        {
            InitializeComponent();
            this.tck = t;
            this.ShowTicketDate();
        }

        // チケットの内容を表示する
        private void ShowTicketDate()
        {
            this.tbSubject.Text = tck.subject;
        }

        private void lblCreated_Click(object sender, EventArgs e)
        {

        }

        private void hsbDoneRatio_Scroll(object sender, ScrollEventArgs e)
        {
            double temp = hsbDoneRatio.Value / 10.0;
            temp = Math.Ceiling(temp);
            tbDoneRatio.Text = (temp * 10.0).ToString();
        }

        private void tbDoneRatio_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
