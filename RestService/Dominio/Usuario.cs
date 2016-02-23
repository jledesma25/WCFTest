using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestService.Dominio
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int UsuarioId { get; set; }
        [DataMember]
        public string UsuarioLogin { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string Clave { get; set; }
        [DataMember]
        public string ClaveCorreo { get; set; }
        [DataMember]
        public bool Estado { get; set; }
        [DataMember]
        public string Respuesta { get; set; }

        //Quinto comentario de otra rama

    }
}