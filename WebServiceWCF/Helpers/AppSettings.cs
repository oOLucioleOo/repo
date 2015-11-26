using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class AppSettings
    {
        public static string GetXmlFileName()
        {
            return ConfigurationManager.AppSettings["XML_FileName"];
        }

        public static string GetNomAdmin()
        {
            return ConfigurationManager.AppSettings["NomAdmin"] ?? ""  ;
        }

        public static string GetLoginAdmin()
        {
            return ConfigurationManager.AppSettings["LoginAdmin"] ?? "";
        }

        public static string GetLangue()
        {
            return ConfigurationManager.AppSettings["Langue"] ?? "";
        }

        public static string GetUrl()
        {
            return ConfigurationManager.AppSettings["Url"] ?? "";
        }
        public static string GetModele()
        {
            return ConfigurationManager.AppSettings["Modele"] ?? "";
        }
        public static string GetCharte()
        {
            return ConfigurationManager.AppSettings["Charte"] ?? "";
        }
        public static string GetNomProprietaire()
        {
            return ConfigurationManager.AppSettings["NomProprietaire"] ?? "";
        }
        public static string GetLoginProprietaire()
        {
            return ConfigurationManager.AppSettings["LoginProprietaire"] ?? "";
        }

        public static string GetNomEspace()
        {
            return ConfigurationManager.AppSettings["NomEspace"] ?? "";
        }
        public static string GetDescriptionEspace()
        {
            return ConfigurationManager.AppSettings["DescriptionEspace"] ?? "";
        }
        public static string GetCodeUM()
        {
            return ConfigurationManager.AppSettings["CodeUM"] ?? "";
        }
        public static string GetOffreService()
        {
            return ConfigurationManager.AppSettings["OffreService"] ?? "";
        }
        public static string GetTypeAcces()
        {
            return ConfigurationManager.AppSettings["TypeAcces"] ?? "";
        }
        public static string GetNiveauAudience()
        {
            return ConfigurationManager.AppSettings["NiveauAudience"] ?? "";
        }
        public static string GetDirection()
        {
            return ConfigurationManager.AppSettings["Direction"] ?? "";
        }
        public static string GetDate()
        {
            return ConfigurationManager.AppSettings["Date"] ?? "";
        }
        public static string GetVersionModele()
        {
            return ConfigurationManager.AppSettings["VersionModele"] ?? "";
        }
        public static string GetGuidSite()
        {
            return ConfigurationManager.AppSettings["GuidSite"] ?? "";
        }
        public static string GetFerme()
        {
            return ConfigurationManager.AppSettings["Ferme"] ?? "";
        }
    } 
}
