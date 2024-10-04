using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Service.DTO;

namespace Service.Interfaces
{
    [ServiceContract]
    public interface IDTOs
    {
        [OperationContract]
        List<FelhasznalokNevEmail> FelhasznalokNevEmail_CS();
    }
}