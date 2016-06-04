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

    }

    // Upload時の引数管理
    public class UploadIssueEventArgs : EventArgs
    {
        public String UploadType;
    }
}
