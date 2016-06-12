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
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        // 設定情報保存
        private void btnSetting_Click(object sender, EventArgs e)
        {
            // 画面から内部データ
            DataModel dm = DataModel.GetInstance();
            dm.settings.User = this.txtUser.Text;
            dm.settings.ServerURL = this.txtServerURL.Text;
            dm.settings.Password = this.txtPassword.Text;

            dm.settings.RedmineURL = this.txtRedmineURL.Text;
            dm.settings.RedmineKey = this.txtRedmineKey.Text;

            SettingAccessor sa = new SettingAccessor();
            sa.SaveSettingData();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            SettingAccessor sa = new SettingAccessor();
            DataModel dm = DataModel.GetInstance();
            String filename = Common.settingfilename;

            // 画面に反映
            this.txtServerURL.Text = dm.settings.ServerURL;
            this.txtUser.Text = dm.settings.User;
            this.txtPassword.Text = dm.settings.Password;

            this.txtRedmineURL.Text = dm.settings.RedmineURL;
            this.txtRedmineKey.Text = dm.settings.RedmineKey;            
        }
    }
}
