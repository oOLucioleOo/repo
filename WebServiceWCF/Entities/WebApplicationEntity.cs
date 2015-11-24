using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [DataContract]
    public class WebApplicationEntity
    {
        public WebApplicationEntity()
        {
            WebApplication = new List<SiteCollectionEntity>();
        }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public ICollection<SiteCollectionEntity> WebApplication { get; set; }
    }
}
