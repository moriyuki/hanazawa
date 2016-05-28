using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.IO;

namespace todolist_windows_form
{
    class XMLAccessorBase
    {
        String _source;


        public enum TagNameID { Innertext, IDnameattribute, }

        //String _path;

        //public String Path
        //{
        //    get { return _path; }
        //    set { _path = value; }
        //}
        public class TagList
        {
            private TagNameID _id;
            private String _name;
            private object _val;

            public TagList(TagNameID id, String name, object val)
            {
                this._id = id;
                this._name = name;
            }

            public TagNameID id
            {
                get;
                set;
            }
            public String name
            {
                get;
                set;
            }
        }
        public class StatusItem
        {
            private int _id;
            private String _name;
            private bool _is_closed;
           

            public StatusItem(int id, String name, bool is_closed)
            {
                this._id = id;
                this._name = name;
                this._is_closed = is_closed;
            }
            public StatusItem()
            {

            }
            public int id
            {
                get;
                set;
            }
            public String name
            {
                get;
                set;
            }
            public bool is_closed
            {
                get;
                set;
            }
            public object val
            {
                get; set;
            }
        }

        protected List<TagList> tag = new List<TagList>();
        protected List<StatusItem> status = new List<StatusItem>();

        protected String parentnode; 

        public XMLAccessorBase()
        {
            tag.Add(new TagList(TagNameID.Innertext, "id", id.StatusItem.id));
            tag.Add(new TagList(TagNameID.Innertext, "name"));
        }

        public void Download(string url, string key)
        {
            var webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;

            string targeturl = url + key;

            this._source = webclient.DownloadString(targeturl);

            XmlTextReader reader = new XmlTextReader(new StringReader(this._source));

            while (reader.Read())
            {
                if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals(this.parentnode))
                {
                    StatusItem si = new StatusItem();

                    while (reader.Read())
                    {

                        if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("id"))
                        {
                            // id 読み込み
                            si.id = int.Parse(reader.ReadString());
                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("name"))
                        {
                            // id 読み込み
                            si.name = reader.ReadString();
                        }
                        else if (reader.NodeType.Equals(XmlNodeType.Element) && reader.Name.Equals("is_closed"))
                        {
                            // id 読み込み
                            si.is_closed = bool.Parse(reader.ReadString());
                        }
                    }
                    status.Add(si);
                }
            }
        }
    }
}
