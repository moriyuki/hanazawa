using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist_windows_form
{
    class DataModel
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
            int id;
            String name;

            public void init()
            {
                id = 0;
                name = String.Empty;
            }
        }

        public struct ticket
        {
            // チケット構成要素
            int id;

            //public struct project
            //{
            //    String name;
            //    int id;
            //}
            //public struct tracker
            //{ String name; int id; }
            //public struct status
            //{ String name; int id; }
            //public struct priorityt
            //{ String name; int id; }
            //public struct author
            //{ String name; int id; }

            //ここまで

            idname project;
            idname tracker;
            idname status;
            idname priority;
            idname auther;
            String subject;
            String description;
            DateTime start_date;
            DateTime due_date;
            int done_ratio;
            bool is_private;
            float estimated_hours;
            DateTime created_on;
            DateTime updated_on;
            DateTime closed_on;

            bool done;

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
            }
        }
        // end struct

        public List<ticket> tickets = new List<ticket>();

        // 新規チケット追加
        // チケット編集
        // チケット完了
        // チケット削除


    }
}
