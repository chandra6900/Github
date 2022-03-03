
using System.ServiceModel;
using tempWCF.Entities;

namespace tempWCF.Contracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITempServiceContract
    {

        [OperationContract]
        string GetSimpleType(int value);

        [OperationContract]
        ComplexType GetComplexType(ComplexType temp);

        // TODO: Add your service operations here
    }
}
