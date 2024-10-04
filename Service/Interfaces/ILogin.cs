using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Service.Models;

namespace Service.Interfaces
{
    [ServiceContract]
    public interface ILogin
    {
        [OperationContract]
        string GetSalt_CS(string loginNev);

        [OperationContract]
        string Login_CS(Login login);
    }
}
