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
    public partial class Form1 : Form
    {
        const int LAYOUT_MERGINE = 6;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StoreManager sm = new StoreManager();
            // sm.createDataFile();
            // 設定値読み込み
            sm.loadTasksFromXmlFile();
            
            // 設定値画面反映
            SetListItemControl();
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
                if (dm.tickets[i].done && dm.tickets[i].closed_on < dt.AddHours(-1))
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
                        dm.tickets[i] = item.myTicket;
                    }
                }

            }

            // データ保存
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
        }
    }
}
