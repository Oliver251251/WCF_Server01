using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    [ServiceContract]
    public interface IJogosultsagok
    {
        [OperationContract]
        List<Jogosultsagok> JogosultsagokLista_CS();

        [OperationContract]
        string JogosultsagokHozzaAd_CS(Jogosultsagok jogosultsag);

        [OperationContract]
        string JogosultsagokModosit_CS(Jogosultsagok jogosultsag);

        [OperationContract]
        string JogosultsagokTorol_CS(int Id);

        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/Jogosultsagok")]
        List<Jogosultsagok> JogosultsagokLista_Web();

        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/Jogosultsagok")]
        string JogosultsagokHozaAd_Web(Jogosultsagok jogosultsagok);

        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/Jogosultsagok")]
        string JogosultsagokModosit_Web(Jogosultsagok jogosultsagok);

        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/Jogosultsagok?Id={Id}")]
        string JogosultsagokTorol_Web(int Id);
    }
}
