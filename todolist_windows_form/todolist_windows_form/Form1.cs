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
            for(int i = 0; i < dm.tickets.Count; i++)
            {
                uc_ticketItem uc_item;
                uc_item = new todolist_windows_form.uc_ticketItem();
                uc_item.Name = "uc_ticketItem" + (i+1).ToString();
                uc_item.Size = new System.Drawing.Size(604, 101);
                uc_item.Location = new System.Drawing.Point(LAYOUT_MERGINE, LAYOUT_MERGINE + i * uc_item.Size.Height + LAYOUT_MERGINE * i);
                uc_item.TabIndex = 0;

                uc_item.myTicket = dm.tickets[i];

                this.panel1.Controls.Add(uc_item);
            }
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
    }
}
