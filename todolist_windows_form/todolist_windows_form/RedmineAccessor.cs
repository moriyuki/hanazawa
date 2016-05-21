using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace todolist_windows_form
{
    class RedmineAccessor
    {
        public static void DownloadTicket(string url, string key)
        {
            var webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;

            string targeturl = url + key;

            string source = webclient.DownloadString(targeturl);

            byte[] temp = Encoding.UTF8.GetBytes(source);
            byte[] sjistemp = Encoding.Convert(Encoding.UTF8, Common.sjisenc, temp);

            string sjisstr = Common.sjisenc.GetString(sjistemp);

            System.IO.File.WriteAllText(Common.localtodoxml, sjisstr, Common.sjisenc);
        }

    }
}
