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
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("tracker"))
                        {
                            // tracker 読み込み
                            do
                            {
                                if (reader.Name.Equals("id"))
                                {
                                    ticket.tracker.id = int.Parse(reader.Value);
                                }
                                else if (reader.Name.Equals("name"))
                                {
                                    ticket.tracker.name = reader.Value;
                                }
                            } while (reader.MoveToNextAttribute());

                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("status"))
                        {
                            // status 読み込み
                            do
                            {
                                if (reader.Name.Equals("id"))
                                {
                                    ticket.status.id = int.Parse(reader.Value);
                                }
                                else if (reader.Name.Equals("name"))
                                {
                                    ticket.status.name = reader.Value;
                                }
                            } while (reader.MoveToNextAttribute());

                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("priority"))
                        {
                            // priority 読み込み
                            do
                            {
                                if (reader.Name.Equals("id"))
                                {
                                    ticket.priority.id = int.Parse(reader.Value);
                                }
                                else if (reader.Name.Equals("name"))
                                {
                                    ticket.priority.name = reader.Value;
                                }
                            } while (reader.MoveToNextAttribute());

                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("auther"))
                        {
                            // auther 読み込み
                            do
                            {
                                if (reader.Name.Equals("id"))
                                {
                                    ticket.auther.id = int.Parse(reader.Value);
                                }
                                else if (reader.Name.Equals("name"))
                                {
                                    ticket.auther.name = reader.Value;
                                }
                            } while (reader.MoveToNextAttribute());

                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("subject"))
                        {
                            // subject 読み込み
                            ticket.subject = reader.Value;

                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("description"))
                        {
                            // description 読み込み
                            ticket.description = reader.Value;

                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("start_date"))
                        {
                            // start_date 読み込み
                            ticket.start_date = DateTime.Parse(reader.Value);

                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("due_date"))
                        {
                            // due_date 読み込み
                            ticket.due_date = DateTime.Parse(reader.Value);

                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("done_ratio"))
                        {
                            // done_ratio 読み込み
                            ticket.done_ratio = int.Parse(reader.Value);

                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("is_private"))
                        {
                            // is_private 読み込み
                            ticket.is_private = bool.Parse(reader.Value);

                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("estimated_hours"))
                        {
                            // estimated_hours 読み込み
                            ticket.estimated_hours = float.Parse(reader.Value);

                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("created_on"))
                        {
                            // created_on 読み込み
                            ticket.created_on = DateTime.Parse(reader.Value);

                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("updated_on"))
                        {
                            // updated_on 読み込み
                            ticket.updated_on = DateTime.Parse(reader.Value);

                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("closed_on"))
                        {
                            // closed_on 読み込み
                            ticket.closed_on = DateTime.Parse(reader.Value);

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
