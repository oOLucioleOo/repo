using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Helpers
{
    public static class XmlLinqHelper
    {
        public static string FindXName(this XContainer element, string name)
        {
            var xElement = element.Element(name);
            return xElement == null ? string.Empty : xElement.Value;
        }


        public static IEnumerable<XContainer> SelectRootNodes(this XContainer parentElement, string nodeName)
        {
            return from el in parentElement.Elements(nodeName) select el;
        }

    }
}
