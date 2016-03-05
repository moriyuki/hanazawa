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

                    if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("issue"))
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
            catch (Exception ex)
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
            XmlDocument datafile = new XmlDocument();

            XmlDeclaration declaration = datafile.CreateXmlDeclaration("1.0", "Shift-JIS", null);
            XmlElement issues = datafile.CreateElement("issues");

            datafile.AppendChild(declaration);
            datafile.AppendChild(issues);

            for (int i = 0; i < dm.tickets.Count; i++)
            {

                XmlElement issue = datafile.CreateElement("issue");

                XmlElement id = datafile.CreateElement("id");
                id.InnerText = dm.tickets[i].id.ToString();
                issue.AppendChild(id);

                XmlElement project = datafile.CreateElement("project");
                project.SetAttribute("name", dm.tickets[i].project.name);
                project.SetAttribute("id", dm.tickets[i].project.id.ToString());
                issue.AppendChild(project);

                XmlElement tracker = datafile.CreateElement("tracker");
                tracker.SetAttribute("name", dm.tickets[i].tracker.name);
                tracker.SetAttribute("id", dm.tickets[i].tracker.id.ToString());
                issue.AppendChild(tracker);

                XmlElement status = datafile.CreateElement("status");
                status.SetAttribute("name", dm.tickets[i].status.name);
                status.SetAttribute("id", dm.tickets[i].status.id.ToString());
                issue.AppendChild(tracker);

                XmlElement priority = datafile.CreateElement("priority");
                priority.SetAttribute("name", dm.tickets[i].priority.name);
                priority.SetAttribute("id", dm.tickets[i].priority.id.ToString());
                issue.AppendChild(priority);

                XmlElement author = datafile.CreateElement("author");
                author.SetAttribute("name", dm.tickets[i].auther.name);
                author.SetAttribute("id", dm.tickets[i].auther.id.ToString());
                issue.AppendChild(author);

                XmlElement subject = datafile.CreateElement("subject");
                subject.InnerText = dm.tickets[i].subject;
                issue.AppendChild(subject);

                XmlElement description = datafile.CreateElement("description");
                issue.AppendChild(description);

                XmlElement start_date = datafile.CreateElement("start_date");
                start_date.InnerText = dm.tickets[i].start_date.ToString();
                issue.AppendChild(start_date);

                XmlElement due_date = datafile.CreateElement("due_date");
                due_date.InnerText = dm.tickets[i].due_date.ToString();
                issue.AppendChild(due_date);

                XmlElement done_ratio = datafile.CreateElement("done_ratio");
                done_ratio.InnerText = dm.tickets[i].done_ratio.ToString();
                issue.AppendChild(done_ratio);

                XmlElement is_private = datafile.CreateElement("is_private");
                is_private.InnerText = dm.tickets[i].is_private.ToString();
                issue.AppendChild(is_private);

                XmlElement estimated_hours = datafile.CreateElement("estimated_hours");
                estimated_hours.InnerText = dm.tickets[i].estimated_hours.ToString();
                issue.AppendChild(estimated_hours);

                XmlElement created_on = datafile.CreateElement("created_on");
                created_on.InnerText = dm.tickets[i].created_on.ToString();
                issue.AppendChild(created_on);

                XmlElement updated_on = datafile.CreateElement("updated_on");
                updated_on.InnerText = dm.tickets[i].updated_on.ToString();
                issue.AppendChild(updated_on);

                XmlElement closed_on = datafile.CreateElement("closed_on");
                closed_on.InnerText = dm.tickets[i].closed_on.ToString();
                issue.AppendChild(closed_on);


                issues.AppendChild(issue);
            }



            datafile.Save("test.xml");
        }
    }
}
