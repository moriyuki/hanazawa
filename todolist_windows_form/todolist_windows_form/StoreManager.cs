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
                XmlTextReader reader = new XmlTextReader(new StringReader(File.ReadAllText("./../../../../Document/redmine_sample.xml")));
                // System.Windows.Forms.MessageBox.Show("load success!");
                while (reader.Read())
                {
                    // Console.WriteLine(" find node!: {0} ", reader.NodeType.ToString());

                    if ( reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("issue") )
                    {
                        DataModel.ticket ticket = new DataModel.ticket();
                        ticket.initTicket();
                        

                        while (reader.Read())
                        {
                            // XMLデータの値を割り付け
                            if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("id"))
                            {
                                // id 読み込み
                                ticket.id = int.Parse(reader.ReadString());
                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("project"))
                            {
                                // project 読み込み
                                if (reader.MoveToAttribute("id"))
                                {
                                    ticket.project.id = int.Parse(reader.Value);
                                }

                                if (reader.MoveToAttribute("name"))
                                {
                                    ticket.project.name = reader.Value;
                                }
                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("tracker"))
                            {
                                // tracker 読み込み

                                if (reader.MoveToAttribute("id"))
                                {
                                    ticket.tracker.id = int.Parse(reader.Value);
                                }
                                if (reader.MoveToAttribute("name"))
                                {
                                    ticket.tracker.name = reader.Value;
                                }


                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("status"))
                            {
                                // status 読み込み

                                if (reader.MoveToAttribute("id"))
                                {
                                    ticket.status.id = int.Parse(reader.Value);
                                }
                                if (reader.MoveToAttribute("name"))
                                {
                                    ticket.status.name = reader.Value;
                                }


                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("priority"))
                            {
                                // priority 読み込み

                                if (reader.MoveToAttribute("id"))
                                {
                                    ticket.priority.id = int.Parse(reader.Value);
                                }
                                else if (reader.MoveToAttribute("name"))
                                {
                                    ticket.priority.name = reader.Value;
                                }


                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("auther"))
                            {
                                // auther 読み込み

                                if (reader.MoveToAttribute("id"))
                                {
                                    ticket.auther.id = int.Parse(reader.Value);
                                }

                                if (reader.MoveToAttribute("name"))
                                {
                                    ticket.auther.name = reader.Value;
                                }


                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("subject"))
                            {
                                // subject 読み込み
                                ticket.subject = reader.ReadString();

                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("description"))
                            {
                                // description 読み込み
                                ticket.description = reader.ReadString();

                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("start_date"))
                            {
                                // start_date 読み込み
                                ticket.start_date = ReadDateTimeFromReeader(reader);

                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("due_date"))
                            {
                                // due_date 読み込み
                                    ticket.due_date = ReadDateTimeFromReeader(reader);
                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("done_ratio"))
                            {
                                // done_ratio 読み込み
                                ticket.done_ratio = int.Parse(reader.ReadString());

                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("is_private"))
                            {
                                // is_private 読み込み
                                ticket.is_private = bool.Parse(reader.ReadString());

                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("estimated_hours"))
                            {
                                // estimated_hours 読み込み
                                float tmp = 0;
                                if (float.TryParse(reader.ReadString(), out tmp))
                                {
                                    ticket.estimated_hours = tmp;
                                }

                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("created_on"))
                            {
                                // created_on 読み込み
                                ticket.created_on = ReadDateTimeFromReeader(reader);

                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("updated_on"))
                            {
                                // updated_on 読み込み
                                ticket.updated_on = ReadDateTimeFromReeader(reader);

                            }
                            else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("closed_on"))
                            {
                                // closed_on 読み込み
                                ticket.closed_on = ReadDateTimeFromReeader(reader);
                            }
                            else if (reader.NodeType.Equals(XmlNodeType.EndElement) && reader.Name.Equals("issue"))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("{0}, {1}", reader.Name, reader.Value);

                            }

                        }
                        dm.tickets.Add(ticket);
                    }
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        // DateTimeを返すXmlReader
        private DateTime ReadDateTimeFromReeader(XmlTextReader reader)
        {
            DateTime dt = DateTime.MinValue;
            DateTime.TryParse(reader.ReadString(), out dt);
            return dt;
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
