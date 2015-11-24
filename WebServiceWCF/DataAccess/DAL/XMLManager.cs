
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace DataAccess.DAL
{
    public class XmlManager 
    {
        private XElement root;
        private static XmlManager _xmlManager;
        private string _xmlName;
        string appPath = Directory.GetCurrentDirectory();
        private XmlManager(string fileName)
        {
            _xmlName = fileName;
            LoadXML();
        }

        public static XmlManager GetXmlManager(string fileName)
        {
            if (null == _xmlManager || !_xmlManager.Equals(fileName))
            {
                _xmlManager = new XmlManager(fileName);
            }
            return _xmlManager;
        }

        private void LoadXML()
        {
            var _path = Path.Combine(appPath, _xmlName);
            root = XElement.Load(_path);
        }

        public IEnumerable<XElement> SelectNodes(string nodeName)
        {
            return from el in GetXmlManager(_xmlName).root.Elements(nodeName) select el;
        }

        

    }
}
