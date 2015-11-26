using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [DataContract]
    public partial class SiteEntity
    {
        [DataMember]
        public string NomAdmin { get; set; }
        [DataMember]
        public string LoginAdmin { get; set; }
        [DataMember]
        public string Langue { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string Modele { get; set; }
        [DataMember]
        public string Charte { get; set; }
        [DataMember]
        public string NomProprietaire { get; set; }
        [DataMember]
        public string LoginProprietaire { get; set; }
        [DataMember]
        public string NomEspace { get; set; }
        [DataMember]
        public string DescriptionEspace { get; set; }
        [DataMember]
        public string CodeUM { get; set; }
        [DataMember]
        public string OffreService { get; set; }
        [DataMember]
        public string TypeAcces { get; set; }
        [DataMember]
        public string NiveauAudience { get; set; }
        [DataMember]
        public string Direction { get; set; }
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public string VersionModele { get; set; }
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public string Ferme { get; set; }
    }
}
