using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace todolist_windows_form
{
    class XMLAccessorStatus : XMLAccessorBase
    {
        public XMLAccessorStatus()
        {
            base.parentnode = "issue_status";
        }
        public new void Download(String url)
        {
            DataModel dm = DataModel.GetInstance();
            try {
                XmlNodeList statuses = base.Download(url);

                if (statuses == null)
                {
                    return;
                }

                foreach (XmlElement parentelm in statuses)
                {
                    DataModel.StatusItem si = new DataModel.StatusItem();

                    foreach (XmlElement elm in parentelm.ChildNodes)
                    {

                        if (elm.Name.Equals("id"))
                        {
                            si.id = int.Parse(elm.InnerText);
                        }
                        else if (elm.Name.Equals("name"))
                        {
                            si.name = elm.InnerText;
                        }
                        else if (elm.Name.Equals("is_closed"))
                        {
                            si.is_closed = bool.Parse(elm.InnerText);
                        }
                    }
                    dm.statusItems.Add(si);
                }
            }
            catch(Exception ex){
                
            }
            }
    }
}
