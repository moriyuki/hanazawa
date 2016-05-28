using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist_windows_form
{
    class Xmltracker : XMLAccessorBase
    {

        public Xmltracker()
        {
            base.parentnode = "tracker";
            base.tag.Add(new TagList(TagNameID.IDnameattribute, "default_status"));
        }

        public void Download(string url, string key)
        {
            base.Download(url, key);
        }

        
    }
}
