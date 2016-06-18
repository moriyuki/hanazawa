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
        public static void DownloadTicket(string url)
        {
            var webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;

            string targeturl = url;
            try
            {
                string source = webclient.DownloadString(targeturl);
                byte[] temp = Encoding.UTF8.GetBytes(source);
                byte[] sjistemp = Encoding.Convert(Encoding.UTF8, Common.sjisenc, temp);
                string sjisstr = Common.sjisenc.GetString(sjistemp);
                System.IO.File.WriteAllText(Common.localtodoxml, sjisstr, Common.sjisenc);
            }

            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
         }

        // チケット作成 ticketデータ -> byte配列に変換
        public static void Createticket(DataModel.ticket tic)
        {
            var webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;
            StoreManager sm = new StoreManager();
            byte[] issue = sm.UpdateIssue(tic);

            Createticket(Common.GetCreateIssueURL(), issue);
            // responseを読み込み、エラーの場合はユーザに通知
        }

        // チケット作成  サーバ問い合わせ
        private static void Createticket(string url, byte[] issue)
        {
            String httpMethod = "POST";
            var webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;

            byte[] response = webclient.UploadData(url, httpMethod, issue);

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
