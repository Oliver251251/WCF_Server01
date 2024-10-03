using Service.Models;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Service.Interfaces
{
    [ServiceContract]
    public interface IFelhasznalok
    {
        [OperationContract]
        List<Felhasznalok> FelhasznalokLista_CS();

        [OperationContract]
        string FelhasznaloHozzaAd_CS(Felhasznalok felhasznalo);

        [OperationContract]
        string FelhasznaloModosit_CS(Felhasznalok felhasznalo);

        [OperationContract]
        string FelhasznaloTorol_CS(int Id);

        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/FelhasznalokLista")]
        List<Felhasznalok> FelhasznalokLista_Web();

        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/FelhasznaloHozzaAd")]
       string FelhasznaloHozaAd_Web(Felhasznalok felhasznalo);

        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/FelhasznaloModosit")]
        string FelhasznaloModosit_Web(Felhasznalok felhasznalo);

        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/FelhasznaloTorol?Id={Id}")]
        string FelhasznaloTorol_Web(int Id);
    }
}
