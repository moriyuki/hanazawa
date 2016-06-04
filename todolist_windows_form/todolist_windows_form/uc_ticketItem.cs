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
        private DataModel.ticket tckorg;
        private String strSubPreText;
        
        public event EventHandler DataChenged;

        // event CheckChanged(Byval )
        public uc_ticketItem()
        {
            InitializeComponent();
        }

        public DataModel.ticket myTicket
        {
            get
            {
                return tck;
            }
            set
            {
                tck = value;
                tckorg = value;
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

        // チケットテキストエリアに入ったとき
        private void txbTicketSubject_Enter(object sender, EventArgs e)
        {
            this.strSubPreText = this.txbTicketSubject.Text;
        }
        // チケットテキストエリアから出たとき
        private void txbTicketSubject_Leave(object sender, EventArgs e)
        {
            if (String.Equals(strSubPreText, this.txbTicketSubject.Text))
            {
                // 同じ場合　何もしない
            }
            else if(String.IsNullOrEmpty(this.txbTicketSubject.Text))
            {
                this.chkDone.Checked = true;
            }
            else
            {
                this.tck.subject = this.txbTicketSubject.Text;
                this.SaveTicket();
            }
        }

        // 詳細ボタンクリックイベント
        private void btnDetail_Click(object sender, EventArgs e)
        {
            FormTicketDetail ftd = new FormTicketDetail();
            ftd.ticketDetail = this.tck;
            if(ftd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tck = ftd.ticketDetail;
                this.txbTicketSubject.Text = tck.subject;
                this.SaveTicket();
            }
        }

        private void uc_ticketItem_Load(object sender, EventArgs e)
        {
            this.txbTicketSubject.Text = this.tck.subject;
            this.ShowTicketItem();
        }

        // チケットを保存する
        private void SaveTicket()
        {
            if (tck.IsEqual(tckorg))
            {
                // do nothing
            }
            else
            {
                // Event 通知
                tck.updated_on = DateTime.Now;
                UploadIssueEventArgs uiea = new UploadIssueEventArgs();
                uiea.UploadType = "PUT";
                DataChenged(this, uiea);
            }
        }

        // チケットの完了イベント処理
        private void chkDone_CheckedChanged(object sender, EventArgs e)
        {
            this.tck.done = !(this.tck.done);
            //-----
            if (this.tck.done)
            {
                this.tck.closed_on = DateTime.Now;
            } else
            {
                this.tck.closed_on = DateTime.MinValue;
            }
            //-----
            this.ShowTicketItem();
            this.SaveTicket();
        }

        private void ShowTicketItem()
        {
            if (this.tck.done)
            {
                this.BackColor = Color.Gray;
                this.txbTicketSubject.BackColor = Color.Gray;
                this.btnDetail.Enabled = false;
            }
            else
            {
                this.BackColor = Color.Transparent;
                this.txbTicketSubject.BackColor = Color.White;
                this.btnDetail.Enabled = true;
            }
        }

        private void txbTicketSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.Enter))
            {
                this.tck.subject = this.txbTicketSubject.Text;
                this.SaveTicket();
            }
        }
    }
}
