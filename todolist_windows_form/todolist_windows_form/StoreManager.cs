﻿using System;
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
            DataModel dm = DataModel.GetInstance();
            try
            {
                // dataFile.Load("test.xml");
                XmlTextReader reader = new XmlTextReader(new StringReader(File.ReadAllText("test.xml")));
                // System.Windows.Forms.MessageBox.Show("load success!");
                while (reader.Read())
                {
                    // Console.WriteLine(" find node!: {0} ", reader.NodeType.ToString());

                    if ( reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("issue") )
                    {
                        DataModel.ticket ticket = new DataModel.ticket();
                        ticket.initTicket();
                        // XMLデータの値を割り付け
                        if ( reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("id"))
                        {
                            // id 読み込み
                            ticket.id = int.Parse(reader.Value);
                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("project"))
                        {
                            // project 読み込み
                            do
                            {
                                if (reader.Name.Equals("id"))
                                {
                                    ticket.project.id = int.Parse(reader.Value);
                                }
                                else if (reader.Name.Equals("name"))
                                {
                                    ticket.project.name = reader.Value;
                                }
                            } while (reader.MoveToNextAttribute());

                        }
                        dm.tickets.Add(ticket);
                    }

                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name.Equals("issue"))
                            {

                            }
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
