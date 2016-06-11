using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace todolist_windows_form
{
    class SettingAccessor
    {
        const string ENCRYPTPASSWORD = "うどん自販機";
        // ファイルから読み込み
        public void LoadFromSettingFile()
        {
            Settings settings = Settings.Instance;
            String filename = Common.settingfilename;
            if (System.IO.File.Exists(filename))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open);
                    settings = (Settings)bf.Deserialize(fs);
                    //settings.ServerURL  = stt.ServerURL;
                    fs.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Error");
                }

                //settings.ServerURL = 
                // 複合化
                settings.Password = Encrypt.DecryptString(settings.Password, ENCRYPTPASSWORD);
                settings.RedmineURL = Encrypt.DecryptString(settings.RedmineURL, ENCRYPTPASSWORD);
                settings.RedmineKey = Encrypt.DecryptString(settings.RedmineKey, ENCRYPTPASSWORD);

            }
        }

        // 内部データを保存
        public void SaveSettingData()
        {
            Settings settings = Settings.Instance;

            // 暗号化処理
            settings.Password = Encrypt.EncryptString(settings.Password, ENCRYPTPASSWORD);
            settings.RedmineURL = Encrypt.EncryptString(settings.RedmineURL, ENCRYPTPASSWORD);
            settings.RedmineKey = Encrypt.EncryptString(settings.RedmineKey, ENCRYPTPASSWORD);

            // 内部データから設定ファイル
            String filename = Common.settingfilename;
            BinaryFormatter bf = new BinaryFormatter();
            System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Create);
            bf.Serialize(fs, settings);
            fs.Close();
        }
    }
}
