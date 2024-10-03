using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Service.Models
{
    [DataContract]
    public class Jogosultsagok : Record
    {
        [DataMember]
        public byte Szint { get; set; }

        [DataMember]
        public string Nev { get; set; }

        [DataMember]
        public string Leiras { get; set; }
    }
}