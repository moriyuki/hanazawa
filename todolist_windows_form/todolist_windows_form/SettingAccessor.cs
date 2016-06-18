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
            Settings settings = new Settings();
            String filename = Common.settingfilename;
            DataModel dm = DataModel.GetInstance();
            if (System.IO.File.Exists(filename))
            {
                
                System.IO.FileStream fs = new System.IO.FileStream();
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    fs= new System.IO.FileStream(filename, System.IO.FileMode.Open);
                    settings = (Settings)bf.Deserialize(fs);

                    dm.settings.ServerURL = settings.ServerURL;
                    dm.settings.User = settings.User;
                    // 複合化
                    dm.settings.Password = Encrypt.DecryptString(settings.Password, ENCRYPTPASSWORD);
                    dm.settings.RedmineURL = Encrypt.DecryptString(settings.RedmineURL, ENCRYPTPASSWORD);
                    dm.settings.RedmineKey = Encrypt.DecryptString(settings.RedmineKey, ENCRYPTPASSWORD);

                    fs.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Error");

                }
                finally
                {
                    fs.Close();
                }
            }
        }

        // 内部データを保存
        public void SaveSettingData()
        {
            Settings settings = new Settings();

            DataModel dm = DataModel.GetInstance();

            settings.ServerURL = dm.settings.ServerURL;
            settings.User = dm.settings.User;
            // 暗号化処理
            settings.Password = Encrypt.EncryptString(dm.settings.Password, ENCRYPTPASSWORD);
            settings.RedmineURL = Encrypt.EncryptString(dm.settings.RedmineURL, ENCRYPTPASSWORD);
            settings.RedmineKey = Encrypt.EncryptString(dm.settings.RedmineKey, ENCRYPTPASSWORD);

            // 内部データから設定ファイル
            String filename = Common.settingfilename;
            BinaryFormatter bf = new BinaryFormatter();
            System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Create);
            bf.Serialize(fs, settings);
            fs.Close();
        }
    }
}
