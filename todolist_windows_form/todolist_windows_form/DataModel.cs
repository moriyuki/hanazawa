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

        public struct ticket
        {
            // チケット構成要素
            String ticketTitle;
            int ticketId;
            bool existTicketFrom;
            DateTime ticketFrom;
            bool existTicketTo;
            DateTime ticketTo;
            String belongProject;
            int workHour;
            bool done;
            DateTime doneDt;

            // チケット構成要素初期化
            void initTicket()
            {
                ticketTitle = "";
                belongProject = "";
                ticketFrom = DateTime.MinValue;
                ticketTo = DateTime.MinValue;
                doneDt = DateTime.MinValue;
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
