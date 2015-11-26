using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [DataContract]
    public partial class SharePointEntity
    {

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public ICollection<WebApplicationEntity> SharePoint { get; set; }
    }
}
