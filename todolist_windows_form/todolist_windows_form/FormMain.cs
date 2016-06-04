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
    public partial class FormMain : Form
    {
        const int LAYOUT_MERGINE = 6;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RedmineAccessor.DownloadTicket("http://birdsoasis.info/issues.xml?project_id=8&key=", "990ef7243dd09f531047ed4fb99e5cc759c330cf");

            StoreManager sm = new StoreManager();
            // sm.createDataFile();
            // 設定値読み込み
            sm.loadTasksFromXmlFile();

            // トラッカー情報読み込み
            DataModel dm = DataModel.GetInstance();
            XMLAccessorTracker tracker = new XMLAccessorTracker();
            tracker.Download("http://birdsoasis.info/trackers.xml?project_id=8&key=", "990ef7243dd09f531047ed4fb99e5cc759c330cf");
            // MessageBox.Show(dm.trackerItems.Count.ToString());

            // ステータス情報読み込み
            XMLAccessorStatus status = new XMLAccessorStatus();
            status.Download("http://birdsoasis.info/issue_statuses.xml?project_id=8&key=", "990ef7243dd09f531047ed4fb99e5cc759c330cf");
            MessageBox.Show(dm.statusItems.Count.ToString());

            // 設定値画面反映
            SetListItemControl();


            //Timer
            this.timer1.Start();
        }

        // ToDolistItemControlを設置する
        private void SetListItemControl()
        {
            DataModel dm = DataModel.GetInstance();
            // continue while item list number
            this.SuspendLayout();
            DateTime dt = DateTime.Now;
            int validTicketIndex = 0; // 表示対象チケット数
            for (int i = 0; i < dm.tickets.Count; i++)
            {
                // 更新されたチケットが指定時間よりも経過していたらコントロールを追加しない
                if (dm.tickets[i].done && dm.tickets[i].closed_on < dt.AddHours(-0.01))
                {
                    continue;
                }

                uc_ticketItem uc_item;
                uc_item = new todolist_windows_form.uc_ticketItem();
                uc_item.Name = "uc_ticketItem" + (i+1).ToString();
                uc_item.Size = new System.Drawing.Size(604, 101);
                uc_item.Location = new System.Drawing.Point(LAYOUT_MERGINE, LAYOUT_MERGINE + validTicketIndex++ * uc_item.Size.Height + LAYOUT_MERGINE * i);
                uc_item.TabIndex = 0;
                uc_item.DataChenged += new System.EventHandler(this.SaveData);

                uc_item.myTicket = dm.tickets[i];

                this.panel1.Controls.Add(uc_item);
            }

            //
            AddBlankTicket(validTicketIndex++);


            this.ResumeLayout();
        }

        private void AddBlankTicket(int i)
        {
            uc_ticketItem uc_item;
            uc_item = new todolist_windows_form.uc_ticketItem();
            uc_item.Name = "uc_ticketItem" + (i + 1).ToString();
            uc_item.Size = new System.Drawing.Size(604, 101);
            uc_item.Location = new System.Drawing.Point(LAYOUT_MERGINE, LAYOUT_MERGINE + i * uc_item.Size.Height + LAYOUT_MERGINE * i);
            uc_item.TabIndex = 0;
            uc_item.DataChenged += new System.EventHandler(this.SaveData);

            this.panel1.Controls.Add(uc_item);
        }

        private void btnAddTicket_Click(object sender, EventArgs e)
        {
            DataModel dm = DataModel.GetInstance();
            DataModel.ticket ticket = new DataModel.ticket();
            dm.tickets.Add(ticket);

            ClearListItemControl();
            SetListItemControl();
        }

        private void ClearListItemControl()
        {
            foreach( Control ctrl in this.panel1.Controls)
            {
                ctrl.Dispose();
            }
            this.panel1.Controls.Clear();
        }

        private void SaveData(object sender, EventArgs e)
        {
            uc_ticketItem item = (uc_ticketItem)sender;
            DataModel dm = DataModel.GetInstance();
            if (item.myTicket.id == 0)
            {
                DataModel.ticket ticket = new DataModel.ticket();
                ticket = item.myTicket;
                ticket.id = dm.GetNextID();
                ticket.created_on = DateTime.Now;
                ticket.updated_on = DateTime.Now;
                dm.tickets.Add(ticket);

                ClearListItemControl();
                SetListItemControl();
            }
            else {

                for (int i = 0; i < dm.tickets.Count; i++)
                {
                    if (dm.tickets[i].id.Equals(item.myTicket.id))
                    {
                        //                       MessageBox.Show("Regal Ticket");
                        dm.tickets[i] = item.myTicket;
                    }
                }

            }

            // データ保存
            // MessageBox.Show("SaveData:" + item.myTicket.subject);
            StoreManager sm = new StoreManager();
            sm.saveTaskstoXmlFile();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // formが閉じられない不具合修正
            if (e.Cancel)
            {
                e.Cancel = !e.Cancel;
            }
            this.timer1.Stop();
        }    

        private void msSetting_Click(object sender, EventArgs e)
        {
            FormSetting fs = new FormSetting();
            fs.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            //          this.Text = DateTime.Now.ToString();

            bool timeflag = false;
            foreach (uc_ticketItem ucitem in this.panel1.Controls)
            {
                if(ucitem.myTicket.closed_on != DateTime.MinValue && ucitem.myTicket.closed_on < DateTime.Now.AddHours(-0.01) )
                {
                    timeflag = true;
                    break;
                }
            }
            if(timeflag)
            {
                this.ClearListItemControl();
                this.SetListItemControl();
            }
            this.timer1.Start();
        }
    }
}
