using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist_windows_form
{
    public class DataModel
    {
        // 自分自身のインスタンス
        private static DataModel dm = new DataModel();
        public int IDManager;

        public static DataModel GetInstance()
        {
            return dm;
        }

        public int GetNextID()
        {
            return ++IDManager;
        }

        public struct idname
        {
            public int id;
            public String name;

            public void init()
            {
                id = 0;
                name = String.Empty;
            }

            public bool IsEqual(idname i)
            {
                if (!id.Equals(i.id))
                {
                    return false;
                }

                if (String.IsNullOrEmpty(name) || !name.Equals(i.name))
                {
                    return false;
                }
                return true;
            }
        }


        public struct ticket
        {

            // チケット構成要素
            public int id;

            public idname project;
            public idname tracker;
            public idname status;
            public idname priority;
            public idname auther;
            public String subject;
            public String description;
            public DateTime start_date;
            public DateTime due_date;
            public int done_ratio;
            public bool is_private;
            public float estimated_hours;
            public DateTime created_on;
            public DateTime updated_on;
            public DateTime closed_on;

            public bool done;

            

            // チケット構成要素初期化
            public void initTicket()
            {
                id = 0;
                project.init();
                tracker.init();
                status.init();
                priority.init();
                auther.init();
                subject = String.Empty;
                description = String.Empty;
                start_date = DateTime.MinValue;
                due_date = DateTime.MinValue;
                done_ratio = 0;
                is_private = false;
                estimated_hours = 0;
                created_on = DateTime.MinValue;
                updated_on = DateTime.MinValue;
                closed_on = DateTime.MinValue;
                done = false;
            }

            public bool IsEqual(ticket t)
            {
                if (!id.Equals(t.id))
                {
                    return false;
                }

                if (!project.IsEqual(t.project))
                {
                    return false;
                }

                if (!tracker.IsEqual(t.tracker))
                {
                    return false;
                }

                if (!status.IsEqual(t.status))
                {
                    return false;
                }

                if (!priority.IsEqual(t.priority))
                {
                    return false;
                }

                if (!auther.IsEqual(t.auther))
                {
                    return false;
                }

                if (!subject.Equals(t.subject))
                {
                    return false;
                }

                if (!description.Equals(t.description))
                {
                    return false;
                }

                if (!start_date.Equals(t.start_date))
                {
                    return false;
                }

                if (!due_date.Equals(t.due_date))
                {
                    return false;
                }

                if (done_ratio != t.done_ratio)
                {
                    return false;
                }

                if (is_private != t.is_private)
                {
                    return false;
                }

                if (estimated_hours != t.estimated_hours)
                {
                    return false;
                }

                if (!created_on.Equals(t.created_on))
                {
                    return false;
                }

                if (!updated_on.Equals(t.updated_on))
                {
                    return false;
                }

                if (!closed_on.Equals(t.closed_on))
                {
                    return false;
                }

                if (done != t.done)
                {
                    return false;
                }

                // すべて同じ場合はTrue
                return true;
            } 
        }

        public List<ticket> tickets = new List<ticket>();

        // チケットのステータス管理用クラス
        public class StatusItem
        {
            private int _id;
            private String _name;
            private bool _is_closed;


            public StatusItem(int id, String name, bool is_closed)
            {
                this._id = id;
                this._name = name;
                this._is_closed = is_closed;
            }
            public StatusItem() { }
            public int id { get; set; }
            public String name { get; set; }
            public bool is_closed { get; set; }

            public override string ToString()
            {
                return this.name;
            }
        }

        public List<StatusItem> statusItems = new List<StatusItem>();

        // チケットのトラッカー管理用クラス
        public class TrackerItem
        {
            private int _id;
            private String _name;
            private idname _defaultstatus;


            public TrackerItem(int id, String name, idname defaultstatus)
            {
                this._id = id;
                this._name = name;
                this._defaultstatus = defaultstatus;
            }
            public TrackerItem() { }
            public int id { get; set; }
            public String name { get; set; }
            public idname defaultstatus { get; set; }

            public override string ToString()
            {
                return this.name;
            }
        }

        public List<TrackerItem> trackerItems = new List<TrackerItem>();

        public static implicit operator DataModel(idname v)
        {
            throw new NotImplementedException();
        }

        // 設定情報保持クラス
        public class Settings
        {
            public
                String _serverURL;
                String _user;
                String _password;

                String _redmineURL;
                String _redmineKey;

            public String ServerURL
            {
                get { return _serverURL; }
                set { _serverURL = value; }
            }
            public String User
            {
                get { return _user; }
                set { _user = value; }
            }
            public String Password
            {
                get { return _password; }
                set { _password = value; }
            }

            public String RedmineURL
            {
                get { return _redmineURL; }
                set { _redmineURL = value; }
            }

            public String RedmineKey
            {
                get { return _redmineKey; }
                set { _redmineKey = value; }
            }

        }
        public Settings settings = new Settings();

    }
}
