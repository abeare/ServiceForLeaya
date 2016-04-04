using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceForLeaya
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract(Namespace = "http://osman.com")]
    public interface IService1
    {
        [OperationContract]
        Complexdata[] gauss_c(Complexdata[] www, int n);


    }


    public class Complexdata
    {

        public double Real
        {
            get;
            set;
        }


        public double Imaginary
        {
            get;
            set;
        }
    }
}
