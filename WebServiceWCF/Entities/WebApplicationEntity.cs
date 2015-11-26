﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [DataContract]
    public partial class WebApplicationEntity
    {

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public ICollection<SiteCollectionEntity> WebApplication { get; set; }
    }
}
