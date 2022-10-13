using System.ServiceModel;

namespace SOR_2
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        int multiply(int valAm, int valB);
    }
}
