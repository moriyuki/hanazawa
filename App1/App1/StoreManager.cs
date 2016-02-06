using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace App1
{
    // ローカルデータ管理クラス
    class StoreManager
    {
        private const String taskDataPath = "./../config/taskdata.xml";

        // ローカルデータファイルが無いときに新規作成する
        public void createDataFile()
        {
            XmlDocument datafile = new XmlDocument();

            XmlDeclaration declaration = datafile.CreateXmlDeclaration("1.0", "Shift-JIS", null);
            XmlElement root = datafile.CreateElement("root");

            datafile.AppendChild(declaration);
            datafile.AppendChild(root);

            XmlElement element = datafile.CreateElement("element");

            element.InnerText = "text";
            element.SetAttribute("attribute", "256");

            root.AppendChild(element);
            
            datafile.Save();
            //using (StreamWriter writer = File.CreateText("sample.xml"))
            //{
            //    datafile.Save(writer);
            //}
            //using (StreamWriter sw = new StreamWriter(@"config.xml")) { 
            //    using (XmlWriter xw = XmlWriter.Create(st))
            //    {
            //        xw.WriteStartDocument();
            //        xw.WriteStartElement("element");
            //        xw.WriteEndElement();
            //        xw.WriteEndDocument();
            //    }
            //}
        }

        // データを呼び出すメソッド（XMLファイルから）
        public void loadTasksFromXmlFile()
        {
            XmlDocument dataFile = new XmlDocument();
            //dataFile.Load(this.taskDataPath);

            while (true)
            {
                // xml data 読み込み
                // 内部データに格納
                DataModel dm = DataModel.GetInstance();
                // dm.tickets
            }
        }

        // データを書き込むメソッド（XMLファイルに）
        public void saveTaskstoXmlFile()
        {
            // 内部データを取得
            DataModel dm = DataModel.GetInstance();

            // xml dataとして保存

        }
    }
}
