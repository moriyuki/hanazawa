using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace todolist_windows_form
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
            
            datafile.Save("test.xml");
        }

        // データを呼び出すメソッド（XMLファイルから）
        public void loadTasksFromXmlFile()
        {
            XmlDocument dataFile = new XmlDocument();
            try
            {
                // dataFile.Load("test.xml");
                XmlTextReader reader = new XmlTextReader(new StringReader(File.ReadAllText("test.xml")));
                // System.Windows.Forms.MessageBox.Show("load success!");
                while (reader.Read())
                {
                    // Console.WriteLine(" find node!: {0} ", reader.NodeType.ToString());

                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            Console.WriteLine("Element:{0}", reader.Name);
                            if (reader.MoveToFirstAttribute())
                            {
                                // 属性値を取得するためのWhile
                                do
                                {
                                    Console.WriteLine("Attribute:{0}={1}", reader.Name, reader.Value);
                                } while (reader.MoveToNextAttribute());
                            }
                            break;

                        case XmlNodeType.Text:
                            Console.WriteLine("Text:{0}", reader.Value);
                            break;

                        case XmlNodeType.EndElement:
                            Console.WriteLine("EndElement:{0}", reader.Name);
                            break;
                        case XmlNodeType.Whitespace:
                            break;  
                    }
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
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
