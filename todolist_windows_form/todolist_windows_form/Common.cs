using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist_windows_form
{
    public static class Common
    {
        public static readonly Encoding sjisenc = Encoding.GetEncoding("shift_jis");
        public static readonly string localtodoxml = "ToDoItem.xml";
        public static readonly string settingfilename = "setting.config";

        // チケット一覧取得用URLを返す
        public static String GetIssueURL()
        {
            DataModel dm = DataModel.GetInstance();
            StringBuilder sb = new StringBuilder();
            sb.Append(dm.settings.RedmineURL);
            sb.Append("issues.xml/");
            sb.Append("?project_id = 8");
            sb.Append("&key=");
            sb.Append(dm.settings.RedmineKey);
            return sb.ToString();
        }

        // トラッカー一覧取得用URLを返す
        public static String GetTrackersURL()
        {
            return "";
        }
        // ステータス一覧取得用URLを返す
        public static String GetStatusesURL()
        {
            return "";
        }
        // チケット作成用URLを返す
        public static String GetCreateIssueURL()
        {
            return "";
        }
        // チケット更新用URLを返す
        public static String GetUpdateIssueURL()
        {
            return "";
        }
    }

    // Upload時の引数管理
    public class UploadIssueEventArgs : EventArgs
    {
        public String UploadType;
    }
}
