using System.ServiceModel;
using Entities;

namespace Interfaces.ServicesContracts
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        EDFEntity GetData();

    }
    
}
