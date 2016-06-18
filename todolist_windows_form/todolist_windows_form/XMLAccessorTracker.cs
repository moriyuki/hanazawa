using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace todolist_windows_form
{
    class XMLAccessorTracker : XMLAccessorBase
    {
        public XMLAccessorTracker()
        {
            base.parentnode = "tracker";
        }
        public new void Download(String url)
        {
            DataModel dm = DataModel.GetInstance();
            try {
                XmlNodeList trackers = base.Download(url);

                if (trackers == null)
                {
                    return;
                }

                foreach (XmlElement parentelm in trackers)
                {
                    DataModel.TrackerItem ti = new DataModel.TrackerItem();

                    foreach (XmlElement elm in parentelm.ChildNodes)
                    {

                        if (elm.Name.Equals("id"))
                        {
                            ti.id = int.Parse(elm.InnerText);
                        }
                        else if (elm.Name.Equals("name"))
                        {
                            ti.name = elm.InnerText;
                        }
                        else if (elm.Name.Equals("default_status"))
                        {
                            DataModel.idname idnameVal = new DataModel.idname();
                            foreach (XmlAttribute atr in elm.Attributes)
                            {
                                if (atr.Name == "id")
                                {
                                    idnameVal.id = int.Parse(atr.InnerText);
                                }
                                else if (atr.Name == "name")
                                {
                                    idnameVal.name = atr.InnerText;
                                }
                            }
                            ti.defaultstatus = idnameVal;
                        }
                    }
                    dm.trackerItems.Add(ti);
                }
            }
            catch (Exception ex)
            {
            }
        }
        
    }
}
