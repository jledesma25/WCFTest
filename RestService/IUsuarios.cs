using RestService.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuarios" in both code and config file together.
    [ServiceContract]
    public interface IUsuarios
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "LoginUsuarios/{usuario}/{clave}", ResponseFormat = WebMessageFormat.Json)]
        Usuario LoginUsuarios(string usuario, string clave);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Usuarios", ResponseFormat = WebMessageFormat.Json)]
        List<Usuario> ListarUsuarios();
    }
}
