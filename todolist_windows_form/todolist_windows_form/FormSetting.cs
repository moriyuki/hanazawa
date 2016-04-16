using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace todolist_windows_form
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.User = this.txtUser.Text;
            settings.ServerURL = this.txtServerURL.Text;
            settings.Password = this.txtPassword.Text;

            String filename = "setting.config";
            BinaryFormatter bf = new BinaryFormatter();
            System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Create);
            bf.Serialize(fs, settings);
            fs.Close();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            String filename = "setting.config";
            if(System.IO.File.Exists(filename))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open);
                    settings = (Settings)bf.Deserialize(fs);
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }

            }
            this.txtServerURL.Text = settings.ServerURL;
            this.txtUser.Text = settings.User;
            this.txtPassword.Text = settings.Password;
        }
    }
}
