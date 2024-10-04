using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{

    [ServiceContract]
    public interface IService1 : IFelhasznalok, IJogosultsagok, IDTOs, ILogin
    {

    }
    //d9f9c15473a78258b88ca255524613a10568c98e79e9bec9dbf928e31b319eed
}
