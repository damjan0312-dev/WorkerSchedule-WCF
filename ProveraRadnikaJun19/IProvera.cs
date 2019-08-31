using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProveraRadnikaJun19
{
    [ServiceContract]
    public interface IProvera
    {
        [OperationContract]
        Boolean login(string ime);
        [OperationContract]
        Boolean logout(string ime);
        [OperationContract]
        List<string> listaPrisustva(string ime_radnika);
    }

   
}
