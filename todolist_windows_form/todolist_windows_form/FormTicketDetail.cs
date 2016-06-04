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
        private DataModel dm = DataModel.GetInstance();
        
        // チケット 詳細のプロパティ
        public DataModel.ticket ticketDetail
        {
            get
            {
                return this.tck;
            }

            set
            {
                this.tck = value;
                this.ShowTicketDate();
            }
        }

        public FormTicketDetail()
        {
            InitializeComponent();
         
        }

        public FormTicketDetail(ref DataModel.ticket t)
        {
            InitializeComponent();
            this.tck = t;
            this.ShowTicketDate();
        }

        // チケットの内容を表示する
        private void ShowTicketDate()
        {
            this.tbSubject.Text =tck.subject ;
            this.lbId.Text = "チケットID：" + tck.id.ToString();
            this.lblClosed.Text = "完了日：" + tck.closed_on.ToString();
            this.lblCreated.Text = "作成日：" + tck.created_on.ToString();
            this.lblUpdated.Text = "更新日：" + tck.updated_on.ToString();
            this.cmbProject.Text = tck.project.name.ToString();
            this.cmbAuthor.Text = tck.auther.name.ToString();

            // ステータスアイテム追加、選択
            DataModel.StatusItem selectedsi = new DataModel.StatusItem();
            foreach (DataModel.StatusItem si in dm.statusItems)
            {
                this.cmbbStatus.Items.Add(si);
                if (si.id.Equals(tck.status.id))
                {
                    selectedsi = si;
                }
            }
            this.cmbbStatus.SelectedItem = selectedsi;

            // 優先度
            this.cmbPriority.Text = tck.priority.name.ToString();

            // トラッカーアイテム追加、選択
            DataModel.TrackerItem selectedti = new DataModel.TrackerItem();
            foreach (DataModel.TrackerItem ti in dm.trackerItems)
            {
                this.cmbTracker.Items.Add(ti);
                if (ti.id.Equals(tck.tracker.id))
                {
                    selectedti = ti;
                }
            }
            this.cmbTracker.SelectedItem = selectedti;

            this.tbDescription.Text = tck.description;
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


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {

            tck.subject = this.tbSubject.Text;
           
            MessageBox.Show(tck.subject);
            this.DialogResult=System.Windows.Forms.DialogResult.OK ;
            this.Close();

        }
    }
}
