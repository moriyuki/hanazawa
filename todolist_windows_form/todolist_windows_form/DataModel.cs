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

        private DataModel()
        {
            // インスタンスが生成されます
        }

        public static DataModel GetInstance()
        {
            return dm;
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
