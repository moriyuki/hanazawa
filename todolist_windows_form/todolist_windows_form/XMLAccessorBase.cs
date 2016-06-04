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

        public class TagList
        {
            private TagNameID _id;
            private String _name;

            public TagList(TagNameID id, String name)
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

        protected List<TagList> tag = new List<TagList>();

        protected String parentnode; 

        public XMLAccessorBase()
        {
            tag.Add(new TagList(TagNameID.Innertext, "id"));
            tag.Add(new TagList(TagNameID.Innertext, "name"));
        }

        public XmlNodeList Download(string url, string key)
        {
            var webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;

            string targeturl = url + key;

            this._source = webclient.DownloadString(targeturl);

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(this._source);

            return xmldoc.GetElementsByTagName(parentnode);

        }
    }
}
