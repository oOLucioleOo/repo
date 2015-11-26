using DataAccess.DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Business.BLLInterfaces;
using Helpers;

namespace Business.BLL
{
    public class XmlManagerBLL : IXmlManagerBLL
    {

        public EDFEntity LoadData(string xmlName)
        {
            XmlReaderDAL manager = new XmlReaderDAL(xmlName);
            return CreateEDFEntity(manager.Root);
        }

        private static EDFEntity CreateEDFEntity(XContainer element)
        {
            var entity = new EDFEntity();
            var childList = element.Elements("SharePoint");
            foreach (var el in childList)
            {
                entity.EDF.Add(CreateSharePointEntity(el));
            }
            return entity;
        }

        private static SharePointEntity CreateSharePointEntity(XContainer element)
        {
            var entity = new SharePointEntity();
            var childList = element.Elements("WebApplication");
            foreach (var el in childList)
            {
                entity.SharePoint.Add(CreateWebApplicationEntity(el));
            }
            return entity;
        }
        
        private static WebApplicationEntity CreateWebApplicationEntity(XContainer element)
        {
            var childList = element.Elements("SitesCollection");
            var wae = new WebApplicationEntity();
            foreach (var el in childList)
            {
                wae.WebApplication.Add(CreateSitesCollectionEntity(el));
            }
            return wae;
        }

        private static SiteCollectionEntity CreateSitesCollectionEntity(XContainer element)
        {
            var childList = element.Elements("Site");
            var sitesCollection = new SiteCollectionEntity();
            foreach (var el in childList)
            {
                sitesCollection.SitesCollection.Add(CreateSiteEntity(el));
            }
            return sitesCollection;
        }

        private static SiteEntity CreateSiteEntity(XContainer el)
        {
            var site = new SiteEntity
                {
                    NomAdmin = el.FindXName(AppSettings.GetNomAdmin()),
                    LoginAdmin = el.FindXName(AppSettings.GetLoginAdmin()),
                    Langue = el.FindXName(AppSettings.GetLangue()),
                    Url = el.FindXName(AppSettings.GetUrl()),
                    Modele = el.FindXName(AppSettings.GetModele()),
                    Charte = el.FindXName(AppSettings.GetCharte()),
                    NomProprietaire = el.FindXName(AppSettings.GetNomProprietaire()),
                    LoginProprietaire = el.FindXName(AppSettings.GetLoginProprietaire()),
                    NomEspace = el.FindXName(AppSettings.GetNomEspace()),
                    DescriptionEspace = el.FindXName(AppSettings.GetDescriptionEspace()),
                    CodeUM = el.FindXName(AppSettings.GetCodeUM()),
                    OffreService = el.FindXName(AppSettings.GetOffreService()),
                    TypeAcces = el.FindXName(AppSettings.GetTypeAcces()),
                    NiveauAudience = el.FindXName(AppSettings.GetNiveauAudience()),
                    Direction = el.FindXName(AppSettings.GetDirection()),
                    Date = el.FindXName(AppSettings.GetDate()),
                    VersionModele = el.FindXName(AppSettings.GetVersionModele()),
                    ID = Guid.Parse(el.FindXName(AppSettings.GetGuidSite())),
                    Ferme = el.FindXName(AppSettings.GetFerme())
                };
            return site;
        }

    }
}
