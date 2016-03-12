﻿using System;
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
            else
            {
                this.tck.subject = this.txbTicketSubject.Text;
                this.SaveTicket();
            }
        }

        // 詳細ボタンクリックイベント
        private void btnDetail_Click(object sender, EventArgs e)
        {
            FormTicketDetail ftd = new FormTicketDetail(tck);
            ftd.ShowDialog();
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
                DataChenged(this, new EventArgs());
            }
        }

        private void chkDone_CheckedChanged(object sender, EventArgs e)
        {
            this.tck.done = !(this.tck.done);
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
    }
}
