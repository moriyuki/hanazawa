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
        // チケット読み込み
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

        // チケット作成
        public static void Createicket(string url, string key, byte[] issue)
        {
            String httpMethod = "POST";
            var webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;

            byte[] response = webclient.UploadData(url + key, httpMethod, issue);

            // responseを読み込み、エラーの場合はユーザに通知
        }

        // チケット更新
        public static void UpdateTicket(string url, string key, byte[] issue, String issue_id )
        {
            // POST:新規作成
            // PUT: 更新
            String httpMethod = "PUT";
            var webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;

            byte[] response = webclient.UploadData(url + key, httpMethod, issue);

            // responseを読み込み、エラーの場合はユーザに通知
        }
    }
}
