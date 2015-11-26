using Business.BLL;
using Business.BLLInterfaces;
using Entities;
using Interfaces.ServicesContracts;

namespace Interfaces.ServicesImplementation
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service : IService
    {
        public EDFEntity GetData()
        {
            IXmlManagerBLL manager = new XmlManagerBLL();
            return manager.LoadData(Helpers.AppSettings.GetXmlFileName());
        }
    }
}
