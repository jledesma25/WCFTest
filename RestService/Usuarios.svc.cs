using RestService.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RestService.Dominio;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Usuarios" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Usuarios.svc or Usuarios.svc.cs at the Solution Explorer and start debugging.
    public class Usuarios : IUsuarios
    {
        private UsuarioDAO dao = new UsuarioDAO();

        public List<Usuario> ListarUsuarios()
        {
            return dao.ListarTodos();
        }
        public Usuario LoginUsuarios(string usuario, string clave)
        {
            return dao.LoginUsuarios(usuario, clave);
        }
       
    }
}
