using DataAccess.DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Business.BLL
{
    public class WebApplicationBLL
    {
        public static WebApplicationEntity GetWebApplicationFromXML(string xmlFileName)
        {
            XmlManager manager = XmlManager.GetXmlManager(xmlFileName);
            return CreateWebApplication(manager.SelectNodes("SitesCollections"));
        }

        private static WebApplicationEntity CreateWebApplication(IEnumerable<XElement> rootNode)
        {
            WebApplicationEntity wae = new WebApplicationEntity();
            foreach (XElement el in rootNode)
            {
                wae.WebApplication.Add(CreateSitesCollection(el.Elements("Sites")));
            }
            return wae;
        }

        private static SiteCollectionEntity CreateSitesCollection(IEnumerable<XElement> rootNode)
        {

            SiteCollectionEntity sitesCollection = new SiteCollectionEntity();
            foreach (XElement el in rootNode)
            {
                sitesCollection.SitesCollection.Add(CreateSite(el));
            }
            return sitesCollection;
        }

        private static SiteEntity CreateSite(XElement el)
        {
            var site = new SiteEntity();
            site.NomAdmin = el.Element(Helpers.AppSettings.GetNomAdmin()).Value;
            site.LoginAdmin = el.Element(Helpers.AppSettings.GetLoginAdmin()).Value;
            site.Langue = el.Element(Helpers.AppSettings.GetLangue()).Value;
            site.Url = el.Element(Helpers.AppSettings.GetUrl()).Value;
            site.Modele = el.Element(Helpers.AppSettings.GetModele()).Value;
            site.Charte = el.Element(Helpers.AppSettings.GetCharte()).Value;
            site.NomProprietaire = el.Element(Helpers.AppSettings.GetNomProprietaire()).Value;
            site.LoginProprietaire = el.Element(Helpers.AppSettings.GetLoginProprietaire()).Value;
            site.NomEspace = el.Element(Helpers.AppSettings.GetNomEspace()).Value;
            site.DescriptionEspace = el.Element(Helpers.AppSettings.GetDescriptionEspace()).Value;
            site.CodeUM = el.Element(Helpers.AppSettings.GetCodeUM()).Value;
            site.OffreService = el.Element(Helpers.AppSettings.GetOffreService()).Value;
            site.TypeAcces = el.Element(Helpers.AppSettings.GetTypeAcces()).Value;
            site.NiveauAudience = el.Element(Helpers.AppSettings.GetNiveauAudience()).Value;
            site.Direction = el.Element(Helpers.AppSettings.GetDirection()).Value;
            site.Date = el.Element(Helpers.AppSettings.GetDate()).Value;
            site.VersionModele = el.Element(Helpers.AppSettings.GetVersionModele()).Value;
            site.ID = Guid.Parse(el.Element(Helpers.AppSettings.GetGuidSite()).Value);
            site.Ferme = el.Element(Helpers.AppSettings.GetFerme()).Value;
            return site;
        }
    }
}
