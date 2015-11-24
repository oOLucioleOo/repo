using Business.BLL;
using Entities;

namespace Interfaces
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service : IService
    {
        public WebApplicationEntity GetData()
        {
            return WebApplicationBLL.GetWebApplicationFromXML(Helpers.AppSettings.GetXmlFileName());
        }
    }
}
