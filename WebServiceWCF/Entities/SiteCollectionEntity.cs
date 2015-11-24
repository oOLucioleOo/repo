using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    [DataContract]
    public class SiteCollectionEntity
    {
        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public ICollection<SiteEntity> SitesCollection { get; set; }

        public SiteCollectionEntity()
        {
            SitesCollection = new List<SiteEntity>();
        }

       
    }
}
