using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ServiceContract
{
  [ServiceContract]
  public interface ISampleService
  {
    [OperationContract(IsOneWay = true)]
    void ShortOneWay(string msg);

    [OperationContract(IsOneWay = true)]
    void LongOneWay(string msg);

    [OperationContract]
    void Short(string msg);

    [OperationContract]
    void Long(string msg);

  }
}
