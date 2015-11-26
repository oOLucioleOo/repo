using System.IO;
using System.Xml.Linq;

namespace DataAccess.DAL
{
    public class XmlReaderDAL
    {
        public XElement Root { get; set; }
        private string _xmlName;
        readonly string _appPath = Directory.GetCurrentDirectory();
        public XmlReaderDAL(string fileName)
        {
            ReadXml(fileName);
        }

        private XmlReaderDAL() { }

        private void ReadXml(string fileName)
        {
            string path;
            if (fileName.Equals(_xmlName) && Root == null)
            {
                path = Path.Combine(_appPath, _xmlName);
                Root = XElement.Load(path);
            }
            else if(!fileName.Equals(_xmlName))
            {
                path = Path.Combine(_appPath, fileName);
                _xmlName = fileName;
                Root = XElement.Load(path);
            }
            
        }
        
    }
}
