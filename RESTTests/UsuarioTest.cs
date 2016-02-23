using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace RESTTests
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void CRUDListarTodos()
        {
            // Prueba de creación de alumno vía HTTP POST

            //byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:3181/Usuarios.svc/Usuarios");
            req.Method = "GET";
            // req.ContentLength = data.Length;
            req.ContentType = "application/json";
            //  var reqStream = req.GetRequestStream();
            // reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = null;

            try
            {
                res = (HttpWebResponse)req.GetResponse(); // si esto no falla, continua
                //caso positivo
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string usuarioJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<Usuario> usuarioCreado = js.Deserialize<List<Usuario>>(usuarioJson);
                Assert.AreEqual(100, usuarioCreado.Count());

            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        public void LoginUsuarios()
        {
            // Prueba de creación de alumno vía HTTP POST

            //byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:3181/Usuarios.svc/Usuarios/Administrador/jubmnfdbo");
            req.Method = "GET";
            // req.ContentLength = data.Length;
            req.ContentType = "application/json";
            //  var reqStream = req.GetRequestStream();
            // reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = null;

            try
            {
                res = (HttpWebResponse)req.GetResponse(); // si esto no falla, continua
                //caso positivo
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string usuarioJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string usuarioCreado = js.Deserialize<string>(usuarioJson);
                Assert.AreEqual(100, usuarioCreado);

            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
