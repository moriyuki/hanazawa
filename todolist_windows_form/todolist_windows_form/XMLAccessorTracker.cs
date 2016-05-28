using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist_windows_form
{
    class XMLAccessorTracker : XMLAccessorBase
    {
        public XMLAccessorTracker()
        {
            base.parentnode = "tracker";
        }
        public void Download()
        {
            base.Download("sample","hogehoge");
        }
    }
}
