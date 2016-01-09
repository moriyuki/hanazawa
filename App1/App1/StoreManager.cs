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
        // ローカルデータファイルが無いときに新規作成する
        void createDataFile()
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

            using (StreamWriter writer = File.CreateText("sample.xml"))
            {
                datafile.Save(writer);
            }

        }

        // データを呼び出すメソッド（XMLファイルから）
        // データを書き込むメソッド（XMLファイルに）
    }
}
