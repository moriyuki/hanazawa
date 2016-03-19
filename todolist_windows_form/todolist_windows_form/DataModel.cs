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

        private DataModel()
        {
            // インスタンスが生成されます
            IDManager = 0;
        }

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

            // public 
        }
        // end struct

        public List<ticket> tickets = new List<ticket>();

        // 新規チケット追加
        // チケット編集
        // チケット完了
        // チケット削除


    }
}
