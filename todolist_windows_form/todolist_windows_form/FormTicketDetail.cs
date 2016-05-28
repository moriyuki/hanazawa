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
        public class comboboxitem
        {
            public int id;
            public String name;

            public override string ToString()
            {
                return name;
            }
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

            comboboxitem cbi = new comboboxitem();
            cbi.id = 0;
            cbi.name = "abc";

            //this.cmbbStatus.Items.Add("未着手");
            //this.cmbbStatus.Items.Add("作業中");
            //this.cmbbStatus.Items.Add("完了");
            this.cmbbStatus.Items.Add(cbi);
            this.cmbbStatus.SelectedItem = this.cmbbStatus.Items[0];

            //this.cmbbStatus.Text = tck.status.name.ToString();
            this.cmbPriority.Text = tck.priority.name.ToString();
            this.cmbTracker.Text = tck.tracker.name.ToString();
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
