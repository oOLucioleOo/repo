﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class WebApplicationEntity
    {
        public WebApplicationEntity()
        {
            WebApplication = new List<SiteCollectionEntity>();
        }
    }
}
